using System;
using System.Collections.Generic;

namespace ProductMicroservice.Core.Model
{
    public class Carts
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public List<Products> Products { get; set; }
    }
}
