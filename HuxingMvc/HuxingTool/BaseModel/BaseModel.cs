using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingTool.BaseModel
{



    /// <summary>
    /// 基础数据类型
    /// </summary>
    public class BaseModel
    {
        public DateTime CreateTime { get; set; } = DateTime.Now;

        public DateTime? LastUpdateTime { get; set; }

    }


}
