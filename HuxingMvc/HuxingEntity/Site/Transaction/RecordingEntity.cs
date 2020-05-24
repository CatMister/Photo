using HuxingEntity.BaseEntity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingEntity.Site
{

    /// <summary>
    /// 流水表
    /// </summary>
    [SugarTable("recording")]
    public class RecordingEntity : BaseEntity<long>
    {
        public long UserId { get; set; }

        public long Amount { get; set; }

        public long Balance { get; set; }


        public long OrderId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [SugarColumn(Length = 1000, IsNullable = true)]
        public string Detail { get; set; }


    }
}
