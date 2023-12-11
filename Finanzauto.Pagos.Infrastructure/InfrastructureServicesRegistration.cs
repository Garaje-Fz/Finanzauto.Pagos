using Finanzauto.Pagos.Application.Contracts.Services;
using Finanzauto.Pagos.Application.Models.Services.Daviplata;
using Finanzauto.Pagos.Infrastructure.Services.Daviplata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Serialization;

namespace Finanzauto.Pagos.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DaviplataSettings>(x => configuration.GetSection("DaviplataSettings"));
            
            services.AddTransient<IDaviplataService, DaviplataService>();
            return services;
        }
    }
}
