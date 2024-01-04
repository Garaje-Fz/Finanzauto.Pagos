using Finanzauto.Pagos.Application.Contracts.Repositories;
using Finanzauto.Pagos.Application.Contracts.Services;
using Finanzauto.Pagos.Application.Models.Services.Daviplata;
using Finanzauto.Pagos.Application.Models.Services.Signature;
using Finanzauto.Pagos.Infrastructure.Persistence;
using Finanzauto.Pagos.Infrastructure.Repositories;
using Finanzauto.Pagos.Infrastructure.Services.Daviplata;
using Finanzauto.Pagos.Infrastructure.Services.Signature;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Finanzauto.Pagos.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //DbContext
            services.AddDbContext<ClientsDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ClientesConnectionString")));

            //Generic repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Services
            services.AddTransient<IDaviplataService, DaviplataService>();
            services.AddTransient<ISignatureService, SignatureService>();

            //Service configurations
            services.Configure<DaviplataSettings>(x => configuration.GetSection("DaviplataSettings"));
            services.Configure<SignatureSettings>(x => configuration.GetSection("SignatureSettings"));

            return services;
        }
    }
}
