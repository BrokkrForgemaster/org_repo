using Microsoft.Extensions.DependencyInjection;
using Wolf.Application.Services;
using Wolf.Application.Services.Authentication;

namespace Wolf.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}