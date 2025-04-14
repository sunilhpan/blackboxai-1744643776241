using InvoiceApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships
        modelBuilder.Entity<PurchaseOrder>()
            .HasMany(p => p.Items)
            .WithOne();

        // Configure decimal precision
        modelBuilder.Entity<InventoryItem>()
            .Property(i => i.Price)
            .HasPrecision(18, 2);
            
        modelBuilder.Entity<Transaction>()
            .Property(t => t.Amount)
            .HasPrecision(18, 2);
    }
}
