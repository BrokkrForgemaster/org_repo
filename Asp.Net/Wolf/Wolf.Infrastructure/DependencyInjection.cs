using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Wolf.Application.Common.Interfaces.Services;
using Wolf.Infrastructure.Authentication.Services;
using Wolf.Application.Common.Interfaces.Persistence;
using Wolf.Infrastructure.Authentication;
using Microsoft.Extensions.Options;
using Wolf.Application.Common.Interfaces.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Wolf.Infrastructure.Services;
namespace Wolf.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configration)
        {
            services
                .AddAuth(configration)
                .AddPersistance();

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }

        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddDbContext<WolfDbContext>(options =>
                options.UseSqlServer("Server=sql-data;Database=BuberDinner;User Id=sa;Password=amiko123!;TrustServerCertificate=True"));

            services.AddScoped<IUserRepository, IUserRepository>();

            return services;
        }

        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            IConfiguration configration)
        {
            var jwtSettings = new JwtSettings();
            configration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });

            return services;
        }
    }
}