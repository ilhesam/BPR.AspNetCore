using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace BPR.AspNetCore.Repository
{
    public class Repository<TEntity, TContext> : BaseRepository<TEntity, Guid, TContext>, IRepository<TEntity>
        where TEntity : BaseEntity<Guid>
        where TContext : DbContext
    {
        public Repository(TContext database) : base(database)
        {
        }
    }
}