using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingModel.User
{
    public class UserModel : EntityDto<long?>
    {


        public string HeadUrl { get; set; }
        /// <summary>
        /// 用户名字
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }


        /// <summary>
        /// 昵称
        /// </summary>

        public string NickName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        public string Description { get; set; }

        public double Integral { get; set; }


        /// <summary>
        /// 性别
        /// </summary>
        public bool Six { get; set; }
        public string SixString { get; set; }

        public string UpdateTime { get; set; }

        public bool IsEnable { get; set; }
    }
}
