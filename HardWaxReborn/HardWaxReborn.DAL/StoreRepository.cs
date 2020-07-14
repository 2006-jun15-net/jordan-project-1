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
            Store singleStore = new Store();
            foreach (var item in storeEntities)
            {
                singleStore.Id = item.Id;
                singleStore.Name = item.StoreName;
                try
                {
                    singleStore.Stock.Add(item.Inventory.Where(i => i.StoreId == singleStore.Id).Select(i => i.ProductId).ToList().FirstOrDefault(), item.Inventory.Select(i => i.Quantity).ToList().FirstOrDefault());


                }
                catch (NullReferenceException)
                {
                    
                    
                }
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
