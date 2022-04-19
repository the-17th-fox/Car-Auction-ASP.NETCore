using CA.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Persistence.Context
{
    public class AuctionContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        // Add shadow property for the user: account created at, updated at

        public AuctionContext(DbContextOptions<AuctionContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Car>().Property<DateTime>("CreatedAt");
            builder.Entity<Car>().Property<DateTime>("UpdatedAt");

            builder.Entity<User>().Property<DateTime>("CreatedAt");
            builder.Entity<User>().Property<DateTime>("UpdatedAt");
        }
    }
}
