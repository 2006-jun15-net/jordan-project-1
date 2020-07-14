using System.Collections.Generic;

namespace HardWaxReborn.Domain
{
    public interface ICustomerRepository 
    {


        void Insert(Customer customer);

        void Update(Customer customer);

        void Delete(int Id);


        






    }
}
