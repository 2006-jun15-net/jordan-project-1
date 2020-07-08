using System;
using System.Collections.Generic;
using System.Text;

namespace HardWaxReborn.Domain
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
         IEnumerable<TEntity> Get();




    }
}
