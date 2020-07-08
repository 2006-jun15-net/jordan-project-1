using System;
using System.Collections.Generic;

namespace HardWaxReborn.DAL.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
