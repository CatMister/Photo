using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingModel.Community
{
    public class PhotoModel
    {
        public long Id { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public string Detail { get; set; }

        public long UserId { get; set; }

        public bool IsMyself { get; set; }
        public bool IsGood { get; set; }

        public List<ReplyModel> ReplyList { get; set; }

    }
}
