using HuxingModel.Global;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingModel.Community
{
    public class GetDynamicModel : PageInfoModel
    {
        public bool IsMyself { get; set; }

        public long UserId { get; set; }
    }
}
