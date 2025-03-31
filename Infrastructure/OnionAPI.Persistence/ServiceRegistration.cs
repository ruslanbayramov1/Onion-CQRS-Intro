using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnionAPI.Application.Interfaces;
using OnionAPI.Domain.Enums;
using OnionAPI.Persistence.Clients;
using OnionAPI.Persistence.Contexts;
using OnionAPI.Persistence.Helpers;
using OnionAPI.Persistence.Implements;

namespace OnionAPI.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddNpgSql(this IServiceCollection services)
    {
        services.AddDbContext<AppPostgreDbContext>(opt =>
        {
            opt.UseNpgsql(ConfigurationHelper.GetConnectionString("Postgres"));
        });

        return services;
    }

    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped<IProductPostgreService, ProductPostgreService>();
        services.AddScoped<IProductElasticService, ProductElasticService>();

        return services;
    }

    public static IApplicationBuilder UseElasticSeedIndexes(this IApplicationBuilder app)
    {
        var client = ElasticClient.GetClient(ElasticIndexes.products);
        client.IndexAsync(ElasticIndexes.products.ToString().ToLower()).Wait();

        return app;
    }
}
