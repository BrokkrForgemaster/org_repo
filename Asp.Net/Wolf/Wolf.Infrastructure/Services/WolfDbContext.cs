using Microsoft.EntityFrameworkCore;
using Wolf.Domain.Users;

namespace Wolf.Infrastructure.Services;
    public sealed class WolfDbContext : DbContext
    {
        public WolfDbContext(
     DbContextOptions<WolfDbContext> options
 ) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
