﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingModel.Transaction
{
    public class SellPhotoModel
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long AtlasId { get; set; }


     
        /// <summary>
        /// 是否上架
        /// </summary>
        public bool IsEnable { get; set; }


        /// <summary>
        /// 本地地址
        /// </summary>
        public string SiteUrl { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 展示地址
        /// </summary>
        public string ShowUrl { get; set; }


        /// <summary>
        /// 展示本地地址
        /// </summary>
        public string ShowSiteUrl { get; set; }


        public long Price { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Titile { get; set; }


        /// <summary>
        /// 详情
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// 是否展示
        /// </summary>
        public bool IsShow { get; set; }


        public bool IsSell { get; set; }
    }
}
