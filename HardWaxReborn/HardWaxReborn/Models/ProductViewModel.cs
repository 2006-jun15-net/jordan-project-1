using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HardWaxReborn.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }

        public double Price { get; set; }

        [DisplayName("Description")]
        public string Type { get; set; }
    }
}
