using System;
using System.Collections.Generic;
using System.Text;

namespace BPR.AspNetCore.Service
{
    public abstract class StringKeyEntitiesDto<TStringKeyEntityDto> : BaseEntitiesDto<TStringKeyEntityDto>
        where TStringKeyEntityDto : StringKeyEntityDto
    {
    }
}