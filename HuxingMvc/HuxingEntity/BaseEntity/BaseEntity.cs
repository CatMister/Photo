using System;
using System.Collections.Generic;
using System.Text;

namespace HuxingEntity.BaseEntity
{
    public class BaseEntity<T> : Entity<T>
    {
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
