using DataAccess.Contexts;
using ProductMicroservice.Core.Interfaces.Repositories;
using ProductMicroservice.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace DataAccess.Repositories
{
    public class ProductCartRepository :IProductCartRepository
    {
        public void Create(CartProduct productCart)
        {
            OnlineStoreContexts db = new OnlineStoreContexts();
            db.CartProducts.Add(productCart);
            db.SaveChanges();

        }

        public CartProduct Read(Guid id)
        {
            OnlineStoreContexts db = new OnlineStoreContexts();
            return db.CartProducts.Find(id);
        }

        public IReadOnlyCollection<CartProduct> ReadAll()
        {
            OnlineStoreContexts db = new OnlineStoreContexts();
            return db.CartProducts.ToList();
        }

        public void Update(CartProduct cartProduct)
        {
            OnlineStoreContexts db = new OnlineStoreContexts();
            db.Entry(cartProduct).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(CartProduct cartProduct)
        {
            OnlineStoreContexts db = new OnlineStoreContexts();
            db.CartProducts.Remove(cartProduct);
            db.SaveChanges();
        }
    }
}
