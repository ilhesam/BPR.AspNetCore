using System;
using System.Collections.Generic;
using System.Text;

namespace BPR.AspNetCore.Entity
{
    public class Entity : BaseEntity<Guid>
    {
        public Entity(Guid id) : base(id)
        {

        }

        public Entity() : base(Guid.NewGuid())
        {

        }
    }
}
