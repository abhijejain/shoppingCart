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
    public class CartController : ControllerBase
    {
        private readonly ICartBusiness _business;
        public CartController(ICartBusiness business)
        {
            _business = business;
        }

        #region Crud Operation

        //Get All Cart Details
        [HttpGet]
        [Route("GetCartDetails")]
        public IActionResult GetCartDetails()
        {
            IEnumerable<Cart> cart = _business.GetCartDetails();
            return Ok(cart);
        }

        [HttpPost]
        [Route("AddtoCart")]
        public IActionResult AddtoCart([FromBody] Cart cart)
        {
            string userId = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            cart.UserId = userId;
            if(cart.Quantity > 0)
            {
                _business.AddtoCart(cart);
            }
            else
            {
               return Ok("Minimum Quantity Should be more ");
            }

            return StatusCode(StatusCodes.Status201Created);
        }

    }
    #endregion
}

