using Wolf.Domain.Common.Models;
using Wolf.Domain.Users.ValueObjects;

namespace Wolf.Domain.Users
{
    public sealed class User : AggregateRoot<UserId, Guid>
    {
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public User(UserId id, string username, string email, string password, DateTime createdAt, DateTime updatedAt) : base(id)
        {

            Username = username;
            Email = email;
            Password = password;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static User Create(string username, string email, string password)
        {
            return new User(UserId.CreateUnique(), username, email, password, DateTime.UtcNow, DateTime.UtcNow);
        }
    }
}