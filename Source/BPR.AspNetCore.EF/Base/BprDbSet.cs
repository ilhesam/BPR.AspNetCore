using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace BPR.AspNetCore.EF
{
    public class BprDbSet<TEntity> : DbSet<TEntity>
        where TEntity : BaseEntity
    {
    }
}