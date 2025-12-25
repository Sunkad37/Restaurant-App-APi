using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.Domain.Repositories;
using RestaurantApp.Infrastructure.Persistence;
using RestaurantApp.Infrastructure.Repositories;
using RestaurantApp.Infrastructure.Seeders;

namespace RestaurantApp.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RestaurantDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("RestaurantAppDb")));

        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
    }
}