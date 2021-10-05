using Domain.Model.Models;
using System.Collections.Generic;

namespace Domain.Model.Interfaces.Services
{
    public interface ICarroService
    {
        IEnumerable<CarroModel> GetAll(string buscaTexto);
        CarroModel GetById(int id);
        CarroModel Create(MarcaCarroAggViewModel marcaCarroAggViewModel);
        CarroModel Update(CarroModel carroModel);
        void Delete(int id);
        bool CheckModelo(string modelo, int id);
    }
}
