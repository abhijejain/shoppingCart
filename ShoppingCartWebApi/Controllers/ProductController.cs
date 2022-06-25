using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartWebApi.Business;
using ShoppingCartWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IShoppingBusiness _business;

        public ProductController(IShoppingBusiness business)
        {
            _business = business;
        }

        #region Crud Operation

        //Get All Products
        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetProducts(int? pageNo, int? pageSize)
        {
            IEnumerable<Product> products = _business.GetProducts();
            int currentPageSize = pageSize ?? 3;
            int currentPageNo = pageNo ?? 1;
            return Ok(products.Skip((currentPageNo - 1) * currentPageSize).Take(currentPageSize));
        }

        //sorting 
        [HttpGet]
        [Route("GetProductList")]
        public IActionResult GetProductList(string sortOrder)
        {
             sortOrder = sortOrder?.ToLower();
             IEnumerable<Product> products = _business.GetProductList(sortOrder);
             return Ok(products);
             
        }

        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct([FromBody] Product product)
        {
                string userId = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
                product.UserId = userId;
                _business.AddProduct(product);
                return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(int productId, [FromBody] Product product)
        {
            string userId = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            _business.UpdateProduct(product, productId);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete("{productId}")]
        public IActionResult RemoveProduct(int productId)
        {
            string userId = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            _business.RemoveProduct(productId);
            return Ok("Record Deleted successfully!");
        }


        #endregion
    }
}
