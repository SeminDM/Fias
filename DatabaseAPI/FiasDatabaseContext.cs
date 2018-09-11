using DatabaseAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI
{
    public class FiasDatabaseContext : IdentityDbContext<User, Role, string>
    {
        public FiasDatabaseContext(DbContextOptions<FiasDatabaseContext> options)
        :base(options)
        {}

        public DbSet<AddressObject> AddressObjects { get; set; }
    }
}
