using Microsoft.VisualBasic;
using Wolf.Application.Common.Interfaces.Authentication;

namespace Wolf.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }
              public AuthenticationResult Register(string username, string email, string password)
        {
            // Check if user already exists

            // Create user (generate uniquie id)

            // Create JWT token
            Guid userId = Guid.NewGuid();
            string token = _jwtTokenGenerator.GenerateToken(
                userId,
                username,
                email);      
                   
            return new AuthenticationResult(
                Guid.NewGuid(),
                username,
                email,
                token);
        }
        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                "username", 
                email,
                "token");
        }

    }
}