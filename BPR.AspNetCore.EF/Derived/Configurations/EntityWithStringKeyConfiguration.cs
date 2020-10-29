using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.Entity;

namespace BPR.AspNetCore.EF
{
    public abstract class EntityStringKeyConfiguration<TEntity> : BaseEntityConfiguration<TEntity, string>
        where TEntity : BaseEntity<string>
    {
    }
}