using FaleMais.Data.Repository;
using FaleMais.Domain.Interfaces;
using FaleMais.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FaleMais.Ui.Web.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITarifaRepository, TarifaRepository>();
            services.AddScoped<IPlanoRepository, PlanoRepository>();

            services.AddScoped<ITarifaService, TarifaService>();
        }
    }
}
