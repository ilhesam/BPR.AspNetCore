using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.Entity;

namespace BPR.AspNetCore.EF
{
    public abstract class EntityIntegerKeyConfiguration<TEntity> : BaseEntityConfiguration<TEntity, int>
        where TEntity : BaseEntity<int>
    {
    }
}