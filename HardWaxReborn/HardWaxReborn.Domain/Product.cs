using System;
using System.Collections.Generic;
using System.Text;

namespace HardWaxReborn.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set;}

        public string Type { get; set; }

        public Product(int id, string name, double price, string type)
        {
            Id = id;
            Name = name;
            Price = price;
            Type = type;
            


        }
    }
}
