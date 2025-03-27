using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnionAPI.Application.Interfaces;
using OnionAPI.Persistence.Contexts;
using OnionAPI.Persistence.Helpers;
using OnionAPI.Persistence.Implements;

namespace OnionAPI.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddNpgSql(this IServiceCollection services)
    {
        services.AddDbContext<OnionApiDbContext>(opt =>
        {
            opt.UseNpgsql(ConfigurationHelper.GetString("Postgres"));
        });

        return services;
    }

    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
