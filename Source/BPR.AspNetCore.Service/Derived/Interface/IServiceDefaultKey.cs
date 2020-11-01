using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.Entity;

namespace BPR.AspNetCore.Service
{
    public interface IService<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto>
        : IBaseService<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto, Guid>
        where TEntity : BaseEntity<Guid>
        where TEntityAddDto : BaseAddDto
        where TEntityEditDto : BaseEditDto<Guid>
        where TEntityDto : BaseEntityDto<Guid>
        where TEntitiesDto : BaseEntitiesDto<TEntityDto>
    {
    }
}
