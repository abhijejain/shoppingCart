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
    public class OrderController : ControllerBase
    {
        private readonly IOrderBusiness _business;
        public OrderController(IOrderBusiness business)
        {
            _business = business;
        }

        #region Crud Operation

        //Get All Cart Details
        [HttpGet]
        [Route("GetOrderDetails")]
        public IActionResult GetOrderDetails()
        {
            IEnumerable<Order> cart = _business.GetOrderDetails();
            return Ok(cart);
        }

        [HttpPost]
        [Route("PlaceOrder")]
        public IActionResult PlaceOrder([FromBody] Order order)
        {
            _business.PlaceOrder(order);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
    #endregion
}
