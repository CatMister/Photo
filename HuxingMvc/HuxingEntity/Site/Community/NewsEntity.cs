using HuxingEntity.BaseEntity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingEntity.Site
{

    /// <summary>
    /// 图文
    /// </summary>
    [SugarTable("news")]
    public class NewsEntity : BaseEntity<long>
    {
        /// <summary>
        /// 标题
        /// </summary>
        [SugarColumn(Length = 100)]
        public string Titie { get; set; }


        /// <summary>
        /// 封面地址
        /// </summary>
        [SugarColumn(Length = int.MaxValue)]
        public string Url { get; set; }


        /// <summary>
        /// 摘要
        /// </summary>
        [SugarColumn(Length = 500, IsNullable = true)]
        public string Summary { get; set; }


        /// <summary>
        /// 正文
        /// </summary>
        [SugarColumn(Length = int.MaxValue)]
        public string Content { get; set; }


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
