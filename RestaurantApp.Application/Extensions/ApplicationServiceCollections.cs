using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace RestaurantApp.Application.Extensions;

public static class ApplicationServiceCollections
{
    public static  void AddApplicationServices(this IServiceCollection services)
    {
        var appassembly = typeof(ApplicationServiceCollections).Assembly;
        
        services.AddAutoMapper(appassembly);
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(appassembly));
        
        services.AddValidatorsFromAssembly(appassembly)
            .AddFluentValidationAutoValidation();
    }
}