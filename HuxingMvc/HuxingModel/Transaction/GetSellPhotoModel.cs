﻿using HuxingModel.Global;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingModel.Transaction
{
    public class GetSellPhotoModel : PageInfoModel
    {
        public bool IsMyself { get; set; }

        public long UserId { get; set; }
    }
}
