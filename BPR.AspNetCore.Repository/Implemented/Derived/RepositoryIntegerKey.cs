using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace BPR.AspNetCore.Repository.Implemented.Derived
{
    public class RepositoryIntegerKey<TEntity, TContext> : BaseRepository<TEntity, int, TContext>, IRepositoryIntegerKey<TEntity>
        where TEntity : BaseEntity<int>
        where TContext : DbContext
    {
        public RepositoryIntegerKey(TContext database) : base(database)
        {
        }
    }
}
