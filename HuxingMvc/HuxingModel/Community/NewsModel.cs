using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingModel.Community
{
    public class NewsModel
    {
        public long Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Titie { get; set; }


        /// <summary>
        /// 封面地址
        /// </summary>
        public string Url { get; set; }


        /// <summary>
        /// 摘要
        /// </summary>
        public string Summary { get; set; }


        /// <summary>
        /// 正文
        /// </summary>
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

        public bool IsMyself { get; set; }

        public string UserName { get; set; }
        public DateTime UpdateTime { get; set; }

        public List<ReplyModel> ReplyList { get; set; }
    }
}
