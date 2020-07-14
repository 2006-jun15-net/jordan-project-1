using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HardWaxReborn.Models
{
    public class CompositeViewModel
    {
        [DisplayName("Customer")]
        public CustomerViewModel Customer { get; set; }

        [DisplayName("Cart")]
        public ShoppingCartViewModel Cart { get; set; }

        [DisplayName("Order")]
        public OrderViewModel Order { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }

        public IEnumerable<StoreViewModel> Stores { get; set; }




    }
}
