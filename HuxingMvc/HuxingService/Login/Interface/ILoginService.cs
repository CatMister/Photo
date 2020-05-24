using HuxingModel.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingService.Login
{
    public interface ILoginService
    {
        /// <summary>
        /// 登陆用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        long Login(UserModel input);

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="input"></param>
        long AddUser(UserModel input);


        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="input"></param>
        void UpdateUser(UserModel input);

        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserModel GetUser(long userId);

        void UpdateUserAttention(long userId, long attentionUserId, bool IsAttention);


        /// <summary>
        ///获取用户列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="Is"></param>
        /// <returns></returns>
        List<UserModel> GetUserLsit(long userId, bool IsAttention);

        void UpdateUserEnable(long id, bool IsEnable);
    }
}
