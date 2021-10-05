using System;
using System.Collections.Generic;
using System.Text;
using Domain.Model.Models;

namespace Domain.Model.Interfaces.Services
{
    public interface IMarcaService
    {
        IEnumerable<MarcaModel> GetAll(string BuscaTexto);
        MarcaModel GetById(int id);

        MarcaModel Create(MarcaModel marcaModel);
        MarcaModel Update(MarcaModel marcaModel);
        void Delete(int id);
    }
}
