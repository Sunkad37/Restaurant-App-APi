using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.Application.Restaurants;

namespace RestaurantApp.Application.Extensions;

public static class ApplicationServiceCollections
{
    public static  void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IRestaurantsService, RestaurantsService>();
    }
}