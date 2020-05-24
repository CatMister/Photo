using HuxingEntity.BaseEntity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingEntity.Site
{

    [SugarTable("user_attention")]
    public class UserAndAttentionEntity:BaseEntity<long>
    {
        public long UserId { get; set; }

        public long AttentionUserId { get; set; }

        public bool IsDisable { get; set; }
    }
}
