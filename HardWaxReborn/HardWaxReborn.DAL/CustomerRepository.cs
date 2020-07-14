using HardWaxReborn.DAL.Entities;
using HardWaxReborn.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HardWaxReborn.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly HardWaxStoreContext _context;
        public CustomerRepository(HardWaxStoreContext context)
        {
            _context = context;
        }

        public void Delete(int Id)
        {
            var customerEntity = _context.Customers.Find(Id);
            _context.Customers.Remove(customerEntity);
        }

        public void Insert(Customer customer)
        {
            var customerEntity = new Customers();
            customerEntity.FirstName = customer.FirstName;
            customerEntity.LastName = customer.LastName;
            customerEntity.Username = customer.UserName;
            _context.Customers.Add(customerEntity);
        }

        public void Update(Customer customer)
        {
            
            var customerEntity = new Customers();
            customerEntity.Id = customer.Id;
            customerEntity.FirstName = customer.FirstName;
            customerEntity.LastName = customer.LastName;
            customerEntity.Username = customer.UserName;
            _context.Entry(customerEntity).State = EntityState.Modified;
        }

        public IEnumerable<Customer> GetAll()
        {
           var customerEntities =  _context.Customers.ToList();
            List<Customer> customerDomains = new List<Customer>();
            foreach(var item in customerEntities)
            {
                customerDomains.Add(new Customer(item.Id, item.FirstName, item.LastName, item.Username));

            }
            foreach(var item in customerDomains)
            {
                var orderEntity = _context.OrderDetails.Where(od => od.CustomerId == item.Id).Select(od => od.Order).FirstOrDefault();
                if (orderEntity != null)
                {
                    var orderDomain = new Order(orderEntity.Id, (double)orderEntity.Total);
                    orderDomain.Placed = orderEntity.OrderTime;

                    item.OrderHistory.Add(orderDomain);
                }
            }
            
            return customerDomains;
        }



        public Customer GetById(int Id)
        {
            var customerEntity = _context.Customers.Find(Id);
            return new Customer(customerEntity.Id,customerEntity.FirstName, customerEntity.LastName, customerEntity.Username);
        }

 
    }
}
