using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.EF;
using BPR.AspNetCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BPR.AspNetCore.Repository.Implemented.Derived
{
    public class RepositoryIntegerKey<TEntity, TContext> : BaseRepository<TEntity, int, TContext>, IRepositoryIntegerKey<TEntity>
        where TEntity : BaseEntity<int>
        where TContext : BprDbContext
    {
        public RepositoryIntegerKey(TContext database, ILogger<TEntity> logger) : base(database, logger)
        {
        }
    }
}
