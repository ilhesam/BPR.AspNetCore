using System;
using System.Collections.Generic;
using System.Text;

namespace BPR.AspNetCore.Service
{
    public abstract class IntegerKeyEntitiesDto<TIntegerKeyEntityDto> : BaseEntitiesDto<TIntegerKeyEntityDto>
        where TIntegerKeyEntityDto : IntegerKeyEntityDto
    {
    }
}