using HardWaxReborn.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HardWaxReborn.Models
{
    public class StoreViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        public Dictionary<Product, int> ProductCatalog { get; set; }
    }
}
