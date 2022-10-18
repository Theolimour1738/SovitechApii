using Microsoft.AspNetCore.Mvc;

namespace SovitechApi.Controllers.Chuck
{
    [ApiController]
    public class chuck : ControllerBase
    {

        [HttpGet]
        [Route("Categories")]

        public async Task<IActionResult> GetCategories()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.chucknorris.io/jokes/categories");
                using (HttpResponseMessage response = await client.GetAsync(client.BaseAddress))
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    response.EnsureSuccessStatusCode();
                    return Ok(responseContent);
                }
            }
        }


        [HttpGet]
        [Route("JokesCategories")]

        public async Task<IActionResult> GetJokesByCategories( string category )
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.chucknorris.io/jokes/random?category=" + category );
                using (HttpResponseMessage response = await client.GetAsync(client.BaseAddress))
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    response.EnsureSuccessStatusCode();
                    return Ok(responseContent);
                }
            }
        }

    }

}

