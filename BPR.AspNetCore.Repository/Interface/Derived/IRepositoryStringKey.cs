using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.Entity;

namespace BPR.AspNetCore.Repository
{
    public interface IRepositoryStringKey<TEntity> : IBaseRepository<TEntity, string>
        where TEntity : BaseEntity<string>
    {
    }
}