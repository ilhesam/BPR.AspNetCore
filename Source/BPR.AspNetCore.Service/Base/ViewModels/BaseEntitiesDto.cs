using System;
using System.Collections.Generic;
using System.Text;

namespace BPR.AspNetCore.Service
{
    public abstract class BaseEntitiesDto<TEntityDto>
        where TEntityDto : BaseEntityDto
    {
        protected BaseEntitiesDto()
        {

        }

        protected BaseEntitiesDto(IList<TEntityDto> entities)
        {
            Entities = entities;
        }

        public IList<TEntityDto> Entities { get; set; }
    }
}