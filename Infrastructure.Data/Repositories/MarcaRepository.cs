using Infrastructure.Data.Context;
using Domain.Model.Exceptions;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly BibliotecaContext _bibliotecaContext;

        public MarcaRepository(BibliotecaContext bibliotecaContext)
        {
            _bibliotecaContext = bibliotecaContext;
        }
        
        public MarcaModel Create(MarcaModel marcaModel)
        {
            _bibliotecaContext.Add(marcaModel);

            return marcaModel;
        }

        public void Delete(int id)
        {
            var marcaModel = GetById(id);
            _bibliotecaContext.Remove(marcaModel);
        }

        public IEnumerable<MarcaModel> GetAll(string buscaTexto)
        {
            var marcas = _bibliotecaContext
                .Marcas
                .Include(x => x.Carros)
                .AsEnumerable();

            if (string.IsNullOrWhiteSpace(buscaTexto))
            {
                var result = marcas.ToList();
                return result;
            }
            else
            {
                var result = marcas.Where(x => x.Nome.Contains(buscaTexto)).ToList();
                return result;
            }
        }

        public MarcaModel GetById(int id)
        {
            return _bibliotecaContext
                .Marcas
                .Include(x => x.Carros)
                .FirstOrDefault(x => x.Id == id);
        }

        public MarcaModel Update(MarcaModel marcaModel)
        {
            try
            {
                _bibliotecaContext.Update(marcaModel);
   
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var message = GetById(marcaModel.Id) is null
                    ? "Autor não encontrado na base de dados"
                    : "Ocorreu um erro inesperado de concorrência. Tente novamente.";

                throw new RepositoryException(message, ex);
            }

            return marcaModel;
        }
    }
}
