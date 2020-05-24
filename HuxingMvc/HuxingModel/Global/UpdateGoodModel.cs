using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingModel.Global
{
    public class UpdateGoodModel : EntityDto<long>
    {
        public bool IsGood { get; set; }
    }
}
