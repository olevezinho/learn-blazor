using BlazorFormsSection5.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorFormsSection5.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasData(
                new Product
                {
                    Id = 1,
                    Name = "Apple Keyboard iPad",
                    Description = "Apple Smart Keyboard iPad"
                },
                new Product
                {
                    Id = 2,
                    Name = "Apple iPhone 15",
                    Description = "Apple iPhone 1 64GB"
                }
            );
    }
}