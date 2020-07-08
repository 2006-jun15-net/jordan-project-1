using HardWaxReborn.DAL.Entities;
using HardWaxReborn.Domain;
using System;
using System.Collections.Generic;

namespace HardWaxReborn.DAL
{
    public class CustomerRepository : ICustomerRepository<Customers>
    {
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customers> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customers GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
