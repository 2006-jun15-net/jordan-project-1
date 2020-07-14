using HardWaxReborn.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HardWaxReborn.Models
{
    public class OrderViewModel
    {
        [DisplayName("Product")]
        public Product Product { get; set; }

        [Range (1,50)]
        [DisplayName("Quantiy")]
        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderTime { get; set; }
    }
}
