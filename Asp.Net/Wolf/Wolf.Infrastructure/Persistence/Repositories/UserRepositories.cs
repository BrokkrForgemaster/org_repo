using Wolf.Application.Common.Interfaces.Persistence;
using Wolf.Domain.Users;

namespace Wolf.Infrastructure.Persistence.Repositories
{
    public class UserRepositories : IUserRepository
    {
        private static readonly List<User> _users = new();

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }

        public void Add(User user)
        {
            _users.Add(user);
        }
    }
}