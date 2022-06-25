using ShoppingCartWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.DataAccess
{
    public interface IOrderDA
    {
        IEnumerable<Order> GetOrderDetails();
        void PlaceOrder(Order order);
    }
}
