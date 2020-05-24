using HuxingEntity.BaseEntity;
using HuxingModel;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HuxingEntity.Site
{
    [SugarTable("User")]
    public class UserEntity : BaseEntity<long>
    {

        /// <summary>
        /// 用户名字
        /// </summary>
        [SugarColumn(Length = 50)]
        public string UserName { get; set; }


        /// <summary>
        /// 密码
        /// </summary>
        [SugarColumn(Length = 100)]
        public string PassWord { get; set; }


        /// <summary>
        /// 昵称
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string NickName { get; set; }


        /// <summary>
        /// 昵称
        /// </summary>
        [SugarColumn(Length = 500, IsNullable = true)]
        public string HeadUrl { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        [SugarColumn(Length = int.MaxValue, IsNullable = true)]
        public string Description { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public bool Six { get; set; }


        public double Integral { get; set; }



        public bool IsEnable { get; set; }



    }
}
