using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.EF.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BPR.AspNetCore.EF
{
    public abstract class BprDbContext : DbContext
    {
        // If this true, Rows that have been soft deleted will be included in the query
        // If this false, Rows that have been soft deleted will not be included in the query
        private readonly bool _showDeletedRows;

        protected BprDbContext(DbContextOptions options, bool showDeletedRows = true) : base(options)
        {
            _showDeletedRows = showDeletedRows;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (!_showDeletedRows)
            {
                // By applying this Query Filter, Rows that have been soft deleted will not be included in the query
                modelBuilder?.ApplySoftDeleteQueryFilters();
            }
        }

        // For perform the commands we need before save changes
        // For example, instead of removing Row from the table, Update the Soft Delete fields
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ChangeTracker.DetectChanges();

            // This method will be executed before saving changes
            BeforeSaveTriggers();

            // For performance reasons, to avoid calling DetectChanges() again.
            ChangeTracker.AutoDetectChangesEnabled = false;
            var result = base.SaveChanges(acceptAllChangesOnSuccess);

            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        private void BeforeSaveTriggers()
        {
            SetAuditProperties();
        }

        private void SetAuditProperties()
        {
            this.SetAuditableEntityOnBeforeSaveChanges();
        }
    }
}
