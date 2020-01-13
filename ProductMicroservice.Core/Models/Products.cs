using System;
using System.Collections.Generic;


namespace ProductMicroservice.Core.Model
{
    public class Products
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Details { get; set; }
        public List<Carts> Carts { get; set; }
    }
}
