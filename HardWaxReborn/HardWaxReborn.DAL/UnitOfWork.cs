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

        public CustomerRepository CustomerRepository
        {
            get
            {
                if (customerRepository == null)
                {
                    customerRepository = new CustomerRepository(_context);
                }
                return customerRepository;
            }
        }

        public OrderRepository OrderRepository
        {
            get
            {
                if(orderRepository == null)
                {
                    orderRepository = new OrderRepository(_context);
                }
                return orderRepository;
            }
        }

        public StoreRepository StoreRepository
        {
            get
            {
                if (storeRepository == null)
                {
                    storeRepository = new StoreRepository(_context);
                }
                return storeRepository;
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
