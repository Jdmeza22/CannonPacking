
using CannonPacking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CannonPacking.Infrastructure.Persistence;

public class PackingDbContext(DbContextOptions<PackingDbContext> options) : DbContext(options)
{
    public DbSet<Towel> Towels => Set<Towel>();
    public DbSet<Box> Boxes => Set<Box>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Towel>(entity =>
        {

            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id)
                .ValueGeneratedNever();
            entity.Property(x => x.ItemCode)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(x => x.ProductCode)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(x => x.Status)
                .IsRequired();
            entity.Property(x => x.IsActive)
                .IsRequired();
            entity.HasIndex(x => x.ItemCode)
                .IsUnique();
            entity.HasOne(x => x.Box)
                .WithMany(b => b.Towels)
                .HasForeignKey(x => x.BoxId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Box>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id)
                    .ValueGeneratedNever();
                entity.Property(x => x.BoxCode)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(x => x.ProductCode)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(x => x.Capacity)
                    .IsRequired();
                entity.Property(x => x.Status)
                    .IsRequired();
                entity.Property(x => x.IsActive)
                    .IsRequired();
                entity.HasIndex(x => x.BoxCode)
                    .IsUnique();
            });
        });
    }
}
