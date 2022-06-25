using ShoppingCartWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.Business
{
    public interface IOrderBusiness
    {
        IEnumerable<Order> GetOrderDetails();
        void PlaceOrder(Order order);
    }
}
