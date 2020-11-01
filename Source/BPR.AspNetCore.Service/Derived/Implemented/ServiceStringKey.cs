using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.Entity;
using BPR.AspNetCore.Repository;
using Microsoft.Extensions.Logging;

namespace BPR.AspNetCore.Service
{
    public abstract class ServiceStringKey<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto>
        : BaseService<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto, string>,
            IServiceStringKey<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto>
        where TEntity : BaseEntity<string>
        where TEntityAddDto : BaseAddDto
        where TEntityEditDto : BaseEditDto<string>
        where TEntityDto : BaseEntityDto<string>
        where TEntitiesDto : BaseEntitiesDto<TEntityDto>, new()
    {
        protected ServiceStringKey(IBaseRepository<TEntity> repository, ILogger<TEntity> logger) : base(repository, logger)
        {
        }
    }
}