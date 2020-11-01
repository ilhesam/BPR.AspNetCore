using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.Entity;

namespace BPR.AspNetCore.Service
{
    public interface IServiceIntegerKey<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto>
        : IBaseService<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto, int>
        where TEntity : BaseEntity<int>
        where TEntityAddDto : BaseAddDto
        where TEntityEditDto : BaseEditDto<int>
        where TEntityDto : BaseEntityDto<int>
        where TEntitiesDto : BaseEntitiesDto<TEntityDto>
    {
    }
}
