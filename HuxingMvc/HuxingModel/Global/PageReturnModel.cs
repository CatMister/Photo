using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingModel
{
    public class PageReturnModel<T>
    {
        public List<T> DateList { get; set; }


        public long TotalNum { get; set; }

    }
}
