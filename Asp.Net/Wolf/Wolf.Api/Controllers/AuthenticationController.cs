using Microsoft.AspNetCore.Mvc;
using Wolf.Application.Services;
using Wolf.Application.Services.Authentication;
using Wolf.Contracts.Authentication;

namespace Wolf.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {

         private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            AuthenticationResult authResult = _authenticationService.Register(
                request.Username,
                request.Email,
                request.Password);

            AuthenticationResponse response = new AuthenticationResponse(
                authResult.Id,
                authResult.Username,
                authResult.Email,
                authResult.Token);

            return Ok(response);
            
        }
        
        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            AuthenticationResult authResult = _authenticationService.Login(
                request.Email,
                request.Password);

            AuthenticationResponse response = new AuthenticationResponse(
                authResult.Id,
                authResult.Username,
                authResult.Email,
                authResult.Token);
                
            return Ok(response);
        }
    }
}