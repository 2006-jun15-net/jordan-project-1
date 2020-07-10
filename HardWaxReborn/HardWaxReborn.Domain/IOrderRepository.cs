using System;
using System.Collections.Generic;
using System.Text;

namespace HardWaxReborn.Domain
{
    public interface IOrderRepository<T>
    {
        IEnumerable<T> GetAllByStore(Store store);

        OrderSummary GetAllByCustomer(Customer customer);

        void Create(Order order);
    }
}
