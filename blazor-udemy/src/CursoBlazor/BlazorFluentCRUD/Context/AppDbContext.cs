using Microsoft.EntityFrameworkCore;

namespace BlazorFluentCRUD.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Aluno> Alunos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>()
            .HasData(
                new Aluno
                {
                    Id = 1,
                    Nome = "Luis",
                    Email = "lfilipecosta3@gmail.com",
                    Idade = 31,
                    Foto = "/fotos/profile.jpg"
                },
                new Aluno
                {
                    Id = 2,
                    Nome = "John Lennon",
                    Email = "johnlennon@ceu.net",
                    Idade = 31,
                    Foto = "/fotos/profile-lennon.jpg"
                },
                new Aluno
                {
                    Id = 3,
                    Nome = "Ozzy",
                    Email = "ozzy@ceu.net",
                    Idade = 78,
                    Foto = "/fotos/profile-ozzy.jpg"
                },
                new Aluno
                {
                    Id = 4,
                    Nome = "Amy",
                    Email = "amy@ceu.net",
                    Idade = 27,
                    Foto = "/fotos/profile-amy.jpg"
                });
    }
}