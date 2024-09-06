using System.Net.Http;
using System.Threading.Tasks;

namespace MiApiRest.Services
{
    public class RickAndMortyService
    {
        private readonly HttpClient _httpClient;

        public RickAndMortyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetCharactersAsync()
        {
            var response = await _httpClient.GetAsync("https://rickandmortyapi.com/api/character");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
