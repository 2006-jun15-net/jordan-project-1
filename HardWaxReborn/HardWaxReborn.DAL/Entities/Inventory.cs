using System;
using System.Collections.Generic;

namespace HardWaxReborn.DAL.Entities
{
    public partial class Inventory
    {
        public Inventory()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }

        public virtual Products Product { get; set; }
        public virtual Stores Store { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
