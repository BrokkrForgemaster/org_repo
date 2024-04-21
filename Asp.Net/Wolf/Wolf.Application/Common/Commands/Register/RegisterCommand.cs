using ErrorOr;
using MediatR;
using Wolf.Application.Services.Authentication;

namespace Wolf.Application.Common.Commands.Register
{
    public record RegisterCommand(
    string Username,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}