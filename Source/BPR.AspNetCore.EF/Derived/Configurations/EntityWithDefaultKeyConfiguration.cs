using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.Entity;

namespace BPR.AspNetCore.EF
{
    public abstract class EntityConfiguration<TEntity> : BaseEntityConfiguration<TEntity, Guid>
        where TEntity : BaseEntity<Guid>
    {
    }
}