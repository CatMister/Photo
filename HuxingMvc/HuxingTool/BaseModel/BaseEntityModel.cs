using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingTool.BaseModel
{
    public class BaseEntityModel<T> : BaseModel where T : struct
    {

        [SugarColumn(IsPrimaryKey = true)]
        public T Id { get; set; }
        

    }
}
