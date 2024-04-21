using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wolf.Application.Services.Authentication
{
    public record AuthenticationResult(
        Guid Id,
        string Username,
        string Email,
        string Token);
}