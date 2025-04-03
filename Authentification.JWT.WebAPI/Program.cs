using AutoMapper;
using Authentification.JWT.Service;
using Authentification.JWT.DAL.Entities;
using Authentification.JWT.DAL.Repositories;
using Authentification.JWT.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Authentification.JWT.WebAPI;
using Microsoft.OpenApi.Models;
using NLog;
using Authentification.JWT.Service.Logging;


var logger = LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();
try
{
    logger.Info("Application démarrée...");
    var builder = WebApplication.CreateBuilder(args);

    // Enregistrer les services nécessaires
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddOpenApi();

    // Ajouter les services JWT et autres services nécessaires
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("28cj02/B6IUzZKdqAV9af5j9SkTOpAuCzc9dbmL2kiA=")),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

    builder.Services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter the token",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
    });

    // Enregistrer le service `UserService` dans le conteneur de DI
    builder.Services.AddScoped<UserService>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<JwtService>(provider =>
    {
        var configuration = provider.GetRequiredService<IConfiguration>();
        var key = configuration.GetValue<string>("JwtSettings:Key");
        return new JwtService(key);
    });
    builder.Services.AddSingleton<ILoggerService, LoggerService>();

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

    // Enregistrer le profil de mappage AutoMapper
    builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

    // Configurer CORS (si nécessaire)
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins", builder =>
        {
            builder.AllowAnyOrigin()   // Autoriser toutes les origines (pour les tests)
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });

    var app = builder.Build();

    // Configurer les middlewares
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();
    app.MapControllers();
    app.UseHttpsRedirection();

    app.Run();

}

catch (Exception ex)
{
    logger.Error(ex, "L'application a planté au démarrage");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}

