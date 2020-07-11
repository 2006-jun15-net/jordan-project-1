using System;
using System.Collections.Generic;
using System.Text;

namespace HardWaxReborn.Domain
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        Product GetById(int Id);

       
        

        
    }
}
