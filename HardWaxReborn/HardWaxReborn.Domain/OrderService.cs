using System;
using System.Collections.Generic;
using System.Text;

namespace HardWaxReborn.Domain
{
    public class OrderService
    {
        private readonly IProductRepository productRepository;

        public IProductRepository ProductRepository
        {
            get
            {
                return productRepository;
            }
        }

        public OrderService(IProductRepository prepo)
        {
            productRepository = prepo;

        }
        public Order PlaceOrder(ShoppingCart cart)
        {
            double orderTotal = 0.00;
            foreach (KeyValuePair<int,int> item in cart.ProductId_Quantity)
            {
                orderTotal += (productRepository.GetById(item.Key).Price * item.Value);
                
            }
            Order order = new Order(70, orderTotal);
            return order;
        }
    }
}
