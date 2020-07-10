using System;
using System.Collections.Generic;
using System.Text;

namespace HardWaxReborn.Domain
{
    public interface IStoreRepository
    {
        void Update(Store store);

        IEnumerable<Store> GetAll();
    }
}
