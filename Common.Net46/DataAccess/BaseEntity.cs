using System;

namespace Common.Net46.DataAccess
{
    public abstract class BaseEntity
    {
        public virtual DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual string CreatedBy { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
    }
}
