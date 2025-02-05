using System.Net.Http;
using System.Text.Json;
using _1.__BFF.Models;

namespace _1.__BFF.Services
{
    /// <summary>
    /// Interface del servicio para los personajes
    /// </summary>
    public interface ICharacterService
    {
        Task<ApiResponse<Character>> GetCharactersAsync(string? pageUrl = null);
    }

    /// <summary>
    /// Clase con implementacion
    /// </summary>
    public class CharacterService : ICharacterService
    {
        /// <summary>
        /// URL de api Rick y Morty
        /// </summary>
        private const string ApiUrl = "https://rickandmortyapi.com/api/character";

        /// <summary>
        /// httpClient para consumo de api
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient"></param>
        public CharacterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Metodo para obtener los Personajes
        /// </summary>
        /// <param name="pageUrl">URl correspondiente a la paginacion</param>
        /// <returns>Lista de personajes</returns>
        public async Task<ApiResponse<Character>> GetCharactersAsync(string? pageUrl = null)
        {
            var url = pageUrl ?? ApiUrl;
            var response = await _httpClient.GetStringAsync(url);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<ApiResponse<Character>>(response, options);
        }
    }



}