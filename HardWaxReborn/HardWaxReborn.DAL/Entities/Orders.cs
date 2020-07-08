using System;
using System.Collections.Generic;

namespace HardWaxReborn.DAL.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal Total { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
