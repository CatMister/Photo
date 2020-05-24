using HuxingEntity.BaseEntity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingEntity.Site
{

    /// <summary>
    /// 用户图片点赞关联表
    /// </summary>
    [SugarTable("user_photo")]
    public class UserAndPhotoEntity : BaseEntity<long>
    {
        public long UserId { get; set; }

        public long PhotoId { get; set; }


        public bool IsGood { get; set; }

    }
}
