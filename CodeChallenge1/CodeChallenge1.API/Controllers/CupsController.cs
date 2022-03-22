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

        }
    }
}
