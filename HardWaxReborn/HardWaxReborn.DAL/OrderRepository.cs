using HardWaxReborn.DAL.Entities;
using HardWaxReborn.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HardWaxReborn.DAL
{   /// <summary>
/// Repository responsible for handling all Access To Orders
/// </summary>
/// <remarks>
/// Responsible for displaying a customer's order history
/// </remarks>
    public class OrderRepository : IOrderRepository
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

        public List<OrderDetails> GetAllByCustomer(Customer customer)
        {
            var customerOrders = _context.Orders.Include(o => o.OrderDetails)
                    .ToList();
            List<OrderDetails> orderSummary = new List<OrderDetails>();
            foreach(var customerOrder in customerOrders)
            {
                orderSummary.Add(customerOrder.OrderDetails.Where(od => od.CustomerId == customer.Id).FirstOrDefault());
                
               
            }
            
                
            return orderSummary;
            
    
        }

        public IEnumerable<Order> GetAllByStore(Store store)
        {
            throw new NotImplementedException();
        }


    }
}
