using ShoppingCartWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.Business
{
    public interface ICartBusiness
    {
        IEnumerable<Cart> GetCartDetails();
        void AddtoCart(Cart cart);
    }
}
