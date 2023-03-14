using Core.CustomEntities;
using Core.Interfaces;
using Core.Interfaces.IServices;
using Core.Services;
using Infraestructura.Data;
using Infraestructura.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructura.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<QDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DbConnection"))
            );
            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            //services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            services.AddTransient<IWmonedaService, WmonedaService>();
            services.AddTransient<IWsucursalService, WsucursalService>();
            
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddAllowCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });

            return services;
        }
    }
}
