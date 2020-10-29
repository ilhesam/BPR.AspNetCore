using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BPR.AspNetCore.Entity;

namespace BPR.AspNetCore.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        // Get Entities
        BprOperationResult<IQueryable<TEntity>> GetAll(bool tracking = false);

        BprOperationResult<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression,
            bool tracking = false);

        BprOperationResult<IQueryable<TEntity>> GetAllAsTracking();
        BprOperationResult<IQueryable<TEntity>> GetAllAsNoTracking();
        BprOperationResult<IQueryable<TEntity>> GetAllAsTracking(Expression<Func<TEntity, bool>> expression);
        BprOperationResult<IQueryable<TEntity>> GetAllAsNoTracking(Expression<Func<TEntity, bool>> expression);

        // Get Entity
        Task<BprOperationResult<TEntity>> GetOrNullAsync(Expression<Func<TEntity, bool>> expression,
            bool tracking = false);

        Task<BprOperationResult<TEntity>> GetOrNullAsNoTrackingAsync(Expression<Func<TEntity, bool>> expression);
        Task<BprOperationResult<TEntity>> GetOrNullAsTrackingAsync(Expression<Func<TEntity, bool>> expression);

        // Add Entity
        Task<BprOperationResult<TEntity>> AddAsync(TEntity entity);

        // Add Entities
        Task<BprOperationResult> AddListAsync(IList<TEntity> entities);

        // Update Entity
        BprOperationResult Update(TEntity entity);

        // Update Entities
        BprOperationResult UpdateList(IList<TEntity> entities);

        // Delete Entity
        BprOperationResult<TEntity> Delete(TEntity entity);
        Task<BprOperationResult<TEntity>> DeleteAsync(Expression<Func<TEntity, bool>> expression);

        // Delete Entities
        BprOperationResult DeleteList(IList<TEntity> entities);
        Task<BprOperationResult> DeleteListAsync(Expression<Func<TEntity, bool>> expression);

        // Check entity existence
        Task<BprOperationResult<bool>> IsExistsAsync(Expression<Func<TEntity, bool>> expression);

        // Save
        Task<BprOperationResult<int>> SaveChangesAsync();
    }

    public interface IBaseRepository<TEntity, TKey> : IBaseRepository<TEntity>
        where TEntity : BaseEntity<TKey>
    {
        // Get Entity
        Task<BprOperationResult<TEntity>> GetByIdAsync(TKey id, bool tracking = false);
        Task<BprOperationResult<TEntity>> GetByIdAsNoTrackingAsync(TKey id);
        Task<BprOperationResult<TEntity>> GetByIdAsTrackingAsync(TKey id);

        // Delete Entity
        Task<BprOperationResult<TEntity>> DeleteAsync(TKey id);

        // Delete Entities
        Task<BprOperationResult> DeleteListAsync(IList<TKey> ids);

        // Check entity existence
        Task<BprOperationResult<bool>> IsExistsAsync(TKey id);
    }
}