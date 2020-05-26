using HuxingModel;
using HuxingModel.Community;
using HuxingModel.Global;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingService.Community
{

    public interface IPhotoService
    {

        #region  图片
        /// <summary>
        /// -添加图片
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="file"></param>
        /// <param name="input"></param>
        void AddPhoto(long userId, IFormFile file, PhotoModel input, string url);

        /// <summary>
        /// 修改图片
        /// </summary>
        /// <param name="input"></param>
        void UpdatePhoto(long UserId, PhotoModel input);

        /// <summary>
        /// 获取图片列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        PageReturnModel<PhotoModel> GetPhoto(long userId, GetPhotoModel input);

        PageReturnModel<PhotoModel> OutMain(long userId, GetPhotoModel input);

        /// <summary>
        /// 获取图片详情
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        PhotoModel GetPhotoDetail(long userId, GetPhotoModel input);


        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        void DeletePhoto(long userId, EntityDto<long> input);


        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        void UpdateGoodPhoto(long userId, UpdateGoodModel input);
        #endregion

        #region 动态
        /// <summary>
        /// 获取动态列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        PageReturnModel<DynamicModel> GetDynamicList(long userId, GetDynamicModel input);


        /// <summary>
        /// 添加动态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        void AddDynaimic(long userId, DynamicModel input);


        /// <summary>
        /// 删除动态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        void DeleteDynainic(long userId, EntityDto<long> input);


        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        void UpdateGoodDynainic(long userId, UpdateGoodModel input);
        #endregion

        #region  图文
        /// <summary>
        /// 获取图文列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        PageReturnModel<NewsModel> GetNewsList(long userId, GetNewsModel input);


        /// <summary>
        /// 删除图文
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        void DeleteNews(long userId, EntityDto<long> input);


        /// <summary>
        /// 添加图文
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        void AddNews(long userId, NewsModel input);


        /// <summary>
        /// 获取图文详情
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        NewsModel GetNewsDetail(long userId, EntityDto<long> input);


        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        void UpdateGoodNews(long userId, UpdateGoodModel input);
        #endregion

        #region   回复
        /// <summary>
        /// 添加回复
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        void AddReply(long userId, ReplyModel input);
        #endregion
    }
}
