using CA.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Persistence.Context
{
    public class AuctionContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<Auction> Auctions => Set<Auction>();
        public DbSet<Lot> Lots => Set<Lot>();
        public DbSet<Bid> Bids => Set<Bid>();
        public DbSet<Transaction> Transactions => Set<Transaction>();

        public AuctionContext(DbContextOptions<AuctionContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Lot>()
                .HasMany(l => l.Bids)
                .WithOne(b => b.Lot)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Car>()
                .HasMany(c => c.Lots)
                .WithOne(l => l.Car)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<User>()
                .HasMany(u => u.Transactions)
                .WithOne(t => t.User)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<User>()
                .HasMany(u => u.Bids)
                .WithOne(b => b.User)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<User>()
                .HasMany(u => u.Car)
                .WithOne(c => c.Seller)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Car>().Property<DateTime>("CreatedAt");
            builder.Entity<Car>().Property<DateTime>("UpdatedAt");

            builder.Entity<Auction>().Property<DateTime>("CreatedAt");
            builder.Entity<Auction>().Property<DateTime>("UpdatedAt");

            builder.Entity<Lot>().Property<DateTime>("CreatedAt");
            builder.Entity<Lot>().Property<DateTime>("UpdatedAt");

            builder.Entity<Transaction>().Property<DateTime>("UpdatedAt");

            builder.Entity<Bid>().Property<DateTime>("UpdatedAt");

            builder.Entity<User>().Property<DateTime>("CreatedAt");
            builder.Entity<User>().Property<DateTime>("UpdatedAt");
            builder.Entity<User>().Property<bool>("IsDeleted");
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e =>
                    e.State == EntityState.Modified
                    || e.State == EntityState.Added)
                .Where(e =>
                    e.Properties.Where(p => 
                        p.Metadata.Name == "UpdatedAt" || p.Metadata.Name == "CreatedAt").Any());

            if (!entries.Any())
                return await base.SaveChangesAsync(cancellationToken);

            foreach (var entityEntry in entries)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Modified:
                        entityEntry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entityEntry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
