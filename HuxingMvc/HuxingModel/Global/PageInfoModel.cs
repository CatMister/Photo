using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingModel.Global
{
    public class PageInfoModel : EntityDto<long?>
    {

        public PageInfoModel()
        {
            PageIndex = 1;
            PageSize = 12;
        }
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
