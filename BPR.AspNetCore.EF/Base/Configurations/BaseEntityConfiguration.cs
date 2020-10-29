using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BPR.AspNetCore.EF
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder?.Property(e => e.CreatedAt)
                .IsRequired();

            builder?.Property(e => e.UpdatedAt)
                .IsRequired();

            builder?.Property(e => e.IsDeleted)
                .IsRequired();
        }
    }

    public abstract class BaseEntityConfiguration<TEntity, TKey> : BaseEntityConfiguration<TEntity>
        where TEntity : BaseEntity<TKey>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder?.HasKey(e => e.Id);

            base.Configure(builder);
        }
    }
}