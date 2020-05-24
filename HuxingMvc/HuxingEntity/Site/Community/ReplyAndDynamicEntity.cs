using HuxingEntity.BaseEntity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingEntity.Site
{

    /// <summary>
    /// 动态回复
    /// </summary>
    [SugarTable("reply_dynamic")]
    public class ReplyAndDynamicEntity : BaseEntity<long>
    {
        [SugarColumn(Length = 1000)]
        public string Context { get; set; }

        public long UserId { get; set; }

        public long DynamicId { get; set; }
        
        public long ReplyUserId { get; set; }

    }
}
