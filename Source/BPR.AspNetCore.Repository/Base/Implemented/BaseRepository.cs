﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BPR.AspNetCore.EF;
using BPR.AspNetCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BPR.AspNetCore.Repository
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TContext : BprDbContext
        where TEntity : BaseEntity
    {
        protected readonly TContext Database;
        protected readonly BprDbSet<TEntity> Table;
        protected readonly ILogger<TEntity> Logger;

        protected BaseRepository(TContext database, ILogger<TEntity> logger)
        {
            Database = database;
            Table = Database.Set<TEntity>() as BprDbSet<TEntity>;
            Logger = logger;
        }

        public virtual BprOperationResult<IQueryable<TEntity>> GetAll(bool tracking = false)
        {
            try
            {
                var result = tracking ? GetAllAsTracking() : GetAllAsNoTracking();
                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<IQueryable<TEntity>>.Fail(e);
            }
        }

        public virtual BprOperationResult<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression,
            bool tracking = false)
        {
            try
            {
                var result = tracking ? GetAllAsTracking(expression) : GetAllAsNoTracking(expression);
                return result;
            }
            catch (Exception e)
            {
                return BprOperationResult<IQueryable<TEntity>>.Fail(e);
            }
        }

        public virtual BprOperationResult<IQueryable<TEntity>> GetAllAsTracking()
        {
            try
            {
                var result = Table.AsTracking();
                return BprOperationResult<IQueryable<TEntity>>.Success(result);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<IQueryable<TEntity>>.Fail(e);
            }
        }

        public virtual BprOperationResult<IQueryable<TEntity>> GetAllAsNoTracking()
        {
            try
            {
                var result = Table.AsNoTracking();
                return BprOperationResult<IQueryable<TEntity>>.Success(result);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<IQueryable<TEntity>>.Fail(e);
            }
        }

        public virtual BprOperationResult<IQueryable<TEntity>> GetAllAsTracking(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var result = Table.Where(expression).AsTracking();
                return BprOperationResult<IQueryable<TEntity>>.Success(result);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<IQueryable<TEntity>>.Fail(e);
            }
        }

        public virtual BprOperationResult<IQueryable<TEntity>> GetAllAsNoTracking(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var result = Table.Where(expression).AsNoTracking();
                return BprOperationResult<IQueryable<TEntity>>.Success(result);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<IQueryable<TEntity>>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<TEntity>> GetOrNullAsync(Expression<Func<TEntity, bool>> expression,
            bool tracking = false)
        {
            try
            {
                var result = tracking
                    ? await GetOrNullAsTrackingAsync(expression)
                    : await GetOrNullAsNoTrackingAsync(expression);
                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntity>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<TEntity>> GetOrNullAsNoTrackingAsync(
            Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entities = GetAllAsNoTracking();

                if (!entities.IsSucceeded)
                {
                    return BprOperationResult<TEntity>.Fail(entities.Exception);
                }

                var result = await entities.Data.SingleOrDefaultAsync(expression);
                return BprOperationResult<TEntity>.Success(result);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntity>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<TEntity>> GetOrNullAsTrackingAsync(
            Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entities = GetAllAsTracking();

                if (!entities.IsSucceeded)
                {
                    return BprOperationResult<TEntity>.Fail(entities.Exception);
                }

                var result = await entities.Data.SingleOrDefaultAsync(expression);
                return BprOperationResult<TEntity>.Success(result);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntity>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<TEntity>> AddAsync(TEntity entity)
        {
            try
            {
                var result = await Table.AddAsync(entity);
                return BprOperationResult<TEntity>.Success(result.Entity);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntity>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult> AddListAsync(IList<TEntity> entities)
        {
            try
            {
                await Table.AddRangeAsync(entities);
                return BprOperationResult.Success();
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult.Fail(e);
            }
        }

        public virtual BprOperationResult Update(TEntity entity)
        {
            try
            {
                var result = Table.Update(entity);
                return BprOperationResult<TEntity>.Success(result.Entity);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntity>.Fail(e);
            }
        }

        public virtual BprOperationResult UpdateList(IList<TEntity> entities)
        {
            try
            {
                Table.UpdateRange(entities);
                return BprOperationResult.Success();
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult.Fail(e);
            }
        }

        public virtual BprOperationResult<TEntity> Delete(TEntity entity)
        {
            try
            {
                var result = Table.Remove(entity);
                return BprOperationResult<TEntity>.Success(result.Entity);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntity>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<TEntity>> DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entity = await GetOrNullAsync(expression);

                if (!entity.IsSucceeded)
                {
                    return BprOperationResult<TEntity>.Fail(entity.Exception);
                }

                var result = Table.Remove(entity.Data);
                return BprOperationResult<TEntity>.Success(result.Entity);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntity>.Fail(e);
            }
        }

        public virtual BprOperationResult DeleteList(IList<TEntity> entities)
        {
            try
            {
                Table.RemoveRange(entities);
                return BprOperationResult.Success();
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult> DeleteListAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entities = GetAll(expression);

                if (!entities.IsSucceeded)
                {
                    return BprOperationResult.Fail(entities.Exception);
                }

                Table.RemoveRange(await entities.Data.ToListAsync());
                return BprOperationResult.Success();
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<bool>> IsExistsAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var result = await Table.AnyAsync(expression);
                return BprOperationResult<bool>.Success(result);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<bool>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<int>> SaveChangesAsync()
        {
            try
            {
                var result = await Database.SaveChangesAsync();
                return BprOperationResult<int>.Success(result);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<int>.Fail(e);
            }
        }
    }

    public abstract class BaseRepository<TEntity, TKey, TContext> : BaseRepository<TEntity, TContext>,
        IBaseRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TContext : BprDbContext
    {
        protected BaseRepository(TContext database, ILogger<TEntity> logger) : base(database, logger)
        {
        }

        public virtual async Task<BprOperationResult<TEntity>> GetByIdAsync(TKey id, bool tracking = false)
        {
            try
            {
                var result = await GetOrNullAsync(e => e.Id.Equals(id), tracking);
                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntity>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<TEntity>> GetByIdAsNoTrackingAsync(TKey id)
        {
            try
            {
                var result = await GetByIdAsync(id, false);
                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntity>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<TEntity>> GetByIdAsTrackingAsync(TKey id)
        {
            try
            {
                var result = await GetByIdAsync(id, true);
                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntity>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<TEntity>> DeleteAsync(TKey id)
        {
            try
            {
                var result = await DeleteAsync(e => e.Id.Equals(id));
                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntity>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult> DeleteListAsync(IList<TKey> ids)
        {
            try
            {
                var result = await DeleteListAsync(e => ids.Contains(e.Id));
                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<bool>> IsExistsAsync(TKey id)
        {
            try
            {
                var result = await IsExistsAsync(e => e.Id.Equals(id));
                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<bool>.Fail(e);
            }
        }
    }
}