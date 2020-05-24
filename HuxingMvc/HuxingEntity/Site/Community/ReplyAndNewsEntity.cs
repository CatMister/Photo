﻿using HuxingEntity.BaseEntity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingEntity.Site
{
    /// <summary>
    /// 图文回复
    /// </summary>
    [SugarTable("reply_news")]
    public class ReplyAndNewsEntity : BaseEntity<long>
    {
        [SugarColumn(Length = 1000)]
        public string Context { get; set; }

        public long UserId { get; set; }

        public long NewsId { get; set; }


        public long ReplyUserId { get; set; }
    }
}
