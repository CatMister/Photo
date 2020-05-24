using HuxingEntity.BaseEntity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingEntity.Site
{
    /// <summary>
    /// 动态
    /// </summary>
    [SugarTable("dynamic")]
    public class DynamicEntity : BaseEntity<long>
    {
        /// <summary>
        /// 内容
        /// </summary>
        [SugarColumn(Length =1000,IsNullable =true)]
        public string Context { get; set; }


        /// <summary>
        /// 地址
        /// </summary>

        [SugarColumn(Length = 1000, IsNullable = true)]
        public string Url { get; set; }


        
        public long UserId { get; set; }


        /// <summary>
        /// 点赞数
        /// </summary>
        public long GoodNum { get; set; }



        /// <summary>
        /// 流量数
        /// </summary>
        public long ViewingNum { get; set; }
    }
}
