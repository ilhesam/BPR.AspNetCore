using System;
using System.Collections.Generic;
using System.Text;

namespace BPR.AspNetCore.Entity
{
    public class EntityStringKey : BaseEntity<string>
    {
        public EntityStringKey() : base(Guid.NewGuid().ToString())
        {

        }

        public EntityStringKey(string id) : base(id)
        {

        }
    }
}
