using ProductMicroservice.Core.Interfaces.Repositories;
using ProductMicroservice.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Core.Services
{
    public class ProductCartService
    {
        private IProductCartRepository _repository;
        //private global::DataAccess.Repositories.ProductCartRepository productCartRepository;

        public ProductCartService(IProductCartRepository repository)
        {
            _repository = repository;

        }

        /*public ProductCartService(global::DataAccess.Repositories.ProductCartRepository productCartRepository)
        {
            this.productCartRepository = productCartRepository;
        }*/

        public void AddProductToCart(Products product, Carts cart)
        {
            var productCart = new CartProduct
            {
                Products = product,
                Carts = cart
            };
            _repository.Create(productCart);
        }

        public void RemoveProductToCart(CartProduct cartProduct)
        {
            _repository.Delete(cartProduct);
        }

        public IReadOnlyCollection<Products> GetProductsInCart(Guid cartId)
        {
            return _repository.ReadAll()
                .Where(pc => pc.Carts.Id == cartId)
                .Select(pc => pc.Products).ToList();
        }

        public IReadOnlyCollection<Carts> GetCartProducts(Guid productId)
        {
            var cartProduct = _repository.ReadAll();
            return cartProduct
                .Where(pc => pc.Products
                .Id == productId).Select(pc => pc.Carts).ToList();
        }
    }
}
