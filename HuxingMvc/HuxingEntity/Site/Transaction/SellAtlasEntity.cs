using HuxingEntity.BaseEntity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingEntity.Site
{
    /// <summary>
    /// 图集列表
    /// </summary>
    [SugarTable("sellatlas")]
    public class SellAtlasEntity : BaseEntity<long>
    {

        public long UserId { get; set; }


        public bool IsEnable { get; set; }

        /// <summary>
        /// 图集本地地址
        /// </summary>
        [SugarColumn(Length = 1000, IsNullable = true)]
        public string SiteUrl { get; set; }


        /// <summary>
        /// 图集封面地址
        /// </summary>
        [SugarColumn(Length = 1000, IsNullable = false)]
        public string ShowUrl { get; set; }

        /// <summary>
        /// 图集封面地址
        /// </summary>
        [SugarColumn(Length = 1000, IsNullable = true)]
        public string ShowSiteUrl { get; set; }


        /// <summary>
        /// 标题
        /// </summary>
        public string Titile { get; set; }

        /// <summary>
        /// 详情
        /// </summary>
        public string Detail { get; set; }


        public long Price { get; set; }

        public bool IsSell { get; set; }
    }
}
