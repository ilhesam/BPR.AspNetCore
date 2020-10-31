using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.Entity;

namespace BPR.AspNetCore.Service.Base
{
    public interface IBprMapper<out TEntity, out TEntityAddDto, out TEntityEditDto, out TEntityDto, out TEntitiesDto>
        where TEntity : BaseEntity
        where TEntityAddDto : BaseAddDto
        where TEntityEditDto : BaseEditDto
        where TEntityDto : BaseEntityDto
        where TEntitiesDto : BaseEntitiesDto<TEntityDto>
    {
        TEntity MapToEntity(object obj);
        TEntityAddDto MapToAddDto(object obj);
        TEntityEditDto MapToEditDto(object obj);
        TEntityDto MapToEntityDto(object obj);
        TEntitiesDto MapToEntitiesDto(object obj);
    }
}