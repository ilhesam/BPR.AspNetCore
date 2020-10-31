using System;
using System.Collections.Generic;
using System.Text;

namespace BPR.AspNetCore.Service
{
    public abstract class BaseEntityDto<TKey> : BaseEntityDto
    {
        public TKey Id { get; set; }
    }

    public abstract class BaseEntityDto
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
