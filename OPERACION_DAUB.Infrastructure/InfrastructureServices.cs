using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OPERACION_DAUB.INFRASTRUCTURE.Repositories;
using OPERACION_DAUB.INFRASTRUCTURE.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPERACION_DAUB.INFRASTRUCTURE
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStringConfig>(c =>
            {
                configuration.GetSection("ConnectionStrings");
            });
            services.AddScoped<IRepresentanteRepository, RepresentanteRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProveedorRepository, ProveedorRepository>();
            services.AddScoped<IContratoRepository, ContratoRepository>();

            return services;
        }
    }
}
