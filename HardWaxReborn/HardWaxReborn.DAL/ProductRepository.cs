using HardWaxReborn.DAL.Entities;
using HardWaxReborn.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HardWaxReborn.DAL
{
    public class ProductRepository : IProductRepository
    {
        private HardWaxStoreContext _context;

        public ProductRepository(HardWaxStoreContext context)
        {
            _context = context;

        }
        public IEnumerable<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            List<Products> productEntities = _context.Products.ToList();
            foreach(var product in productEntities)
            {
                products.Add(new Product(product.Id, product.ProductName, (double)product.Price, product.Type));
            }
            return products;
        }

        public Product GetById(int Id)
        {
            var productEntity = _context.Products.Find(Id);
            var product = new Product(productEntity.Id, productEntity.ProductName, (double)productEntity.Price, productEntity.Type);
            return product;
        }
    }
}
