using System;
using System.Collections.Generic;
using System.Text;

namespace HardWaxReborn.Domain
{
    public class Store
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Dictionary<int, int> Stock { get; set; }



    }
}
