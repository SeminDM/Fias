using System;
using DatabaseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI
{
    public class FiasDatabaseContext : DbContext
    {
        public FiasDatabaseContext(DbContextOptions<FiasDatabaseContext> options)
        :base(options)
        {}

        public DbSet<AddressObject> AddressObjects { get; set; }
    }
}
