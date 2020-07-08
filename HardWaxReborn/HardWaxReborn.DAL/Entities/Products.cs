using System;
using System.Collections.Generic;

namespace HardWaxReborn.DAL.Entities
{
    public partial class Products
    {
        public Products()
        {
            Inventory = new HashSet<Inventory>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
