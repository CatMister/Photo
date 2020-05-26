using HuxingEntity;
using HuxingEntity.Site;
using HuxingModel;
using HuxingModel.Community;
using HuxingModel.Enum;
using HuxingModel.Global;
using HuxingService.Config;
using Microsoft.AspNetCore.Http;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HuxingService.Community.Impl
{
    public class PhotoService : PhotoClient, IPhotoService
    {
        IConfigService ConfigService;
        public PhotoService(IConfigService configService)
        {
            ConfigService = configService;
        }

        #region  图片
        /// <summary>
        /// -添加图片
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="file"></param>
        /// <param name="input"></param>
        public void AddPhoto(long userId, IFormFile file, PhotoModel input, string url)
        {
            var currentTime = DateTime.Now;
            var imageUrl = ConfigService.Upload(file);
            url = $"{url}/{imageUrl.Item1}";
            var fileName = string.Empty;
            if (string.IsNullOrEmpty(input.Name))
            {
                fileName = Path.GetFileName(file.FileName);
            }
            else
            {
                fileName = input.Name;
            }
            var entity = new PhotoEntity()
            {
                Name = fileName,
                Url = url,
                UserId = userId,
                Detail = input.Detail,
                SiteUrl = imageUrl.Item2,
                CreateTime = currentTime,
                UpdateTime = currentTime
            };
            DbContext.Insertable(entity).ExecuteCommand();
        }


        /// <summary>
        /// 修改图片
        /// </summary>
        /// <param name="input"></param>
        public void UpdatePhoto(long userId, PhotoModel input)
        {
            CheckEmpty(input.Id, "请选择图片");
            var entity = DbContext.Queryable<PhotoEntity>().Where(c => c.Id == input.Id && c.UserId == userId).First();
            CheckEmpty(entity, "选择的图片不存在");
            CheckEmpty(input.Name, "图片名为空");
            if (!input.Name.Equals(entity.Name))
            {
                entity.Name = input.Name;
                entity.Detail = input.Detail;
                entity.UpdateTime = DateTime.Now;
                DbContext.Updateable(entity).ExecuteCommand();
            }
        }


        /// <summary>
        /// 获取图片列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PageReturnModel<PhotoModel> GetPhoto(long userId, GetPhotoModel input)
        {

            var result = new List<PhotoModel>();
            var total = 0;
            var entityList = DbContext.Queryable<PhotoEntity>()
                .WhereIF(input.IsMyself && userId != 0, c => c.UserId == userId).
                WhereIF(!string.IsNullOrEmpty(input.Like), c => c.Name.Contains(input.Like) || c.Detail.Contains(input.Like))
                .Select(c => new PhotoModel()
                {
                    Name = c.Name,
                    Url = c.Url,
                    Id = c.Id,
                    Detail = c.Detail,
                    UserId = c.UserId
                }).ToPageList(input.PageIndex, input.PageSize, ref total);
            var entityIdList = entityList.Select(c => c.Id).ToList();
            var IsGoodList = DbContext.Queryable<UserAndPhotoEntity>().Where(c => c.IsGood && c.UserId == userId && entityIdList.Contains(c.PhotoId)).Select(c => c.PhotoId).ToList();
            var replyList = GetReplyList(entityIdList, ReplyOfType.Photo, userId);
            foreach (var item in entityList)
            {
                item.IsGood = IsGoodList.Any(c => c == item.Id);
                item.IsMyself = item.UserId == userId;
                item.ReplyList = replyList.Where(c => c.Id == item.Id).OrderBy(c => c.CreateTime).ToList();
            }
            return new PageReturnModel<PhotoModel>() { TotalNum = total, DateList = entityList };
        }



        /// <summary>
        /// 获取图片详情
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PhotoModel GetPhotoDetail(long userId, GetPhotoModel input)
        {
            CheckEmpty(input.Id, "请选择图片");
            var result = new List<PhotoModel>();
            var entity = DbContext.Queryable<PhotoEntity>()
                   .WhereIF(input.IsMyself, c => c.UserId == userId)
                .Where(c => c.Id == input.Id)
                .Select(c => new PhotoModel()
                {
                    Name = c.Name,
                    Detail = c.Detail,
                    Url = c.Url,
                    Id = c.Id,
                    UserId = c.UserId
                }).First();
            CheckEmpty(entity, "选择的图片不存在");
            entity.IsMyself = entity.UserId == userId;
            return entity;
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public void DeletePhoto(long userId, EntityDto<long> input)
        {
            if (input != null && input.Id != 0)
            {
                DbContext.Deleteable<PhotoEntity>().Where(c => c.Id == input.Id && c.UserId == userId).ExecuteCommand();
            }
        }


        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public void UpdateGoodPhoto(long userId, UpdateGoodModel input)
        {
            if (input != null && input.Id != 0)
            {

                var currentTime = DateTime.Now;
                var entity = DbContext.Queryable<UserAndPhotoEntity>().Where(c => c.UserId == userId && c.PhotoId == input.Id).First();
                if (entity == null)
                {
                    DbContext.Insertable(new UserAndPhotoEntity()
                    {
                        UserId = userId,
                        PhotoId = input.Id,
                        CreateTime = currentTime,
                        UpdateTime = currentTime
                    }).ExecuteCommand();
                }
                else
                {
                    entity.IsGood = input.IsGood;
                    entity.UpdateTime = currentTime;
                    DbContext.Updateable(entity).ExecuteCommand();
                }
            }
        }


        #endregion



        #region 动态
        /// <summary>
        /// 获取动态列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public PageReturnModel<DynamicModel> GetDynamicList(long userId, GetDynamicModel input)
        {
            var total = 0;
            var userIdList = new List<long>();
            if (!input.IsMyself)
            {
                userIdList = DbContext.Queryable<UserAndAttentionEntity>().Where(c => c.UserId == userId).Select(c => c.AttentionUserId).ToList();
            }
            userIdList.Add(userId);
            var entityList = DbContext.Queryable<DynamicEntity, UserAndDyanmicEntity, UserEntity>((dynamic, userAnddynamic, user) => new object[]
                 {
                    JoinType.Left,dynamic.Id==userAnddynamic.DyanmicId&&userAnddynamic.UserId==userId,
                    JoinType.Left,dynamic.UserId==user.Id
                 }).Where((dynamic, userAnddynamic, user) => userIdList.Contains(dynamic.UserId)).
                   Select((dynamic, userAnddynamic, user) => new DynamicModel()
                   {
                       Id = dynamic.Id,
                       Context = dynamic.Context,
                       Url = dynamic.Url,
                       UserId = dynamic.UserId,
                       GoodNum = SqlFunc.Subqueryable<UserAndDyanmicEntity>().Where(c => c.IsGood && c.DyanmicId == dynamic.Id).Count(),
                       ViewingNum = dynamic.ViewingNum,
                       IsGood = userAnddynamic.IsGood,
                       UserName = user.NickName,
                       HeadUrl = user.HeadUrl,
                       CreateTime = dynamic.CreateTime

                   }).OrderBy(dynamic => dynamic.Id, OrderByType.Desc).ToPageList(input.PageIndex, input.PageSize, ref total);
            var entityIdList = entityList.Select(c => c.Id).ToList();
            var replyList = GetReplyList(entityIdList, ReplyOfType.Dynamic, userId);
            foreach (var item in entityList)
            {
                item.IsMyself = item.UserId == userId;
                item.ReplyList = replyList.Where(c => c.Id == item.Id).OrderBy(c => c.CreateTime).ToList();
            }
            DbContext.Updateable<DynamicEntity>().UpdateColumns(c => new { c.ViewingNum }).ReSetValue(c => c.ViewingNum == (c.ViewingNum + 1)).Where(c => entityIdList.Contains(c.Id)).ExecuteCommand();
            return new PageReturnModel<DynamicModel>() { TotalNum = total, DateList = entityList };
        }

        /// <summary>
        /// 添加动态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public void AddDynaimic(long userId, DynamicModel input)
        {
            CheckExit(string.IsNullOrEmpty(input.Context) && string.IsNullOrEmpty(input.Url), "动态内容不能为空");
            var entity = new DynamicEntity()
            {
                Context = input.Context,
                Url = input.Url,
                UserId = userId,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            DbContext.Insertable(entity).ExecuteCommand();
        }
        /// <summary>
        /// 删除动态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public void DeleteDynainic(long userId, EntityDto<long> input)
        {
            if (input != null && input.Id != 0)
            {
                DbContext.Deleteable<DynamicEntity>().Where(c => c.Id == input.Id).ExecuteCommand();
            }
        }


        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public void UpdateGoodDynainic(long userId, UpdateGoodModel input)
        {
            if (input != null && input.Id != 0)
            {

                var currentTime = DateTime.Now;
                var entity = DbContext.Queryable<UserAndDyanmicEntity>().Where(c => c.UserId == userId && c.DyanmicId == input.Id).First();
                if (entity == null)
                {
                    DbContext.Insertable(new UserAndDyanmicEntity()
                    {
                        UserId = userId,
                        DyanmicId = input.Id,
                        CreateTime = currentTime,
                        UpdateTime = currentTime
                    }).ExecuteCommand();
                }
                else
                {
                    entity.IsGood = input.IsGood;
                    entity.UpdateTime = currentTime;
                    DbContext.Updateable(entity).ExecuteCommand();
                }
            }
        }
        #endregion



        #region  图文
        /// <summary>
        /// 获取图文列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public PageReturnModel<NewsModel> GetNewsList(long userId, GetNewsModel input)
        {
            var result = new List<NewsModel>();
            var total = 0;
            var entityList = DbContext.Queryable<NewsEntity>()
                .WhereIF(input.IsMyself, c => c.UserId == userId)
                .WhereIF(!string.IsNullOrEmpty(input.Like), c => c.Summary.Contains(input.Like) || c.Content.Contains(input.Like) || c.Titie.Contains(input.Like))
                .Select(c => new NewsModel()
                {
                    Id = c.Id,
                    Titie = c.Titie,
                    Url = c.Url,
                    Summary = c.Summary,
                    Content = c.Content,
                    UserId = c.UserId,
                    GoodNum = c.GoodNum,
                    ViewingNum = c.ViewingNum,
                }).OrderBy(c => c.Id, OrderByType.Desc).ToPageList(input.PageIndex, input.PageSize, ref total);

            var entityIdList = entityList.Select(c => c.Id).ToList();
            var replyList = GetReplyList(entityIdList, ReplyOfType.News, userId);
            foreach (var item in entityList)
            {
                item.IsMyself = item.UserId == userId;
                item.ReplyList = replyList.Where(c => c.Id == item.Id).OrderBy(c => c.CreateTime).ToList();
            }
            return new PageReturnModel<NewsModel>() { TotalNum = total, DateList = entityList };
        }


        /// <summary>
        /// 删除图文
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public void DeleteNews(long userId, EntityDto<long> input)
        {
            if (input != null && input.Id == 0)
            {
                DbContext.Deleteable<NewsEntity>().Where(c => c.Id == input.Id && c.UserId == userId).ExecuteCommand();
            }

        }



        /// <summary>
        /// 添加图文
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public void AddNews(long userId, NewsModel input)
        {
            var currentTime = DateTime.Now;
            CheckEmpty(input.Content, "请输入正文");
            CheckEmpty(input.Summary, "请输入文章摘要");
            CheckEmpty(input.Titie, "标题不能为空");
            var entity = new NewsEntity()
            {
                Titie = input.Titie,
                Url = input.Url,
                Summary = input.Summary,
                Content = input.Content,
                UserId = input.UserId,
                CreateTime = currentTime,
                UpdateTime = currentTime
            };
            DbContext.Insertable(entity).ExecuteCommand();
        }

        /// <summary>
        /// 获取图片详情
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public NewsModel GetNewsDetail(long userId, EntityDto<long> input)
        {
            CheckEmpty(input, "你选择的图文详情不存在");
            CheckEmpty(input.Id, "你选择的图文详情不存在");
            var entity = DbContext.Queryable<NewsEntity>().Where(c => c.Id == input.Id).First();
            var userEntity = DbContext.Queryable<UserEntity>().Where(c => c.Id == entity.Id).First();
            CheckEmpty(entity, "你选择的图文详情不存在");
            var replyList = GetReplyList(new List<long>() { entity.Id }, ReplyOfType.News, userId);
            return new NewsModel()
            {
                Id = entity.Id,
                Content = entity.Content,
                Summary = entity.Summary,
                Titie = entity.Titie,
                Url = entity.Url,
                UserId = entity.UserId,
                GoodNum = entity.GoodNum,
                ViewingNum = entity.ViewingNum,
                IsMyself = entity.UserId == userId,
                UserName = userEntity.UserName,
                UpdateTime = entity.UpdateTime,
                ReplyList = replyList


            };
        }


        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public void UpdateGoodNews(long userId, UpdateGoodModel input)
        {
            if (input != null && input.Id != 0)
            {

                var currentTime = DateTime.Now;
                var entity = DbContext.Queryable<UserAndNewsEntity>().Where(c => c.UserId == userId && c.NewsId == input.Id).First();
                if (entity == null)
                {
                    DbContext.Insertable(new UserAndNewsEntity()
                    {
                        UserId = userId,
                        NewsId = input.Id,
                        CreateTime = currentTime,
                        UpdateTime = currentTime
                    }).ExecuteCommand();
                }
                else
                {
                    entity.IsGood = input.IsGood;
                    entity.UpdateTime = currentTime;
                    DbContext.Updateable(entity).ExecuteCommand();
                }
            }
        }

        #endregion

        #region   回复
        /// <summary>
        /// 添加回复
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        public void AddReply(long userId, ReplyModel input)
        {
            var currentTime = DateTime.Now;
            CheckEmpty(input.Content, "请输入查询内容");
            if (input != null && input.ReplyId != 0)
            {
                var type = (ReplyOfType)input.ReplyId;
                switch (type)
                {
                    case ReplyOfType.Dynamic:
                        CheckExit(!DbContext.Queryable<DynamicEntity>().Any(c => c.Id == input.ReplyId), "回复内容不存在");
                        DbContext.Insertable(new ReplyAndDynamicEntity()
                        {
                            Context = input.Content,
                            DynamicId = input.ReplyId,
                            ReplyUserId = input.ReplyUserId,
                            UserId = userId,
                            CreateTime = currentTime,
                            UpdateTime = currentTime
                        }).ExecuteCommand();
                        break;
                    case ReplyOfType.News:
                        CheckExit(!DbContext.Queryable<NewsEntity>().Any(c => c.Id == input.ReplyId), "回复内容不存在");
                        DbContext.Insertable(new ReplyAndNewsEntity()
                        {
                            Context = input.Content,
                            NewsId = input.ReplyId,
                            ReplyUserId = input.ReplyUserId,
                            UserId = userId,
                            CreateTime = currentTime,
                            UpdateTime = currentTime

                        }).ExecuteCommand();
                        break;
                    case ReplyOfType.Photo:
                        CheckExit(!DbContext.Queryable<PhotoEntity>().Any(c => c.Id == input.ReplyId), "回复内容不存在");
                        DbContext.Insertable(new ReplyAndPhotoEntity()
                        {
                            Context = input.Content,
                            PhotoId = input.ReplyId,
                            ReplyUserId = input.ReplyUserId,
                            UserId = userId,
                            CreateTime = currentTime,
                            UpdateTime = currentTime

                        }).ExecuteCommand();
                        break;
                }
            }
        }


        /// <summary>
        /// 获取回复列表
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        public List<ReplyModel> GetReplyList(List<long> idList, ReplyOfType type, long userId)
        {
            var result = new List<ReplyModel>();
            switch (type)
            {
                case ReplyOfType.Dynamic:
                    result = DbContext.Queryable<ReplyAndDynamicEntity, UserEntity>((relpy, user) => new object[] {
                        JoinType.Left,relpy.UserId==user.Id
                    }).Where((relpy, user) => idList.Contains(relpy.DynamicId)).Select((relpy, user) => new ReplyModel()
                    {
                        Content = relpy.Context,
                        Id = relpy.Id,
                        ReplyId = relpy.DynamicId,
                        ReplyUserId = relpy.ReplyUserId,
                        UserId = relpy.UserId,
                        CreateTime = relpy.CreateTime,
                        UpdateTime = relpy.UpdateTime,
                        UserName = user.UserName,
                        NickName = user.NickName,
                        HeadUrl = user.HeadUrl,
                    }).ToList();
                    break;
                case ReplyOfType.News:
                    result = DbContext.Queryable<ReplyAndNewsEntity, UserEntity>((relpy, user) => new object[] {
                        JoinType.Left,relpy.UserId==user.Id
                    }).Where((relpy, user) => idList.Contains(relpy.NewsId)).Select((relpy, user) => new ReplyModel()
                    {
                        Content = relpy.Context,
                        Id = relpy.Id,
                        ReplyId = relpy.NewsId,
                        ReplyUserId = relpy.ReplyUserId,
                        UserId = relpy.UserId,
                        CreateTime = relpy.CreateTime,
                        UpdateTime = relpy.UpdateTime,
                        UserName = user.UserName,
                        NickName = user.NickName,
                        HeadUrl = user.HeadUrl,
                    }).ToList();
                    break;
                case ReplyOfType.Photo:
                    result = DbContext.Queryable<ReplyAndPhotoEntity, UserEntity>((relpy, user) => new object[] {
                        JoinType.Left,relpy.UserId==user.Id
                    }).Where((relpy, user) => idList.Contains(relpy.PhotoId)).Select((relpy, user) => new ReplyModel()
                    {
                        Content = relpy.Context,
                        Id = relpy.Id,
                        ReplyId = relpy.PhotoId,
                        ReplyUserId = relpy.ReplyUserId,
                        UserId = relpy.UserId,
                        CreateTime = relpy.CreateTime,
                        UpdateTime = relpy.UpdateTime,
                        UserName = user.UserName,
                        NickName = user.NickName,
                        HeadUrl = user.HeadUrl,
                    }).ToList();
                    break;
            }
            foreach (var item in result)
            {
                item.IsMyself = item.UserId == userId;
            }
            return result;
        }

        public PageReturnModel<PhotoModel> OutMain(long userId, GetPhotoModel input)
        {
            var result = new List<PhotoModel>();
            var total = 0;
            var entityList = DbContext.Queryable<PhotoEntity>()
                .WhereIF(input.IsMyself && userId == 0, c => c.UserId == userId).
                WhereIF(!string.IsNullOrEmpty(input.Like), c => c.Name.Contains(input.Like) || c.Detail.Contains(input.Like))
                .Select(c => new PhotoModel()
                {
                    Name = c.Name,
                    Url = c.Url,
                    Id = c.Id,
                    Detail = c.Detail,
                    UserId = c.UserId
                }).ToPageList(input.PageIndex, input.PageSize, ref total);
            var entityIdList = entityList.Select(c => c.Id).ToList();
            var IsGoodList = DbContext.Queryable<UserAndPhotoEntity>().Where(c => c.IsGood && c.UserId == userId && entityIdList.Contains(c.PhotoId)).Select(c => c.PhotoId).ToList();
            var replyList = GetReplyList(entityIdList, ReplyOfType.Photo, userId);
            foreach (var item in entityList)
            {
                item.IsGood = IsGoodList.Any(c => c == item.Id);
                item.IsMyself = item.UserId == userId;
                item.ReplyList = replyList.Where(c => c.Id == item.Id).OrderBy(c => c.CreateTime).ToList();
            }
            return new PageReturnModel<PhotoModel>() { TotalNum = total, DateList = entityList };
        }
        #endregion

    }
}
