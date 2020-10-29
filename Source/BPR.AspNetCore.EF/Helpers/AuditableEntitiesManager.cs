using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace BPR.AspNetCore.EF.Helpers
{
    public static class AuditableEntitiesManager
    {
        public static void SetAuditableEntityOnBeforeSaveChanges<TContext>(this TContext context)
            where TContext : DbContext
        {
            var now = DateTime.Now;

            foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        break;

                    case EntityState.Modified:
                        break;

                    case EntityState.Deleted:
                        {
                            // For soft-deletes to work with the original `Remove` method.
                            entry.State = EntityState.Unchanged; 

                            entry.Entity.Delete();
                            break;
                        }
                }
            }
        }
    }
}