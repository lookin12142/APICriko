using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MiApiRest.Services;

namespace MiApiRest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RickAndMortyController : ControllerBase
    {
        private readonly RickAndMortyService _service;

        public RickAndMortyController(RickAndMortyService service)
        {
            _service = service;
        }

        [HttpGet("characters")]
        public async Task<IActionResult> GetCharacters()
        {
            var characters = await _service.GetCharactersAsync();
            return Ok(characters);
        }
    }
}
