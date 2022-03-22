using CodeChallenge1.Models.Entities;
using CodeChallenge1.Models.ViewModels;
using CodeChallenge1.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CupsController : ControllerBase
    {
        private readonly ICupService _cupService;

        public CupsController(ICupService cupService)
        {
            _cupService = cupService;
        }

        [HttpPut("swap")]
        public async Task<ActionResult<CupVM>> SwapCups([FromBody] Array swaps)
        {
            var cupList = await _cupService.Setup();

            foreach (var swap in swaps)
            {
                if (swap.GetType() != typeof(string))
                {
                    return BadRequest("Swaps are not all string values.");
                }
                if ((swap as string).All(char.IsUpper) != true)
                {
                    return BadRequest("Not all swap characters are upper case.");
                }
                if ((swap as string).Length != 2)
                {
                    return BadRequest("Entered swap has too few, or too many, characters.");
                }
                char[] chars = (swap as string).ToCharArray();
                if (chars[0] == chars[1])
                {
                    return BadRequest("Cannot swap cup with itself.");
                }
                foreach (char c in chars)
                {
                    if (c != 'A' || c != 'B' || c != 'C')
                    {
                        return BadRequest("One of the input characters was not 'A', 'B', or 'C'");
                    }
                }
                //if (chars[0] == 'A' || chars[1] == 'A')
                //{
                //    CupVM start = cupList[0];
                //    if 
                //}
            }
        }
    }
}
