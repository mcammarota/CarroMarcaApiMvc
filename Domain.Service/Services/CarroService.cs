using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;
using System.Collections.Generic;
using System.Transactions;

namespace Domain.Service.Services
{
    public class CarroService : ICarroService
    {
        private readonly ICarroRepository _carroRepository;
        private readonly IMarcaRepository _marcaRepository;

        public CarroService(ICarroRepository carroRepository, IMarcaRepository marcaRepository)
        {
            _carroRepository = carroRepository;
            _marcaRepository = marcaRepository;
        }

        public CarroModel Create(MarcaCarroAggViewModel marcaCarroAggViewModel)
        {
            if (marcaCarroAggViewModel.Carro.MarcaId > 0)
            {
                return _carroRepository.Create(marcaCarroAggViewModel.Carro);
            }

            var marca = _marcaRepository.Create(marcaCarroAggViewModel.Marca);

            marcaCarroAggViewModel.Carro.Marca = marca;

            var carro = _carroRepository.Create(marcaCarroAggViewModel.Carro);

            return carro;
        }

        public void Delete(int id)
        {
            _carroRepository.Delete(id);
        }

        public IEnumerable<CarroModel> GetAll(string buscaTexto)
        {
            return _carroRepository.GetAll(buscaTexto);
        }

        public CarroModel GetById(int id)
        {
            return _carroRepository.GetById(id);
        }

        public CarroModel Update(CarroModel carroModel)
        {
            return _carroRepository.Update(carroModel);
        }

        public bool CheckModelo(string modelo, int id)
        {
            var carroModel = _carroRepository.GetModeloNotFromThisId(modelo, id);
            return carroModel is null;
        }
    }
}
