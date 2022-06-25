using ShoppingCartWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.DataAccess
{
    public class CartDA : ICartDA
    {
        public ShoppingCartDbContext _cartDbContext;

        public CartDA(ShoppingCartDbContext cartDbContext)
        {
            _cartDbContext = cartDbContext;

        }

        public void AddtoCart(Cart cart)
        {
            Product product = _cartDbContext.ProductList.Find(cart.ProductId);
            if(product != null && product.ExpiryDate > DateTime.Now)
            {
                cart.TotalCost = (cart.Quantity * product.Price);
                _cartDbContext.Cart.Add(cart);
                _cartDbContext.SaveChanges();
            }
           
        }

        public IEnumerable<Cart> GetCartDetails()
        {
            IQueryable<Cart> carts = _cartDbContext.Cart;
            return carts;
        }
    }
}
