using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using BPR.AspNetCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BPR.AspNetCore.EF
{
    internal static class SoftDeleteQueryFilters
    {
        /// <summary>
        /// By applying this Query Filter, Rows that have been soft deleted will not be included in the query
        /// </summary>
        internal static void ApplySoftDeleteQueryFilters(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model
                .GetEntityTypes()
                .Where(eType => typeof(BaseEntity).IsAssignableFrom(eType.ClrType)))
            {
                entityType.AddSoftDeleteQueryFilter();
            }
        }

        private static void AddSoftDeleteQueryFilter(this IMutableEntityType entityData)
        {
            var methodToCall = typeof(SoftDeleteQueryFilters)
                .GetMethod(nameof(GetSoftDeleteFilter), BindingFlags.NonPublic | BindingFlags.Static)
                ?.MakeGenericMethod(entityData.ClrType);
            var filter = methodToCall?.Invoke(null, new object[] { });
            entityData.SetQueryFilter((LambdaExpression)filter);
        }

        private static LambdaExpression GetSoftDeleteFilter<TEntity>() where TEntity : BaseEntity
        {
            return (Expression<Func<TEntity, bool>>)(entity => !entity.IsDeleted);
        }
    }
}
