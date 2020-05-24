using HuxingEntity.BaseEntity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingEntity.Site
{
    /// <summary>
    /// 举报
    /// </summary>
    [SugarTable("communityReport")]
    public class CommunityReportEntity : BaseEntity<long>
    {
        
        public long UserId { get; set; }

        [SugarColumn(Length =1000,IsNullable =false)]
        public string Detail { get; set; }

        public long ReportType { get; set; }

        public long CommunityId { get; set; }

        public bool IsDeal { get; set; }

    }
}
