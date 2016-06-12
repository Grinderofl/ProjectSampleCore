using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSampleCore.Infrastructure.Domain.Base
{
    public abstract class Entity
    {
        public virtual DateTime LastModified { get; set; } = DateTime.Now;
    }

    public abstract class Entity<TPk> : Entity
    {
        public virtual TPk Id { get; set; }
    }
}
