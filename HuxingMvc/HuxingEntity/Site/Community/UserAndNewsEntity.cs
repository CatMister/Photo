using HuxingEntity.BaseEntity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingEntity.Site
{
  
    /// <summary>
    /// 用户点赞图文关联表
    /// </summary>
    [SugarTable("user_news")]
    public class UserAndNewsEntity : BaseEntity<long>
    {
        public long UserId { get; set; }

        public long NewsId { get; set; }


        public bool IsGood { get; set; }

    }
}
