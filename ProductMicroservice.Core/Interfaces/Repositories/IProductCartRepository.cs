using ProductMicroservice.Core.Model;
using System;
using System.Collections.Generic;


namespace ProductMicroservice.Core.Interfaces.Repositories
{
    public interface IProductCartRepository
    {
        void Create(CartProduct productCart);

        CartProduct Read(Guid id);

        IReadOnlyCollection<CartProduct> ReadAll();

        void Update(CartProduct productCart);

        void Delete(CartProduct productCart);
    }
}
