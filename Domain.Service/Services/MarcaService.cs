using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;
using System.Collections.Generic;

namespace Domain.Service.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }
        
        public MarcaModel Create(MarcaModel marcaModel)
        {
            return _marcaRepository.Create(marcaModel);
        }

        public void Delete(int id)
        {
            _marcaRepository.Delete(id);
        }

        public IEnumerable<MarcaModel> GetAll(string buscaTexto)
        {
            return _marcaRepository.GetAll(buscaTexto);
        }

        public MarcaModel GetById(int id)
        {
            return _marcaRepository.GetById(id);
        }

        public MarcaModel Update(MarcaModel marcaModel)
        {
            return _marcaRepository.Update(marcaModel);
        }
    }
}
