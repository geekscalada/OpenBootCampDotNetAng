using APIVersionControl.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APIVersionControl.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersControllerV2 : ControllerBase
    {
       
        private const string ApiTestURL = "https://fakestoreapi.com/products";
        
        private const string AppID = "6283561db7f84b13fae4115f";
        private readonly HttpClient _httpClient;

        public UsersControllerV2(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("1.0")]
        [HttpGet(Name = "GetUsersData")]
        public async Task<IActionResult> GetUsersDataAsync()
        {

            // hacemos la petición a la URL
            var response = await _httpClient.GetStreamAsync(ApiTestURL);            


            var productData = JsonSerializer.DeserializeAsyncEnumerable<Producto>(response);


            return Ok(productData);

        }

    }
}
