using System.Net.Http;
using System.Text.Json;
using _1.__BFF.Models;

namespace _1.__BFF.Services
{
  
    /// <summary>
    /// Interface del servicio para los episodios
    /// </summary>
    public interface IEpisodeService
    {
        Task<ApiResponse<Episode>> GetEpisodesAsync(string? pageUrl = null);
    }

    /// <summary>
    /// Clase con Implementacion
    /// </summary>
    public class EpisodeService : IEpisodeService
    {
        /// <summary>
        /// URL api Rick y Morty
        /// </summary>
        private const string ApiUrl = "https://rickandmortyapi.com/api/episode";

        /// <summary>
        /// httpClient para consumo de api
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient"></param>
        public EpisodeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Metodo para obtener los episodios
        /// </summary>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        public async Task<ApiResponse<Episode>> GetEpisodesAsync(string? pageUrl = null)
        {
            var url = pageUrl ?? ApiUrl;
            var response = await _httpClient.GetStringAsync(url);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<ApiResponse<Episode>>(response, options);
        }
    }


}