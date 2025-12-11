using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace BlazorAppDockerSqlServer.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        if (dbCreator is not null)
        {
            // Create Database
            if (!dbCreator.CanConnect())
            {
                dbCreator.Create();
            }
            
            // Create tables
            if (!dbCreator.HasTables())
            {
                dbCreator.CreateTables();
            }
        }
    }
    
    public DbSet<Contacto> Contactos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Contacto>()
            .HasData(
                new Contacto {
                    Id = 1,
                    Nome = "Luis Brochado",
                    Email = "lfilipecosta3@gmail.com"
                },
                new Contacto {
                    Id = 2,
                    Nome = "Lucas Dilauro",
                    Email = "lucasdilauro@gmail.com"
                },
                new Contacto {
                    Id = 3,
                    Nome = "José Primo",
                    Email = "zeprimo@gmail.com"
                });
        
        base.OnModelCreating(builder);
    }
}
