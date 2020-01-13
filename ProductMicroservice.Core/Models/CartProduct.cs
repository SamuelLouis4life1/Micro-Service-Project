using System;

namespace ProductMicroservice.Core.Model
{
    public class CartProduct
    {
        public Guid Id { get; set; }
        public virtual Carts Carts { get; set; }
        public virtual Products Products { get; set; }
    }
}
