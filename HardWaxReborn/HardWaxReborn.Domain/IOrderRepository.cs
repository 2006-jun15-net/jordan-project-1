﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HardWaxReborn.Domain
{
    public interface IOrderRepository<T>
    {
       

        

        void Create(Order order);
    }
}
