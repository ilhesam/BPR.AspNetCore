using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BPR.AspNetCore.Entity;
using BPR.AspNetCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BPR.AspNetCore.Service
{
    public abstract class BaseService<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto>
        : IBaseService<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto>
        where TEntity : BaseEntity
        where TEntityAddDto : BaseAddDto
        where TEntityEditDto : BaseEditDto
        where TEntityDto : BaseEntityDto
        where TEntitiesDto : BaseEntitiesDto<TEntityDto>, new()
    {
        protected readonly IBaseRepository<TEntity> Repository;
        protected readonly ILogger<TEntity> Logger;
        protected readonly IBprMapper<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto> Mapper;

        protected BaseService(IBaseRepository<TEntity> repository, ILogger<TEntity> logger)
        {
            Repository = repository;
            Logger = logger;
        }

        public virtual async Task<BprOperationResult<TEntityDto>> AddAsync(TEntityAddDto addDto)
        {
            try
            {
                var entity = Mapper.MapAddDtoToEntity(addDto);
                var result = await Repository.AddAsync(entity);

                if (!result.IsSucceeded)
                {
                    return BprOperationResult<TEntityDto>.Fail(result.Exception);
                }

                var entityDto = Mapper.MapEntityToEntityDto(result.Data);
                return BprOperationResult<TEntityDto>.Success(entityDto);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntityDto>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult> AddListAsync(IList<TEntityAddDto> list)
        {
            try
            {
                var entities = Mapper.MapAddDtosToEntities(list);
                var result = await Repository.AddListAsync(entities);

                if (!result.IsSucceeded)
                {
                    return BprOperationResult.Fail(result.Exception);
                }

                return BprOperationResult.Success();
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<TEntityDto>> DeleteAsync(
            Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var result = await Repository.DeleteAsync(expression);

                if (!result.IsSucceeded)
                {
                    return BprOperationResult<TEntityDto>.Fail(result.Exception);
                }

                var entityDto = Mapper.MapEntityToEntityDto(result.Data);
                return BprOperationResult<TEntityDto>.Success(entityDto);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntityDto>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult> DeleteListAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var result = await Repository.DeleteListAsync(expression);

                if (!result.IsSucceeded)
                {
                    return BprOperationResult.Fail(result.Exception);
                }

                return BprOperationResult.Success();
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult.Fail(e);
            }
        }

        public virtual BprOperationResult<IQueryable<TEntityDto>> GetAll(bool tracking = false)
        {
            try
            {
                var result = tracking ? GetAllAsTracking() : GetAllAsNoTracking();

                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<IQueryable<TEntityDto>>.Fail(e);
            }
        }

        public virtual BprOperationResult<IQueryable<TEntityDto>> GetAll(Expression<Func<TEntity, bool>> expression,
            bool tracking = false)
        {
            try
            {
                var result = tracking ? GetAllAsTracking(expression) : GetAllAsNoTracking(expression);

                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<IQueryable<TEntityDto>>.Fail(e);
            }
        }

        public virtual BprOperationResult<IQueryable<TEntityDto>> GetAllAsNoTracking(
            Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var result = Repository.GetAll(expression, false);

                if (!result.IsSucceeded)
                {
                    return BprOperationResult<IQueryable<TEntityDto>>.Fail(result.Exception);
                }

                var entityDtos = Mapper.MapEntitiesToEntityDtos(result.Data);
                return BprOperationResult<IQueryable<TEntityDto>>.Success(entityDtos);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<IQueryable<TEntityDto>>.Fail(e);
            }
        }

        public BprOperationResult<IQueryable<TEntityDto>> GetAllAsNoTracking()
        {
            try
            {
                var result = Repository.GetAll(false);

                if (!result.IsSucceeded)
                {
                    return BprOperationResult<IQueryable<TEntityDto>>.Fail(result.Exception);
                }

                var entityDtos = Mapper.MapEntitiesToEntityDtos(result.Data);
                return BprOperationResult<IQueryable<TEntityDto>>.Success(entityDtos);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<IQueryable<TEntityDto>>.Fail(e);
            }
        }

        public BprOperationResult<IQueryable<TEntityDto>> GetAllAsTracking()
        {
            try
            {
                var result = Repository.GetAll(true);

                if (!result.IsSucceeded)
                {
                    return BprOperationResult<IQueryable<TEntityDto>>.Fail(result.Exception);
                }

                var entityDtos = Mapper.MapEntitiesToEntityDtos(result.Data);
                return BprOperationResult<IQueryable<TEntityDto>>.Success(entityDtos);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<IQueryable<TEntityDto>>.Fail(e);
            }
        }

        public BprOperationResult<IQueryable<TEntityDto>> GetAllAsTracking(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var result = Repository.GetAll(expression, true);

                if (!result.IsSucceeded)
                {
                    return BprOperationResult<IQueryable<TEntityDto>>.Fail(result.Exception);
                }

                var entityDtos = Mapper.MapEntitiesToEntityDtos(result.Data);
                return BprOperationResult<IQueryable<TEntityDto>>.Success(entityDtos);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<IQueryable<TEntityDto>>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<TEntitiesDto>> GetAllAsync(bool tracking = false)
        {
            try
            {
                var result = GetAll(tracking);

                if (!result.IsSucceeded)
                {
                    return BprOperationResult<TEntitiesDto>.Fail(result.Exception);
                }

                var entitiesDto = new TEntitiesDto
                {
                    Entities = await result.Data.ToListAsync()
                };

                return BprOperationResult<TEntitiesDto>.Success(entitiesDto);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntitiesDto>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<TEntityDto>> GetOrNullAsNoTrackingAsync(
            Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var result = await Repository.GetOrNullAsync(expression, false);

                if (!result.IsSucceeded)
                {
                    return BprOperationResult<TEntityDto>.Fail(result.Exception);
                }

                var entityDto = Mapper.MapEntityToEntityDto(result.Data);
                return BprOperationResult<TEntityDto>.Success(entityDto);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntityDto>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<TEntityDto>> GetOrNullAsTrackingAsync(
            Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var result = await Repository.GetOrNullAsync(expression, true);

                if (!result.IsSucceeded)
                {
                    return BprOperationResult<TEntityDto>.Fail(result.Exception);
                }

                var entityDto = Mapper.MapEntityToEntityDto(result.Data);
                return BprOperationResult<TEntityDto>.Success(entityDto);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntityDto>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<TEntityDto>> GetOrNullAsync(
            Expression<Func<TEntity, bool>> expression,
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
                return BprOperationResult<TEntityDto>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<bool>> IsExistsAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var result = await Repository.IsExistsAsync(expression);
                return result;
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
                var result = await Repository.SaveChangesAsync();
                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<int>.Fail(e);
            }
        }

        public virtual BprOperationResult Update(TEntityEditDto editDto)
        {
            try
            {
                var entity = Mapper.MapEditDtoToEntity(editDto);
                var result = Repository.Update(entity);

                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntityDto>.Fail(e);
            }
        }

        public virtual BprOperationResult UpdateList(IList<TEntityEditDto> list)
        {
            try
            {
                var entities = Mapper.MapEditDtosToEntities(list);
                var result = Repository.UpdateList(entities);

                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntityDto>.Fail(e);
            }
        }
    }

    public abstract class BaseService<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto, TKey>
        : BaseService<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto>,
            IBaseService<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto, TKey>
        where TEntity : BaseEntity<TKey>
        where TEntityAddDto : BaseAddDto
        where TEntityEditDto : BaseEditDto<TKey>
        where TEntityDto : BaseEntityDto<TKey>
        where TEntitiesDto : BaseEntitiesDto<TEntityDto>, new()
    {
        protected BaseService(IBaseRepository<TEntity> repository, ILogger<TEntity> logger) : base(repository, logger)
        {
        }

        public virtual async Task<BprOperationResult<TEntityDto>> GetByIdAsync(TKey id, bool tracking = false)
        {
            try
            {
                var result = tracking ? await GetByIdAsTrackingAsync(id) : await GetByIdAsNoTrackingAsync(id);
                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntityDto>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<TEntityDto>> GetByIdAsNoTrackingAsync(TKey id)
        {
            try
            {
                var result = await GetOrNullAsync(e => e.Id.Equals(id), false);
                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntityDto>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<TEntityDto>> GetByIdAsTrackingAsync(TKey id)
        {
            try
            {
                var result = await GetOrNullAsync(e => e.Id.Equals(id), true);
                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntityDto>.Fail(e);
            }
        }

        public virtual async Task<BprOperationResult<TEntityDto>> DeleteAsync(TKey id)
        {
            try
            {
                var result = await DeleteAsync(e => e.Id.Equals(id));
                return result;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BprOperationResult<TEntityDto>.Fail(e);
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