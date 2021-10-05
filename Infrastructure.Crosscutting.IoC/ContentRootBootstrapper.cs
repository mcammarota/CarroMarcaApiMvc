using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Model.Interfaces.UoW;
using Domain.Service.Services;
using Infrastructure.Data.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Crosscutting.IoC
{
    public static class ContentRootBootstrapper
    {
        public static void RegisterDependencies(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<BibliotecaContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("BibliotecaContext")));

            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<ICarroService, CarroService>();
            services.AddScoped<ICarroRepository, CarroRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
