using HardWaxReborn.DAL.Entities;
using HardWaxReborn.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HardWaxReborn.DAL
{
    public class StoreRepository : IStoreRepository
    {
        private readonly HardWaxStoreContext _context;

        public StoreRepository(HardWaxStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<Store> GetAll()
        {
            var storeEntities = _context.Stores
                .Include(s => s.Inventory)
                .ToList();
            var storeDomains = new List<Store>();
            foreach(var item in storeEntities)
            {
                Store singleStore = new Store(item.Id,item.StoreName);
                singleStore.Stock.Add(item.Inventory.Where(i => i.StoreId == singleStore.Id).FirstOrDefault().ProductId, item.Inventory.FirstOrDefault().Quantity) ;
                storeDomains.Add(singleStore);
                    
            }
            return storeDomains;
        }

        public void Update(Store store)
        {
            var storeEntity = new Stores();
            storeEntity.Id = store.Id;
            storeEntity.StoreName = store.Name;
            _context.Entry(storeEntity).State = EntityState.Modified;

        }
    }
}
