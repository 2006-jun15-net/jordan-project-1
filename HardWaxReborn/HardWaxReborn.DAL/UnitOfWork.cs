using HardWaxReborn.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardWaxReborn.DAL
{
    public class UnitOfWork : IDisposable
    {
        private HardWaxStoreContext _context;
        private CustomerRepository customerRepository;
        private OrderRepository orderRepository;
        private StoreRepository storeRepository;
        private ProductRepository productRepository;

        public UnitOfWork(CustomerRepository crepo, OrderRepository orepo, StoreRepository srepo, ProductRepository prepo, HardWaxStoreContext context)
        {
            customerRepository = crepo;
            orderRepository = orepo;
            storeRepository = srepo;
            productRepository = prepo;
            _context = context;

            
        }

        public CustomerRepository CustomerRepository
        {
            get
            {
                return customerRepository;
            }
        }

        public OrderRepository OrderRepository
        {
            get
            {
                return orderRepository;
            }
        }

        public StoreRepository StoreRepository
        {
            get
            {
                return storeRepository;
            }
        }

        public ProductRepository ProductRepository
        {
            get
            {
                return productRepository;
            }
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
