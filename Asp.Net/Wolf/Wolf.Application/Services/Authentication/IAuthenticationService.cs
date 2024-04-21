using Wolf.Application.Services.Authentication;

namespace Wolf.Application.Services
{
    public interface IAuthenticationService
    {
        AuthenticationResult Login(string username, string password);
        AuthenticationResult Register(string username, string email, string password);
        
    }
}