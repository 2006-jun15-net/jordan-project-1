using System.Collections.Generic;

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
