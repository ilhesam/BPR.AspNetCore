using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace BPR.AspNetCore.Repository
{
    public class RepositoryStringKey<TEntity, TContext> : BaseRepository<TEntity, string, TContext>, IRepositoryStringKey<TEntity>
        where TEntity : BaseEntity<string>
        where TContext : DbContext
    {
        public RepositoryStringKey(TContext database) : base(database)
        {
        }
    }
}
