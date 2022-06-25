using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.Models
{
    public class SignUpResponseModel
    {
        public string _Id { get; set; }
        public bool Email_verified { get; set; }
        public string Email { get; set; }
    }
}
