using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();

        [HttpGet]
        public async Task<HttpResponseMessage> GetAlbums()
        {
            var getData = await client.GetAsync("https://jsonplaceholder.typicode.com/albums");
            return getData;
        }
    }
}
