using LADS20M3.DR4.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LADS20M3.DR4.HttpService
{
    public interface ICarroHttpClient
    {
        Task<IEnumerable<CarroViewModel>> GetAllAsync(string buscaTexto);
        Task<CarroViewModel> GetByIdAsync(int id);
        Task<CarroViewModel> CreateAsync(MarcaCarroAggRequest marcaCarroAggRequest);
        Task<CarroViewModel> UpdateAsync(CarroViewModel carroModel);
        Task DeleteAsync(int id);
        Task<bool> CheckModelo(string modelo, int id);
    }
}
