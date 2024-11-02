using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Interfaces;
using eCommerceApp.Infrastructure.Data;
using eCommerceApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceApp.Infrastructure.DependencyInjection;

public static class ServiceContainer
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = "Default";
        services.AddDbContext<AppDbContext>(Options => Options.UseSqlServer(configuration.GetConnectionString(connectionString), sqlOptions =>
        {// Ensure this is the correct assembly
            sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
            sqlOptions.EnableRetryOnFailure(); // Enable automatic retries for transient failures
        }), ServiceLifetime.Scoped);

        services.AddScoped<IGeneric<Product>, GenericRepository<Product>>();
        services.AddScoped<IGeneric<Category>, GenericRepository<Category>>();

        return services;
    }
}