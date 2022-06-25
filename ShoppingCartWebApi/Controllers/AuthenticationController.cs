using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShoppingCartWebApi.Models;
using System;
using System.Net.Http;
using System.Text;


namespace ShoppingCartWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _config;
        private static readonly HttpClient Client = new HttpClient();

        public AuthenticationController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp(SignUpRequestModel signup)
        {

            signup.client_id = _config.GetValue<string>("auth0_client_id");
            signup.connection = _config.GetValue<string>("auth0_connection");
            var signupDetail = new SignUpResponseModel();
            var jsonContent = JsonConvert.SerializeObject(signup);
            using (HttpRequestMessage request = new HttpRequestMessage())
            {
                var uriBuilder = new UriBuilder(_config.GetValue<string>("auth0_signup_api_url"));
                request.RequestUri = uriBuilder.Uri;
                request.Method = HttpMethod.Post;
                request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                using (var result = Client.SendAsync(request).Result)
                {
                    if (result.IsSuccessStatusCode)
                    {
                        var detail = result.Content.ReadAsStringAsync().Result;
                        signupDetail = JsonConvert.DeserializeObject<SignUpResponseModel>(detail);
                    }
                }

            }

            return Json(new { response = signupDetail });

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetAccessToken(GetAccessTokenRequestModel getAccessToken)
        {

            getAccessToken.grant_type = _config.GetValue<string>("auth0_grant_type");
            getAccessToken.client_id = _config.GetValue<string>("auth0_client_id");
            getAccessToken.audience = _config.GetValue<string>("auth0_audience");
            getAccessToken.client_secret = _config.GetValue<string>("auth0_client_secret");

            var accessTokenDetail = new GetAccessTokenResponseModel();
            var jsonContent = JsonConvert.SerializeObject(getAccessToken);
            using (HttpRequestMessage request = new HttpRequestMessage())
            {
                var uriBuilder = new UriBuilder(_config.GetValue<string>("auth0_token_api_url"));
                request.RequestUri = uriBuilder.Uri;
                request.Method = HttpMethod.Post;
                request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                using (var result = Client.SendAsync(request).Result)
                {
                    if (result.IsSuccessStatusCode)
                    {
                        var detail = result.Content.ReadAsStringAsync().Result;
                        accessTokenDetail = JsonConvert.DeserializeObject<GetAccessTokenResponseModel>(detail);
                    }
                }

            }

            return Json(new { response = accessTokenDetail });

        }
    }
}
