using Wolf.Domain.Users;

namespace Wolf.Application.Services.Authentication
{
    public record AuthenticationResult(
        User User,
        string Token);
}