using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wolf.Application.Common.Interfaces.Authentication;
using Wolf.Application.Common.Interfaces.Services;
using Wolf.Infrastructure.Authentication;
using Wolf.Infrastructure.Authentication.Services;

namespace Wolf.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
    }
}