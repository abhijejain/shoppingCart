using ShoppingCartWebApi.DataAccess;
using ShoppingCartWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.Business
{
    public class OrderBusiness:IOrderBusiness
    {
        private readonly IOrderDA _orderDA;
        public OrderBusiness(IOrderDA orderDA)
        {
            _orderDA = orderDA;
        }
        public IEnumerable<Order> GetOrderDetails()
        {
            return _orderDA.GetOrderDetails();
        }

        public void PlaceOrder(Order order)
        {
            _orderDA.PlaceOrder(order);
        }
    }
}
