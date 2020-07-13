using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersTask.Models
{
    public class customerDbContext : DbContext
    {
        public customerDbContext(DbContextOptions<customerDbContext> options) : base(options)
        {

        }

        public DbSet<customer> Customers { get; set; }
        public DbSet<country> Countries { get; set; }
        public DbSet<government> Governments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<country>()
                .HasMany(g => g.Governments)
                .WithOne(c => c.Country)
                .HasForeignKey(x => x.countryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<government>()
                .HasMany(c => c.Customers)
                .WithOne(g => g.Government)
                .HasForeignKey(x => x.governmentId)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
