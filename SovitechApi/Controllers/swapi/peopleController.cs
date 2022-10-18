using Microsoft.AspNetCore.Mvc;

namespace SovitechApi.Controllers.swapi
{
    [ApiController]
    public class swapi : ControllerBase
    {
        [HttpGet]
        [Route("People")]

        public async Task<IActionResult> GetPeople()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://swapi.dev/api/people/");
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
