using HardWaxReborn.DAL.Entities;
using HardWaxReborn.Domain;
using Microsoft.EntityFrameworkCore;
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

        IEnumerable<Customer> GetAll()
        {
           var customerEntities =  _context.Customers.ToList();
            List<Customer> customers = (List<Customer>)customerEntities.Select(e => new Customer(e.FirstName, e.LastName, e.Username));
            return customers;
        }

        IEnumerable<Customer> ICustomerRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        Customer GetById(int Id)
        {
            var customerEntity = _context.Customers.Find(Id);
            return new Customer(customerEntity.FirstName, customerEntity.LastName, customerEntity.Username);
        }

        Customer ICustomerRepository.GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
