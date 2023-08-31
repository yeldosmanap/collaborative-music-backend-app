using System.Text.Json.Serialization;
using CollaborativeMusicApp.Application.Contract.Persistence;
using CollaborativeMusicApp.Application.Services;
using CollaborativeMusicApp.Application.Services.Implementations;
using CollaborativeMusicApp.Domain.Entities;
using CollaborativeMusicApp.Infrastructure;
using CollaborativeMusicApp.Infrastructure.Auth;
using CollaborativeMusicApp.Infrastructure.Context;
using CollaborativeMusicApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DataContext
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddAuth(builder.Configuration);

// Add UserRepository layer
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add AuthService layer
builder.Services.AddScoped<IAuthService, AuthService>();

// Add BCryptPasswordHasher
builder.Services.AddScoped<IPasswordHasher<User>, BCryptPasswordHasher<User>>();


// Add JsonOptions for better readability of JSON responses in Swagger UI and Postman 
builder.Services.AddControllers().AddJsonOptions(options => 
{ 
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Use Serilog for logging
builder.Host.UseSerilog((context, configuration) => 
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Add CORS policies
app.UseCors(corsPolicyBuilder => corsPolicyBuilder
    .WithMethods("POST", "GET", "PUT", "DELETE")
    .WithHeaders("Accept", "Content-Type", "Origin")
    .WithOrigins("http://localhost:5124", "https://localhost:5124"));

// Add serilog middleware for logging
app.UseSerilogRequestLogging();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapGet("/", context => {
            context.Response.Redirect("swagger");
            return Task.CompletedTask;
        });
    });
}


app.MapControllers();

app.Run();