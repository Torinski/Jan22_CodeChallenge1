using CodeChallenge1.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CodeChallenge1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();

        [HttpGet]
        public async Task<List<Album>> GetAlbums([FromQuery] string? search = null)
        {
            var getData = await client.GetAsync("https://jsonplaceholder.typicode.com/albums");
            var jsonString = await getData.Content.ReadAsStringAsync();

            List<Album> model = JsonConvert.DeserializeObject<List<Album>>(jsonString);
            if (search == null)
            {
                return model;
            }
            else
            {
                List<Album> searchResults = new List<Album>();
                foreach (Album album in model)
                {
                    if (album.title.ToLower().Contains(search.ToLower()))
                    {
                        searchResults.Add(album);
                    }
                }
                return searchResults;
            }
        }
    }
}
