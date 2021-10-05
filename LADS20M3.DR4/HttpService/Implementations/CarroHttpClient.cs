using LADS20M3.DR4.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace LADS20M3.DR4.HttpService.Implementations
{
    public class CarroHttpClient : ICarroHttpClient
    {
        private readonly HttpClient _httpClient;

        public CarroHttpClient(
            HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CarroViewModel> CreateAsync(MarcaCarroAggRequest marcaCarroAggRequest)
        {
            var httpResponseMessage = await _httpClient
                    .PostAsJsonAsync(string.Empty, marcaCarroAggRequest);

            var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var carroResponse = await JsonSerializer
                .DeserializeAsync<CarroViewModel>(
                    contentStream,
                    new JsonSerializerOptions
                    {
                        IgnoreNullValues = true,
                        PropertyNameCaseInsensitive = true
                    });

            return carroResponse;
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"{id}");
        }

        public async Task<IEnumerable<CarroViewModel>> GetAllAsync(string buscaTexto)
        {
            var carros = await _httpClient
                .GetFromJsonAsync<IEnumerable<CarroViewModel>>(buscaTexto);
            return carros;
        }

        public async Task<CarroViewModel> GetByIdAsync(int id)
        {
            var carroViewModel = await _httpClient
                .GetFromJsonAsync<CarroViewModel>($"GetById/{id}");

            return carroViewModel;
        }

        public async Task<CarroViewModel> UpdateAsync(CarroViewModel carroViewModel)
        {
            var httpResponseMessage = await _httpClient
                    .PutAsJsonAsync($"{carroViewModel.Id}", carroViewModel);

            var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var carroResponse = await JsonSerializer
                .DeserializeAsync<CarroViewModel>(
                    contentStream,
                    new JsonSerializerOptions
                    {
                        IgnoreNullValues = true,
                        PropertyNameCaseInsensitive = true
                    });

            return carroResponse;
        }

        public async Task<bool> CheckModelo(string modelo, int id)
        {
            if (string.IsNullOrWhiteSpace(modelo))
                return false;
            var isModeloValid = await _httpClient
                .GetFromJsonAsync<bool>($"CheckModelo/{modelo}/{id}");

            return isModeloValid;
        }
    }
}
