using _1.__BFF.Models;
using _1.__BFF.Services;
using Microsoft.AspNetCore.Mvc;

namespace _1.__BFF.Controllers
{
    /// <summary>
    /// Controlador de los episodios
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EpisodesController : ControllerBase
    {
        private readonly IEpisodeService _service;
        private readonly ILogger<EpisodesController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public EpisodesController(IEpisodeService service, ILogger<EpisodesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Metodo para obtener los Episodios
        /// </summary>
        /// <param name="pageUrl">URL para paginacion</param>
        /// <returns>Lista de episodios</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<ApiResponse<Episode>>> GetEpisodes([FromQuery] string? pageUrl)
        {
            try
            {
                var episodes = await _service.GetEpisodesAsync(pageUrl);
                return Ok(episodes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener episodios: {ex.Message}");
            }
        }
    }
}