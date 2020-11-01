using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.Entity;

namespace BPR.AspNetCore.Service
{
    public interface IServiceStringKey<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto>
        : IBaseService<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto, string>
        where TEntity : BaseEntity<string>
        where TEntityAddDto : BaseAddDto
        where TEntityEditDto : BaseEditDto<string>
        where TEntityDto : BaseEntityDto<string>
        where TEntitiesDto : BaseEntitiesDto<TEntityDto>
    {
    }
}
