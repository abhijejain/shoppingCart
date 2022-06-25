using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.Models
{
    public class Cart
    {
        //public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; }
        Product product { get; set; }

        [ForeignKey("product")]
        public int ProductId { get; set; }

        public decimal TotalCost { get; set; }

    }
}
