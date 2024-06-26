using Wolf.Application.Common.Interfaces.Services;

namespace Wolf.Infrastructure.Authentication.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}