using System;
using System.Collections.Generic;
using System.Text;

namespace BPR.AspNetCore.Entity
{
    public class EntityIntegerKey : BaseEntity<int>
    {
        public EntityIntegerKey() : base(0)
        {

        }

        public EntityIntegerKey(int id) : base(id)
        {

        }
    }
}
