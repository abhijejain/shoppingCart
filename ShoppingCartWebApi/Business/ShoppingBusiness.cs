using Microsoft.AspNetCore.Mvc;
using ShoppingCartWebApi.DataAccess;
using ShoppingCartWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.Business
{
    public class ShoppingBusiness : IShoppingBusiness
    {
        private readonly IShoppingDA _shoppingDA;
        public ShoppingBusiness(IShoppingDA shoppingDA)
        {
            _shoppingDA = shoppingDA;
        }

        public void AddProduct(Product product)
        {
            _shoppingDA.AddProduct(product);
        }

        public IEnumerable<Product> GetProductList(string sortOrder)
        {
            return _shoppingDA.GetProductList(sortOrder);
        }

        public string RemoveProduct(int productId)
        {
            return _shoppingDA.RemoveProduct(productId);
        }

        public string UpdateProduct(Product product, int productId)
        {
            return _shoppingDA.UpdateProduct(product, productId);
        }

        IEnumerable<Product> IShoppingBusiness.GetProducts()
        {
            return _shoppingDA.GetProducts();
        }
    }
}
