using Infrastructure.Data.Context;
using Domain.Model.Exceptions;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class CarroRepository : ICarroRepository
    {
        private readonly BibliotecaContext _bibliotecaContext;

        public CarroRepository(BibliotecaContext bibliotecaContext)
        {
            _bibliotecaContext = bibliotecaContext;
        }

        public CarroModel Create(CarroModel carroModel)
        {
            _bibliotecaContext.Add(carroModel);
            
            return carroModel;
        }

        public void Delete(int id)
        {
            var carroModel = GetById(id);
            _bibliotecaContext.Remove(carroModel);
        }

        public IEnumerable<CarroModel> GetAll(string buscaTexto)
        {
            var carros = _bibliotecaContext
                .Carros
                .Include(l => l.Marca);

            return string.IsNullOrWhiteSpace(buscaTexto)
                ? carros
                : carros.Where(x => x.Modelo.Contains(buscaTexto));
        }

        public CarroModel GetById(int id)
        {
            return _bibliotecaContext
                .Carros
                .Include(l => l.Marca)
                .FirstOrDefault(m => m.Id == id);
        }

        public CarroModel Update(CarroModel carroModel)
        {
            try
            {
                _bibliotecaContext.Update(carroModel);
                
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var message = GetById(carroModel.Id) is null
                    ? "Carro não encontrado na base de dados"
                    : "Ocorreu um erro inesperado de concorrência. Tente novamente.";

                throw new RepositoryException(message, ex);
            }

            return carroModel;
        }

        public CarroModel GetModeloNotFromThisId(string modelo, int id)
        {
            var result = _bibliotecaContext
                .Carros
                .FirstOrDefault(x => x.Modelo == modelo && x.Id != id);

            return result;
        }
    }
}
