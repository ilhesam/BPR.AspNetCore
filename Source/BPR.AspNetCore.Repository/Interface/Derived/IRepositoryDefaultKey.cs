using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.Entity;

namespace BPR.AspNetCore.Repository
{
    public interface IRepository<TEntity> : IBaseRepository<TEntity, Guid>
        where TEntity : BaseEntity<Guid>
    {
    }
}