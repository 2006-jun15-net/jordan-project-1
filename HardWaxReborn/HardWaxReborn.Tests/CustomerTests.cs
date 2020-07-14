using HardWaxReborn.Domain;
using System;
using Xunit;
using Xunit.Sdk;

namespace HardWaxReborn.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void CustomerShouldBeAbleToBeCreatedWithoutDatabase()
        {
            Customer customer = new Customer(1, "evan", "tanner", "etanner");
            Assert.NotNull(customer);


        }
        [Fact]
        public void CustomerShouldAllowChangeInProperty()
        {

        }
    }
}
