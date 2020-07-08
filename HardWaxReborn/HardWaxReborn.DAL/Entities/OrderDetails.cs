using System;
using System.Collections.Generic;

namespace HardWaxReborn.DAL.Entities
{
    public partial class OrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantiy { get; set; }
        public int InventoryId { get; set; }
        public int CustomerId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
