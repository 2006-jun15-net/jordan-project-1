using HardWaxReborn.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HardWaxReborn.Models
{
    public class CustomerViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        public List<Order> OrderHistory { get; set; }
    }
}
