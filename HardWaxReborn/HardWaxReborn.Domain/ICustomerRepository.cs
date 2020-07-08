using HardWaxReborn.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardWaxReborn.Domain
{
    public interface ICustomerRepository<T> 
    {
        IEnumerable<T> GetAll();

        T GetById (int Id);

        void Insert(Customer customer);

        void Update(Customer customer);

        void Delete(int Id);


        






    }
}
