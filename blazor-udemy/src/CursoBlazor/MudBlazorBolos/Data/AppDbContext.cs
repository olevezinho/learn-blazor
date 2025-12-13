using Microsoft.EntityFrameworkCore;

namespace MudBlazorBolos.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Bolo> Bolos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bolo>()
            .HasData(
                new Bolo
                {
                    Id = 1,
                    Nome = "Pastel de Nata",
                    Descricao = "Um bolo tipico português",
                    Preco = 3.5m,
                    ImagemUrl = "https://www.rissolariatradicional.com/wp-content/uploads/2020/11/1-Pastel-de-Nata-centrado.jpg"
                },
                new Bolo
                {
                    Id = 2,
                    Nome = "Croissant",
                    Descricao = "Um bolo tipico frances",
                    Preco = 7.5m,
                    ImagemUrl = "https://upload.wikimedia.org/wikipedia/commons/2/2a/Croissant-Petr_Kratochvil.jpg"
                },
                new Bolo
                {
                    Id = 3,
                    Nome = "Pão de ló",
                    Descricao = "Um bolo tipico de felgueiras",
                    Preco = 17.5m,
                    ImagemUrl = "https://merceariadeportugal.com/cdn/shop/products/PAO_DE_LO_INDIVIDUAL_800x.png"
                },
                new Bolo
                {
                    Id = 4,
                    Nome = "Jesuíta",
                    Descricao = "Um bolo tipico português",
                    Preco = 17.5m,
                    ImagemUrl = "https://www.fabricoproprio.net/c/wp-content/uploads/2022/11/38_jesuita.jpg"
                });
    }
}