using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BPR.AspNetCore.Entity;

namespace BPR.AspNetCore.Service
{
    public interface IBprMapper<TEntity, TEntityAddDto, TEntityEditDto, out TEntityDto, out TEntitiesDto>
        where TEntity : BaseEntity
        where TEntityAddDto : BaseAddDto
        where TEntityEditDto : BaseEditDto
        where TEntityDto : BaseEntityDto
        where TEntitiesDto : BaseEntitiesDto<TEntityDto>
    {
        TEntity MapToEntity(object obj);
        IList<TEntity> MapToEntities(IList<object> obj);
        TEntityAddDto MapToAddDto(object obj);
        TEntityEditDto MapToEditDto(object obj);
        TEntityDto MapToEntityDto(object obj);
        TEntitiesDto MapToEntitiesDto(object obj);

        TEntity MapAddDtoToEntity(TEntityAddDto addDto);
        IList<TEntity> MapAddDtosToEntities(IList<TEntityAddDto> addDtos);

        TEntity MapEditDtoToEntity(TEntityEditDto editDto);
        IList<TEntity> MapEditDtosToEntities(IList<TEntityEditDto> editDtos);

        TEntityDto MapEntityToEntityDto(TEntity entity);
        IQueryable<TEntityDto> MapEntitiesToEntityDtos(IQueryable<TEntity> entities);
    }
}