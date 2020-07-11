using System.Collections.Generic;

namespace HardWaxReborn.Domain
{
    public interface ICustomerRepository 
    {
        IEnumerable<Customer> GetAll();

        Customer GetById (int Id);

        void Insert(Customer customer);

        void Update(Customer customer);

        void Delete(int Id);


        






    }
}
