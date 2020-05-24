using HuxingEntity;
using HuxingEntity.Site;
using HuxingModel.User;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingService.Login
{
    public class LoginService : PhotoClient, ILoginService
    {
        public LoginService()
        {
        }


        /// <summary>
        /// 登陆用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public long Login(UserModel input)
        {

            input.UserName = CheckEmpty(input.UserName, "账号不能为空");
            input.PassWord = CheckEmpty(input.PassWord, "密码不能为空");
            var entity = DbContext.Queryable<UserEntity>().First(c => c.UserName == input.UserName && c.PassWord == input.PassWord);
            if (entity == null)
            {
                throw new Exception("账号密码错误");
            }
            return entity.Id;

        }



        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="input"></param>
        public long AddUser(UserModel input)
        {

            var currentTime = DateTime.Now;
            CheckUser(input);
            input.PassWord = CheckEmpty(input.PassWord, "请输入密码");
            input.UserName = CheckEmpty(input.UserName, "请输入用户名");
            CheckExit(DbContext.Queryable<UserEntity>().Where(c => c.UserName == input.UserName).Any(), "用户名已经存在");
            var entity = new UserEntity()
            {
                NickName = input.NickName,
                UserName = input.UserName,
                PassWord = input.PassWord,
                HeadUrl = input.HeadUrl,
                Phone = input.Phone,
                Six = input.Six,
                CreateTime = currentTime,
                UpdateTime = currentTime
            };
            return DbContext.Insertable(entity).ExecuteReturnBigIdentity();
        }

        private void CheckUser(UserModel input)
        {
            //input.PassWord = CheckEmpty(input.PassWord, "请输入密码");

            input.Phone = CheckEmpty(input.Phone, "请输入电话");
            input.NickName = CheckEmpty(input.NickName, "请输入昵称");
        }


        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="input"></param>
        public void UpdateUser(UserModel input)
        {
            CheckEmpty(input.Id, "更新用户不存在");
            input.Phone = CheckEmpty(input.Phone, "请输入电话");
            var entity = DbContext.Queryable<UserEntity>().First(c => c.Id == input.Id);
            CheckEmpty(entity, "用户不存在");
            CheckExit(DbContext.Queryable<UserEntity>().Where(c => c.UserName == input.UserName && c.Id != input.Id).Any(), "用户名已经存在");
            CheckUser(input);
            entity.NickName = input.NickName;
            entity.HeadUrl = input.HeadUrl;
            entity.Description = input.Description;
            entity.Phone = input.Phone;
            entity.Six = input.Six;
            entity.UpdateTime = DateTime.Now;
            DbContext.Updateable(entity).ExecuteCommand();
        }


        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserModel GetUser(long userId)
        {
            var entity = DbContext.Queryable<UserEntity>().First(c => c.Id == userId);
            CheckEmpty(entity, "用户信息异常，用户不存在");
            return new UserModel()
            {
                HeadUrl = entity.HeadUrl,
                NickName = entity.NickName,
                Phone = entity.Phone,
                Integral = entity.Integral,
                Six = entity.Six,
                SixString = entity.Six ? "男" : "女",
                Description = entity.Description
            };
        }


        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="input"></param>
        public void UpdateUserPassWord(UserModel input)
        {
            CheckEmpty(input.Id, "更新用户不存在");
            var entity = DbContext.Queryable<UserEntity>().First(c => c.Id == input.Id);
            CheckEmpty(entity, "用户不存在");
            entity.PassWord = input.PassWord;
            entity.UpdateTime = DateTime.Now;
            DbContext.Updateable(entity).ExecuteCommand();
        }


        /// <summary>
        /// 添加关注用户接口
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="attentionUserId"></param>
        /// <param name="IsAttention"></param>

        public void UpdateUserAttention(long userId, long attentionUserId, bool IsAttention)
        {
            var entity = DbContext.Queryable<UserAndAttentionEntity>().First(c => c.Id == userId && c.AttentionUserId == attentionUserId);
            if (IsAttention)
            {
                if (entity == null)
                {
                    entity = new UserAndAttentionEntity()
                    {
                        UserId = entity.UserId,
                        AttentionUserId = entity.AttentionUserId,
                        CreateTime = DateTime.Now,
                        UpdateTime = DateTime.Now
                    };
                    DbContext.Insertable(entity).ExecuteCommand();
                }
            }
            else
            {
                if (entity != null)
                {
                    DbContext.Deleteable(entity).ExecuteCommand();
                }

            }
        }

        /// <summary>
        ///获取用户列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="Is"></param>
        /// <returns></returns>
        public List<UserModel> GetUserLsit(long userId, bool IsAttention)
        {


            var entityList = DbContext.Queryable<UserEntity>().WhereIF(IsAttention, c => SqlFunc.Subqueryable<UserAndAttentionEntity>().Where(t => t.UserId == userId && c.Id == t.AttentionUserId).Any())
                .Select(c => new UserModel()
                {
                    Id = c.Id,
                    HeadUrl = c.HeadUrl,
                    NickName = c.NickName,
                    Integral = c.Integral,
                    SixString = c.Six ? "男" : "女",
                    Description = c.Description,
                    IsEnable = c.IsEnable
                }).ToList();
            return entityList;
        }

        public void UpdateUserEnable(long id, bool IsEnable)
        {
            var entity = DbContext.Queryable<UserEntity>().First(c => c.Id == id);
            CheckEmpty(entity, "用户不存在");
            entity.IsEnable = IsEnable;
            entity.UpdateTime = DateTime.Now;
            DbContext.Updateable(entity).ExecuteCommand();
        }
    }
}
