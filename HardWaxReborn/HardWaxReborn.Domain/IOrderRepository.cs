using System;
using System.Collections.Generic;
using System.Text;

namespace HardWaxReborn.Domain
{
    public interface IOrderRepository
    {
       

        

        void Create(Order order, ShoppingCart cart);
    }
}
