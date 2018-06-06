using System;
using DatabaseAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI
{
    public class FiasDatabaseContext : IdentityDbContext<User>
    {
        public FiasDatabaseContext(DbContextOptions<FiasDatabaseContext> options)
        :base(options)
        {}

        public DbSet<AddressObject> AddressObjects { get; set; }
    }
}
