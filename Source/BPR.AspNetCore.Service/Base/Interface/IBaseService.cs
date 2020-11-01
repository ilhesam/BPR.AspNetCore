using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BPR.AspNetCore.Entity;
using BPR.AspNetCore.Repository;

namespace BPR.AspNetCore.Service
{
    public interface IBaseService<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto>
        where TEntity : BaseEntity
        where TEntityAddDto : BaseAddDto
        where TEntityEditDto : BaseEditDto
        where TEntityDto : BaseEntityDto
        where TEntitiesDto : BaseEntitiesDto<TEntityDto>
    {
        // Get Entities
        Task<BprOperationResult<TEntitiesDto>> GetAllAsync(bool tracking = false);
        BprOperationResult<IQueryable<TEntityDto>> GetAll(bool tracking = false);

        BprOperationResult<IQueryable<TEntityDto>> GetAll(Expression<Func<TEntity, bool>> expression,
            bool tracking = false);

        BprOperationResult<IQueryable<TEntityDto>> GetAllAsTracking();
        BprOperationResult<IQueryable<TEntityDto>> GetAllAsNoTracking();
        BprOperationResult<IQueryable<TEntityDto>> GetAllAsTracking(Expression<Func<TEntity, bool>> expression);
        BprOperationResult<IQueryable<TEntityDto>> GetAllAsNoTracking(Expression<Func<TEntity, bool>> expression);

        // Get Entity
        Task<BprOperationResult<TEntityDto>> GetOrNullAsync(Expression<Func<TEntity, bool>> expression,
            bool tracking = false);

        Task<BprOperationResult<TEntityDto>> GetOrNullAsTrackingAsync(Expression<Func<TEntity, bool>> expression);
        Task<BprOperationResult<TEntityDto>> GetOrNullAsNoTrackingAsync(Expression<Func<TEntity, bool>> expression);

        // Add Entity
        Task<BprOperationResult<TEntityDto>> AddAsync(TEntityAddDto addDto);

        // Add Entities
        Task<BprOperationResult> AddListAsync(IList<TEntityAddDto> list);

        // Update Entity
        BprOperationResult Update(TEntityEditDto editDto);

        // Update Entities
        BprOperationResult UpdateList(IList<TEntityEditDto> list);

        // Delete Entity
        Task<BprOperationResult<TEntityDto>> DeleteAsync(Expression<Func<TEntity, bool>> expression);

        // Delete Entities
        Task<BprOperationResult> DeleteListAsync(Expression<Func<TEntity, bool>> expression);

        // Check entity existence
        Task<BprOperationResult<bool>> IsExistsAsync(Expression<Func<TEntity, bool>> expression);

        // Save
        Task<BprOperationResult<int>> SaveChangesAsync();
    }

    public interface IBaseService<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto, TKey>
        : IBaseService<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto>
        where TEntity : BaseEntity<TKey>
        where TEntityAddDto : BaseAddDto
        where TEntityEditDto : BaseEditDto<TKey>
        where TEntityDto : BaseEntityDto<TKey>
        where TEntitiesDto : BaseEntitiesDto<TEntityDto>
    {
        // Get Entity
        Task<BprOperationResult<TEntityDto>> GetByIdAsync(TKey id, bool tracking = false);
        Task<BprOperationResult<TEntityDto>> GetByIdAsNoTrackingAsync(TKey id);
        Task<BprOperationResult<TEntityDto>> GetByIdAsTrackingAsync(TKey id);

        // Delete Entity
        Task<BprOperationResult<TEntityDto>> DeleteAsync(TKey id);

        // Delete Entities
        Task<BprOperationResult> DeleteListAsync(IList<TKey> ids);

        // Check entity existence
        Task<BprOperationResult<bool>> IsExistsAsync(TKey id);
    }
}