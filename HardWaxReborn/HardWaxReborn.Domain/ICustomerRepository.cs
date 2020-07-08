using System;
using System.Collections.Generic;
using System.Text;

namespace HardWaxReborn.Domain
{
    public interface ICustomerRepository<T> 
    {
         IEnumerable<T> GetAll();






    }
}
