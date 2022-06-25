using Microsoft.AspNetCore.Mvc;
using ShoppingCartWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.DataAccess
{
    public class ShoppingDA : IShoppingDA
    {
        public ShoppingCartDbContext _shoppingDbContext;

        public ShoppingDA(ShoppingCartDbContext shoppingDbContext)
        {
            _shoppingDbContext = shoppingDbContext;

        }

        public void AddProduct(Product product)
        {
            _shoppingDbContext.ProductList.Add(product);
            _shoppingDbContext.SaveChanges();
        }

        public IEnumerable<Product> GetProductList(string sortOrder)
        {
            sortOrder = sortOrder?.ToLower();
            IQueryable<Product> products = sortOrder switch
            {
                "desc" => _shoppingDbContext.ProductList.OrderByDescending(p => p.Price),
                "asc" => _shoppingDbContext.ProductList.OrderBy(p => p.Price),
                _ => _shoppingDbContext.ProductList,
            };
            return products;
        }

        public IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> products = _shoppingDbContext.ProductList;
            return products;
        }

        public string RemoveProduct(int productId)
        {
            Product selectedProduct = _shoppingDbContext.ProductList.Find(productId);
            if (selectedProduct == null)
                return ("No Records Found for this ID - " + productId);

            //if (userId != selectedProduct.UserId)
            //    return BadRequest("Sorry....You don't have access to delete this record");
            else
            {
                _shoppingDbContext.ProductList.Remove(selectedProduct);
                _shoppingDbContext.SaveChanges();
                return ("Record Deleted successfully!");
            }
        }

        public string UpdateProduct(Product product, int productId)
        {
            Product selectedProduct = _shoppingDbContext.ProductList.Find(productId);
            if (selectedProduct == null)
            {
                return ("No Records Found for this ID - " + productId);
            }
            //if (product.UserId != selectedProduct.UserId)
            //{
            //    return "Sorry....You don't have access to Update this record";
            //}
            else
            {
                selectedProduct.Name = product.Name;
                selectedProduct.Description = product.Description;
                selectedProduct.Category = product.Category;
                selectedProduct.SubCategory = product.SubCategory;
                selectedProduct.Price = product.Price;
                selectedProduct.DateAdded = product.DateAdded;
                selectedProduct.ExpiryDate = product.ExpiryDate;
                _shoppingDbContext.SaveChanges();
                return "Record Updated Successfully in the database";
            }
        }
    }
}
