using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.Entity;
using BPR.AspNetCore.Repository;
using Microsoft.Extensions.Logging;

namespace BPR.AspNetCore.Service
{
    public abstract class ServiceIntegerKey<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto>
        : BaseService<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto, int>,
            IServiceIntegerKey<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto>
        where TEntity : BaseEntity<int>
        where TEntityAddDto : BaseAddDto
        where TEntityEditDto : BaseEditDto<int>
        where TEntityDto : BaseEntityDto<int>
        where TEntitiesDto : BaseEntitiesDto<TEntityDto>, new()
    {
        protected ServiceIntegerKey(IRepositoryIntegerKey<TEntity> repository, ILogger<TEntity> logger) : base(repository, logger)
        {
        }
    }
}