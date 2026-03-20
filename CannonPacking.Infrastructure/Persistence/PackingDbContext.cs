
using CannonPacking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CannonPacking.Infrastructure.Persistence;

public class PackingDbContext(DbContextOptions<PackingDbContext> options) : DbContext(options)
{
    public DbSet<Towel> Towels => Set<Towel>();
    public DbSet<Box> Boxes => Set<Box>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Towel>()
            .HasIndex(x => x.ItemCode)
            .IsUnique();

        modelBuilder.Entity<Box>()
            .HasIndex(x => x.BoxCode)
            .IsUnique();
    }
}
