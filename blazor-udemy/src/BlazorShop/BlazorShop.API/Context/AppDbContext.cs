using BlazorShop.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.API.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options) { }
    
    public DbSet<Carrinho>? Carrinhos { get; set; }
    public DbSet<CarrinhoItem>? CarrinhoItens { get; set; }
    public DbSet<Produto>? Produtos { get; set; }
    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Utilizador>? Utilizadores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Categorias
        modelBuilder.Entity<Categoria>()
            .HasData(
                new Categoria
                {
                    Id = 1,
                    Nome = "Beleza",
                    IconCSS = "fas fa-spa"
                },
                new Categoria
                {
                    Id = 2,
                    Nome = "Tecnologia",
                    IconCSS = "fas fa-spa"
                },
                new Categoria
                {
                    Id = 3,
                    Nome = "Leitura",
                    IconCSS = "fas fa-spa"
                }
            );
        
        // Produtos
        modelBuilder.Entity<Produto>()
            .HasData(
                new Produto
                {
                    Id = 1,
                    Nome = "Glossier - Kit de cuidados de pele",
                    Descricao = "Um kit fornecido pela natura, que contem produtos para cuidados com a pele",
                    ImagemUrl = "/Imagens/Beleza/Beleza1.png",
                    Preco = 100,
                    Quantidade = 100,
                    CategoriaId = 1
                },
                new Produto
                {
                    Id = 2,
                    Nome = "Smartphone Premium",
                    Descricao = "Um smartphone android, com uma usabilidade fantástica",
                    ImagemUrl = "/Imagens/Tecnologia/Smartphone1.png",
                    Preco = 300,
                    Quantidade = 100,
                    CategoriaId = 2
                },
                new Produto
                {
                    Id = 3,
                    Nome = "Livro - DDD",
                    Descricao = "Um livro sobre desenvolvimento de software",
                    ImagemUrl = "/Imagens/Leitura/Livro1.png",
                    Preco = 30,
                    Quantidade = 100,
                    CategoriaId = 3
                },
                new Produto
                {
                    Id = 4,
                    Nome = "Fones de ouvido",
                    Descricao = "Uns fones de ouvido para ouvir a melhor música",
                    ImagemUrl = "/Imagens/Tecnologia/Phones1.png",
                    Preco = 200,
                    Quantidade = 100,
                    CategoriaId = 3
                },
                new Produto
                {
                    Id = 5,
                    Nome = "Pad Mouse",
                    Descricao = "Um rato para computador",
                    ImagemUrl = "/Imagens/Tecnologia/Rato1.png",
                    Preco = 20,
                    Quantidade = 75,
                    CategoriaId = 3
                },
                new Produto
                {
                    Id = 6,
                    Nome = "Fone de Ouvido Bluetooth",
                    Descricao = "Uns fones de ouvido s/fio para ouvir a melhor música",
                    ImagemUrl = "/Imagens/Tecnologia/Phones2.png",
                    Preco = 250,
                    Quantidade = 100,
                    CategoriaId = 3
                }
            );
        
        // Utilizadores
        modelBuilder.Entity<Utilizador>()
            .HasData(
                new Utilizador
                {
                    Id = 1,
                    Nome = "Filipe"
                },
                new Utilizador
                {
                    Id = 2,
                    Nome = "Helena"
                }
            );
        
        // Carrinhos
        modelBuilder.Entity<Carrinho>()
            .HasData(
                new Carrinho
                {
                    Id = 1,
                    UtilizadorId = 1
                },
                new Carrinho
                {
                    Id = 2,
                    UtilizadorId = 2
                });
    }
}