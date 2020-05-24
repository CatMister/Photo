using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingEntity.BaseEntity
{
    public class Entity<T>
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public virtual T Id { get; set; }
    }
}
