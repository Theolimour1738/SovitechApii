using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SovitechApi.Controllers.Search
{
    public class Search : ControllerBase
    {


        [HttpGet]
        [Route("search/{jokes}")]

        public async Task<IActionResult> SearchJokes(string jokes)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.chucknorris.io/jokes/search?query=" + jokes);
                using (HttpResponseMessage response = await client.GetAsync(client.BaseAddress))
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    response.EnsureSuccessStatusCode();
                    return Ok(responseContent);
                }
            }
        }

        [HttpGet]
        [Route("searchP/{people}")]
        public async Task<IActionResult> SearchPeople(string people)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://swapi.dev/api/people/?search=" + people);
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
