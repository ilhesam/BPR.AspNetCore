using System;
using System.Collections.Generic;
using System.Text;

namespace BPR.AspNetCore.Service
{
    public abstract class BaseEditDto<TKey> : BaseEditDto
    {
        public TKey Id { get; set; }
    }

    public abstract class BaseEditDto
    {

    }
}
