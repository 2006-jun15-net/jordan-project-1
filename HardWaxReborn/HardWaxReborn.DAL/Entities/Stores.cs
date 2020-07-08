using System;
using System.Collections.Generic;

namespace HardWaxReborn.DAL.Entities
{
    public partial class Stores
    {
        public Stores()
        {
            Inventory = new HashSet<Inventory>();
        }

        public int Id { get; set; }
        public string StoreName { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
