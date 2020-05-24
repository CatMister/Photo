using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingModel.Community
{
    public class DynamicModel
    {

        public long Id { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Context { get; set; }


        /// <summary>
        /// 地址
        /// </summary>

        public string Url { get; set; }



        public long UserId { get; set; }
        public string UserName { get; set; }

        public string HeadUrl { get; set; }

        /// <summary>
        /// 点赞数
        /// </summary>
        public long GoodNum { get; set; }



        /// <summary>
        /// 流量数
        /// </summary>
        public long ViewingNum { get; set; }

        public bool IsGood { get; set; }

        public bool IsMyself { get; set; }

        public List<ReplyModel> ReplyList { get; set; }


        public DateTime CreateTime { get; set; }
    }

}
