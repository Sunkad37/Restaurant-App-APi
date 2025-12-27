using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RestaurantApp.Application.User;

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

        services.AddScoped<IUserContext, UserContext>();
        services.AddHttpContextAccessor();
    }
}