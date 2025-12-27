using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using RestaurantApp.Api.Middlewares;
using RestaurantApp.Application.Extensions;
using RestaurantApp.Domain.Entities;
using RestaurantApp.Infrastructure.Extensions;
using RestaurantApp.Infrastructure.Seeders;
using RestaurantApp.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

//
// -------------------- SERVICE REGISTRATION --------------------
//

// Register application layer services (CQRS, MediatR, AutoMapper, etc.)
builder.Services.AddApplicationServices();

// Register infrastructure layer services (EF Core DbContext, repositories, etc.)
builder.Services.AddInfrastructure(builder.Configuration);

// Register Swagger/OpenAPI for API documentation
builder.Services.AddEndpointsApiExplorer();

// Swagger - Asp .Net Core Identity Set Up
builder.AddPresentationExtensions();

// Register custom error handling middleware
builder.Services.AddTransient<ErrorHandlingMiddleware>();

//
// -------------------- BUILD APP --------------------
//

var app = builder.Build();

//
// -------------------- DATABASE SEEDING --------------------
//

// Run initial seeding logic (e.g., populate restaurants/dishes if empty)
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
    await seeder.Seed();
}

//
// -------------------- HTTP REQUEST PIPELINE --------------------
//

// Enable Swagger only in Development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant API V1");
        c.RoutePrefix = string.Empty; // Swagger UI available at root "/"
    });
}

// Redirect HTTP → HTTPS
app.UseHttpsRedirection();

// Asp .Net Core Identity
//app.MapGroup("api/identity/").MapIdentityApi<User>();

app.MapPost("/login", async (LoginRequest request, SignInManager<User> signInManager) =>
{
    var result = await signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);
    return result.Succeeded ? Results.Ok("Login successful") : Results.Unauthorized();
});


// Authorization middleware (ensure endpoints respect [Authorize] attributes)
app.UseAuthorization();

// Global error handling middleware (catches exceptions and formats responses)
app.UseMiddleware<ErrorHandlingMiddleware>();

// Map controller routes (attribute routing)
app.MapControllers();

//
// -------------------- RUN APP --------------------
//

app.Run();