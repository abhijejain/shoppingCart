using Microsoft.AspNetCore.Mvc;
using ShoppingCartWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.Business
{
    public interface IShoppingBusiness
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductList(string sortOrder);
        void AddProduct(Product product);
        string UpdateProduct(Product product, int productId);
        string RemoveProduct(int productId);
    }
}
