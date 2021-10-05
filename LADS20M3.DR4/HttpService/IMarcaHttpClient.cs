using LADS20M3.DR4.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LADS20M3.DR4.HttpService
{
    public interface IMarcaHttpClient
    {
        Task<IEnumerable<MarcaViewModel>> GetAllAsync(string buscaTexto);
        Task<MarcaViewModel> GetByIdAsync(int id);
        Task<MarcaViewModel> CreateAsync(MarcaViewModel marcaModel);
        Task<MarcaViewModel> UpdateAsync(MarcaViewModel marcaModel);
        Task DeleteAsync(int id);
    }
}
