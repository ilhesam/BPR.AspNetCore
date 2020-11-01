using System;
using System.Collections.Generic;
using System.Text;
using BPR.AspNetCore.Entity;
using BPR.AspNetCore.Repository;
using Microsoft.Extensions.Logging;

namespace BPR.AspNetCore.Service
{
    public abstract class Service<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto>
        : BaseService<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto, Guid>,
            IService<TEntity, TEntityAddDto, TEntityEditDto, TEntityDto, TEntitiesDto>
        where TEntity : BaseEntity<Guid>
        where TEntityAddDto : BaseAddDto
        where TEntityEditDto : BaseEditDto<Guid>
        where TEntityDto : BaseEntityDto<Guid>
        where TEntitiesDto : BaseEntitiesDto<TEntityDto>, new()
    {
        protected Service(IRepository<TEntity> repository, ILogger<TEntity> logger) : base(repository, logger)
        {
        }
    }
}