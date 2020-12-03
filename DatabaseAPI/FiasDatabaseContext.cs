using DatabaseAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI
{
    public class FiasDatabaseContext : IdentityDbContext<User, Role, string>
    {
        public FiasDatabaseContext(DbContextOptions<FiasDatabaseContext> options)
        :base(options)
        {
            var a = new DataInitializer();
            a.Go();

        }

        public DbSet<AddressObject> AddressObjects { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Developer> Developers { get; set; }
    }
}
