using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;
using Ecom.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecom.Infrastructure;

public static class InfrastructureRegistration
{
    public static IServiceCollection InfrastructureConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        // services.AddScoped<ICategoryRepository, CategoryRepository>();
        // services.AddScoped<IProductRepository, ProductRepository>();
        // services.AddScoped<IPhotoRepository, PhotoRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        // Apply DbContext
        services.AddDbContext<AppDbContext>(op =>
        {
            op.UseSqlServer(configuration.GetConnectionString("EcomDatabase"));
        });
        return services;
    }
}