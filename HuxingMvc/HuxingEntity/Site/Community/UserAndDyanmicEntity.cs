using HuxingEntity.BaseEntity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingEntity.Site
{


    /// <summary>
    /// 用户动态关联表
    /// </summary>
    [SugarTable("user_dynamic")]
    public class UserAndDyanmicEntity : BaseEntity<long>
    {
        public long UserId { get; set; }

        public long DyanmicId { get; set; }


        public bool IsGood { get; set; }

    }
}
