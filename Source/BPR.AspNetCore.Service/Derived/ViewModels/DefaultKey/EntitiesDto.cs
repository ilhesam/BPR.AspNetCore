using System;
using System.Collections.Generic;
using System.Text;

namespace BPR.AspNetCore.Service
{
    public abstract class EntitiesDto<TEntityDto> : BaseEntitiesDto<TEntityDto>
        where TEntityDto : EntityDto
    {
    }
}