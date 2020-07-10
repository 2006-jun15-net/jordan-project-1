using HardWaxReborn.DAL.Entities;
using HardWaxReborn.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HardWaxReborn.DAL
{
    class OrderRepository : IOrderRepository<Order>
    {
        private readonly HardWaxStoreContext _context;

        public OrderRepository(HardWaxStoreContext context)
        {
            _context = context;
        }
        public void Create(Order order)
        {
            var orderEntity = new Orders
            {
                OrderTime = DateTime.Now,
                Total = (decimal)order.OrderTotal
            };

            _context.Orders.Add(orderEntity);
            order.Id = orderEntity.Id;

        }

        public OrderSummary GetAllByCustomer(Customer customer)
        {
            var customerOrders = _context.Orders.Include(o => o.OrderDetails)
                    .ToList();
            List<Order> orderhist = new List<Order>();
            OrderSummary orderSummary = new OrderSummary();
            foreach(var customerOrder in customerOrders)
            {
               orderSummary.Orders.Add((Order)customerOrder.OrderDetails.Where(od => od.CustomerId == customer.Id));
                
               
            }
            
                
            return orderSummary;
            
    
        }

        public IEnumerable<Order> GetAllByStore(Store store)
        {
            throw new NotImplementedException();
        }
    }
}
