using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Core.Domain;

namespace ParkingApp.Infrastructure.Database
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(x => x.ParkingSpot)
                .WithOne(x => x.User)
                .HasForeignKey<ParkingSpot>(x => x.UserId);

            builder.Entity<User>()
                .HasOne(x => x.Transaction)
                .WithOne(x => x.User)
                .HasForeignKey<Transaction>(x => x.UserId);

            base.OnModelCreating(builder);
        }

        public DbSet<ParkingLot> ParkingLots { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
