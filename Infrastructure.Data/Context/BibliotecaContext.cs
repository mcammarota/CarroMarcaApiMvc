using Domain.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        public DbSet<MarcaModel> Marcas { get; set; }
        public DbSet<CarroModel> Carros { get; set; }

    }
}
