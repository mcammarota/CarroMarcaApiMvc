using Domain.Model.Models;
using System.Collections.Generic;

namespace Domain.Model.Interfaces.Repositories
{
    public interface IMarcaRepository
    {
        IEnumerable<MarcaModel> GetAll(string buscaTexto);
        MarcaModel GetById(int id);

        MarcaModel Create(MarcaModel marcaModel);
        MarcaModel Update(MarcaModel marcaModel);
        void Delete(int id);
    }
}
