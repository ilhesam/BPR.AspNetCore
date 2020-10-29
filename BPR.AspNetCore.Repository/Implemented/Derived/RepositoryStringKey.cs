using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.EF;
using BPR.AspNetCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BPR.AspNetCore.Repository
{
    public class RepositoryStringKey<TEntity, TContext> : BaseRepository<TEntity, string, TContext>, IRepositoryStringKey<TEntity>
        where TEntity : BaseEntity<string>
        where TContext : BprDbContext
    {
        public RepositoryStringKey(TContext database, ILogger<TEntity> logger) : base(database, logger)
        {
        }
    }
}
