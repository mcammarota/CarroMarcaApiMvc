using LADS20M3.DR4.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace LADS20M3.DR4.HttpService.Implementations
{
    public class MarcaHttpClient : IMarcaHttpClient
    {
        private readonly HttpClient _httpClient;

        public MarcaHttpClient(
            HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MarcaViewModel> CreateAsync(MarcaViewModel marcaViewModel)
        {
            var httpResponseMessage = await _httpClient
                    .PostAsJsonAsync(string.Empty, marcaViewModel);

            var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var marcaResponse = await JsonSerializer
                .DeserializeAsync<MarcaViewModel>(
                    contentStream,
                    new JsonSerializerOptions
                    {
                        IgnoreNullValues = true,
                        PropertyNameCaseInsensitive = true
                    });

            return marcaResponse;
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"{id}");
        }

        public async Task<IEnumerable<MarcaViewModel>> GetAllAsync(string buscaTexto)
        {
            var marcas = await _httpClient
                .GetFromJsonAsync<IEnumerable<MarcaViewModel>>(buscaTexto);

            return marcas;
        }

        public async Task<MarcaViewModel> GetByIdAsync(int id)
        {
            var marcaViewModel = await _httpClient
                .GetFromJsonAsync<MarcaViewModel>($"GetById/{id}");

            return marcaViewModel;
        }

        public async Task<MarcaViewModel> UpdateAsync(MarcaViewModel marcaViewModel)
        {
            var httpResponseMessage = await _httpClient
                    .PutAsJsonAsync($"{marcaViewModel.Id}", marcaViewModel);

            var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var marcaResponse = await System.Text.Json.JsonSerializer
                .DeserializeAsync<MarcaViewModel>(
                    contentStream,
                    new JsonSerializerOptions
                    {
                        IgnoreNullValues = true,
                        PropertyNameCaseInsensitive = true
                    });

            return marcaResponse;
        }
    }
}
