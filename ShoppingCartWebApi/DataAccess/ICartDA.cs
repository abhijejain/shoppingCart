using ShoppingCartWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.DataAccess
{
    public interface ICartDA
    {
        IEnumerable<Cart> GetCartDetails();
        void AddtoCart(Cart cart);
    }
}
