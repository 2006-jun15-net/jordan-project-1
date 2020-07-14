using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HardWaxReborn.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public double Price { get; set; }

        [DisplayName("Description")]
        [DataType(DataType.Text)]
        public string Type { get; set; }
    }
}
