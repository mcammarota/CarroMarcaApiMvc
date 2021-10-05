using Domain.Model.Models;
using System.Collections.Generic;

namespace Domain.Model.Interfaces.Repositories
{
    public interface ICarroRepository
    {
        IEnumerable<CarroModel> GetAll(string buscaTexto);
        CarroModel GetById(int id);

        CarroModel Create(CarroModel carroModel);
        CarroModel Update(CarroModel carroModel);
        void Delete(int id);
        CarroModel GetModeloNotFromThisId(string modelo, int id);
    }
}
