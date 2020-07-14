using System;
using System.Collections.Generic;
using System.Text;

namespace HardWaxReborn.Domain
{
    public class ShoppingCart
    {
        public Dictionary<int, int> ProductId_Quantity { get; set; }

        public List<Store> Stores { get; set; }

        public Customer Customer { get; set; }

    }
}
