using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingModel.Community
{
    public class ReplyModel
    {
        public string Content { get; set; }

        public long ReplyId { get; set; }

        public long Id { get; set; }

        public long ReplyUserId { get; set; }



        public long UserId { get; set; }

        public string UserName { get; set; }
        public string  NickName  { get; set; }


        public string HeadUrl { get; set; }

        public bool IsMyself { get; set; }


        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
