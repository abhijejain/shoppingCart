using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.Models
{
    public class SignUpRequestModel
    {
//internal string client_id;
        public string client_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string connection { get; set; }

    }
}
