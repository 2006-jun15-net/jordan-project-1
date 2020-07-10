using System;

namespace HardWaxReborn.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Placed { get; set; }

        public double OrderTotal { get; set; }

        public Order(int id, double orderTotal)
        {
            Id = id;
            OrderTotal = orderTotal;
            

        }

    }
}