using ShoppingCartWebApi.DataAccess;
using ShoppingCartWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.Business
{
    public class CartBusiness : ICartBusiness
    {
        private readonly ICartDA _cartDA;
        public CartBusiness(ICartDA cartDA)
        {
            _cartDA = cartDA;
        }

        public void AddtoCart(Cart cart)
        {
            _cartDA.AddtoCart(cart);
        }

        public IEnumerable<Cart> GetCartDetails()
        {
            return _cartDA.GetCartDetails();
        }
    }
}
