using HardWaxReborn.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HardWaxReborn.Tests
{
    public class ShoppingCartTests
    {
        [Fact]
        public void ShoppingCartShouldHoldStores()
        {
            ShoppingCart cart = new ShoppingCart();
            cart.Stores.Add(new Store());
            Assert.Empty(cart.Stores);
        }

        [Fact]
        public void ShoppingCartShouldInstantiate()
        {
            ShoppingCart cart = new ShoppingCart();
            Assert.NotNull(cart);


        }
    }
    

}
