using HardWaxReborn.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardWaxReborn.Models
{
    public class StoreViewModel
    {
        public Dictionary<Product, int> ProductCatalog { get; set; }
    }
}
