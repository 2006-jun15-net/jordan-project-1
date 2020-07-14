using HardWaxReborn.DAL.Entities;
using HardWaxReborn.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
        public void Create(Order order, ShoppingCart cart)
        {
            var orderEntity = new Orders
            {
                OrderTime = DateTime.Now,
                Total = (decimal)order.OrderTotal
            };

            _context.Orders.Add(orderEntity);
            List<OrderDetails> orderDetailsEntity = new List <OrderDetails>();
            List<Inventory> inventoryEntities = new List<Inventory>();
            foreach (var item in cart.Stores)
            {

                inventoryEntities.Add(_context.Inventory.Where(i => i.StoreId == item.Id).FirstOrDefault());
            }
            foreach (var item in inventoryEntities)
            {
                item.Quantity -= cart.ProductId_Quantity[item.ProductId];
                orderDetailsEntity.Add(new OrderDetails
                {
                    ProductQuantiy = item.Quantity,
                    InventoryId = item.Id,
                    CustomerId = cart.Customer.Id

                }) ;
                _context.Entry(item).State = EntityState.Modified;

            }
            foreach (var item in orderDetailsEntity)
            {
                _context.Entry(item).State = EntityState.Modified;
            }
           
             


            

            
            

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
