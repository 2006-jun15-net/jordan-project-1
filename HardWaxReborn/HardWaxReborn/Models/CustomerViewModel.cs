using HardWaxReborn.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HardWaxReborn.Models
{
    public class CustomerViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        
        [DisplayName("Username")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        
        public List<OrderViewModel> OrderHistory { get; set; }
    }
}
