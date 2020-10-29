using System;
using System.Collections.Generic;
using System.Text;

namespace BPR.AspNetCore.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public bool IsDeleted { get; private set; }

        public void Create() => CreatedAt = DateTime.Now;
        public void Update() => UpdatedAt = DateTime.Now;
        public void Delete()
        {
            if (DeletedAt == null)
            {
                DeletedAt = DateTime.Now;
            }

            IsDeleted = true;
        }
    }

    public class BaseEntity<TKey> : BaseEntity
    {
        public BaseEntity(TKey id)
        {
            Id = id;
        }

        public TKey Id { get; private set; }
    }
}
