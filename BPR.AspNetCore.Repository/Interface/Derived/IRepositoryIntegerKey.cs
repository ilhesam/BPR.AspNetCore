using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.Entity;

namespace BPR.AspNetCore.Repository
{
    public interface IRepositoryIntegerKey<TEntity> : IBaseRepository<TEntity, int>
        where TEntity : BaseEntity<int>
    {
    }
}