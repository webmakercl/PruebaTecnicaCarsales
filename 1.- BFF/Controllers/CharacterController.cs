using _1.__BFF.Models;
using _1.__BFF.Services;
using Microsoft.AspNetCore.Mvc;

namespace _1.__BFF.Controllers
{
    /// <summary>
    /// Controlador de los personajes
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _service;
        private readonly ILogger<CharacterController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public CharacterController(ICharacterService service, ILogger<CharacterController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Metodo para obtener los personajes
        /// </summary>
        /// <param name="pageUrl">URL para paginacion</param>
        /// <returns>Lista de personajes</returns>
        [HttpGet]
        [Consumes("application/json")] 
        [Produces("application/json")]
        public async Task<ActionResult<ApiResponse<Character>>> GetCharacters([FromQuery] string? pageUrl)
        {
            try
            {
                var episodes = await _service.GetCharactersAsync(pageUrl);
                return Ok(episodes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener episodios: {ex.Message}");
            }
        }
    }
}