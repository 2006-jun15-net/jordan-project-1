using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardWaxReborn.Models
{
    public class ShoppingCartViewModel
    {
        public Dictionary<int, int> ProductId_Quantity { get; set; }

        public List<StoreViewModel> Stores { get; set; }

        public CustomerViewModel Customer { get; set; }
    }
}
