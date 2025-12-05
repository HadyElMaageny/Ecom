using System.Text;
using Ecom.Core.Entities;
using Ecom.Core.Interfaces;
using Ecom.Core.Services;
using Ecom.Infrastructure.Data;
using Ecom.Infrastructure.Repositories;
using Ecom.Infrastructure.Repositories.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;

namespace Ecom.Infrastructure;

public static class InfrastructureRegistration
{
    public static IServiceCollection InfrastructureConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        // services.AddScoped<ICategoryRepository, CategoryRepository>();
        // services.AddScoped<IProductRepository, ProductRepository>();
        // services.AddScoped<IPhotoRepository, PhotoRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        // register email sender
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IGenerateToken, GenerateToken>();
        services.AddSingleton<IImageManagementService, ImageManagementService>();
        services.AddSingleton<IFileProvider>(
            new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
        // Apply DbContext
        services.AddDbContext<AppDbContext>(op =>
        {
            op.UseSqlServer(configuration.GetConnectionString("EcomDatabase"));
        });

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.Cookie.Name = "token";
                options.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return Task.CompletedTask;
                    }
                };
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Secret"]!)),

                    ValidateIssuer = true,
                    ValidIssuer = configuration["Token:Issuer"],

                    ValidateAudience = false,
                    
                    ClockSkew = TimeSpan.Zero
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["token"];
                        return Task.CompletedTask;
                    }
                };
            });
        return services;
    }
}