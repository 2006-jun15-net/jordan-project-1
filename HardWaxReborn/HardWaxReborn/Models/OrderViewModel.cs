using HardWaxReborn.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardWaxReborn.Models
{
    public class OrderViewModel
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public DateTime OrderTime { get; set; }
    }
}
