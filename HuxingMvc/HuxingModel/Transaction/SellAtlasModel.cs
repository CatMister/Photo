using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingModel.Transaction
{
    public class SellAtlasModel
    {

        public long Id { get; set; }
        public long UserId { get; set; }


        public bool IsEnable { get; set; }

        /// <summary>
        /// 图集本地地址
        /// </summary>
        public string SiteUrl { get; set; }


        /// <summary>
        /// 图集封面地址
        /// </summary>
        public string ShowUrl { get; set; }

        /// <summary>
        /// 图集封面地址
        /// </summary>
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
