using ShoppingCartWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.DataAccess
{
    public class OrderDA : IOrderDA
    {
        public ShoppingCartDbContext _cartDbContext;

        public OrderDA(ShoppingCartDbContext cartDbContext)
        {
            _cartDbContext = cartDbContext;

        }
        public IEnumerable<Order> GetOrderDetails()
        {
            IQueryable<Order> orders = _cartDbContext.Order;
            return orders;
        }

        public void PlaceOrder(Order order)
        {
            _cartDbContext.Order.Add(order);
            _cartDbContext.SaveChanges();
        }
    
    }
}
