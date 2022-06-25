using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        Product product { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("product")]
        public int ProductId { get; set; }
        public decimal TotalAmount { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
    }
}
