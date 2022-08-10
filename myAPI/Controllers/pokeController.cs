using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace myAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class pokemonController : ControllerBase
    {
        specieModel content;
        private readonly HttpClient _client;
        public pokemonController(IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _client = clientFactory.CreateClient("pokemon");
        }
        /// <summary>
        ///Uses the https://pokeapi.co/ api
        /// Gets the name of a pokemon species according to the input number
        /// </summary>
        /// <returns>A string representing name of a pokemon species corresponding to the input index </returns>
        [HttpGet]
        [Route("pokemon-species")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetRawRedditHotPosts(int randomNum)
        {
            var res = await _client.GetAsync("");
            content = await res.Content.ReadFromJsonAsync<specieModel>();
            String name;
            if (randomNum < 19 && randomNum > 0)
            {
                name = content.results[randomNum].name;
            }
            else { name = ""; }
            return Ok(name);
        }
        //ReadFromJsonAsync
    }

}

