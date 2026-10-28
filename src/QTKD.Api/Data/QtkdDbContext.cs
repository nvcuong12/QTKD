using QtkdApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace QtkdApi.Data;

public class QtkdDbContext : DbContext
{
    public QtkdDbContext(DbContextOptions<QtkdDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Contract> Contracts => Set<Contract>();

    public DbSet<PriceList> PriceLists => Set<PriceList>();

    public DbSet<PriceItem> PriceItems => Set<PriceItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).HasMaxLength(256).IsRequired();
            entity.Property(c => c.Status).HasConversion<string>().HasMaxLength(32);
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.ContractNo).HasMaxLength(64).IsRequired();
            entity.HasIndex(c => c.ContractNo).IsUnique();
            entity.Property(c => c.Status).HasConversion<string>().HasMaxLength(32);
            entity.HasOne(c => c.Customer)
                .WithMany(customer => customer.Contracts)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<PriceList>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).HasMaxLength(256).IsRequired();
        });

        modelBuilder.Entity<PriceItem>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.ServiceCode).HasMaxLength(64).IsRequired();
            entity.Property(p => p.UnitPrice).HasPrecision(18, 2);
            entity.HasOne(p => p.PriceList)
                .WithMany(list => list.Items)
                .HasForeignKey(p => p.PriceListId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}