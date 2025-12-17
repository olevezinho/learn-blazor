using BlazorQuickGridEF.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorQuickGridEF.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options) { }
    
    public DbSet<Equipa> Equipas => Set<Equipa>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipa>().HasData(
            new Equipa
            {
                Id = 1,
                Nome = "FC Porto",
                Pontos = 76,
                Jogos = 30,
                Vitorias = 24,
                Empates = 4,
                Derrotas = 2,
                SaldoGolos = 45,
                GolosPro = 70,
                Status = "Campeão",
                TemChampions = true
            },
            new Equipa
            {
                Id = 2,
                Nome = "SL Benfica",
                Pontos = 70,
                Jogos = 30,
                Vitorias = 22,
                Empates = 4,
                Derrotas = 4,
                SaldoGolos = 40,
                GolosPro = 65,
                Status = "Liga dos Campeões",
                TemChampions = true
            },
            new Equipa
            {
                Id = 3,
                Nome = "Sporting CP",
                Pontos = 65,
                Jogos = 30,
                Vitorias = 20,
                Empates = 5,
                Derrotas = 5,
                SaldoGolos = 30,
                GolosPro = 60,
                Status = "Liga dos Campeões",
                TemChampions = false
            },
            new Equipa
            {
                Id = 4,
                Nome = "SC Braga",
                Pontos = 60,
                Jogos = 30,
                Vitorias = 18,
                Empates = 6,
                Derrotas = 6,
                SaldoGolos = 25,
                GolosPro = 55,
                Status = "Liga Europa",
                TemChampions = false
            },
            new Equipa
            {
                Id = 5,
                Nome = "Vitória SC",
                Pontos = 50,
                Jogos = 30,
                Vitorias = 15,
                Empates = 5,
                Derrotas = 10,
                SaldoGolos = 10,
                GolosPro = 45,
                Status = "Liga Europa",
                TemChampions = false
            },
            new Equipa
            {
                Id = 6,
                Nome = "Boavista FC",
                Pontos = 40,
                Jogos = 30,
                Vitorias = 12,
                Empates = 4,
                Derrotas = 14,
                SaldoGolos = -5,
                GolosPro = 35,
                Status = "Liga Europa",
                TemChampions = false
            },
            new Equipa
            {
                Id = 7,
                Nome = "CD Tondela",
                Pontos = 30,
                Jogos = 30,
                Vitorias = 8,
                Empates = 6,
                Derrotas = 16,
                SaldoGolos = -20,
                GolosPro = 25,
                Status = "Manutenção",
                TemChampions = false
            },
            new Equipa
            {
                Id = 8,
                Nome = "GD Chaves",
                Pontos = 25,
                Jogos = 30,
                Vitorias = 6,
                Empates = 7,
                Derrotas = 17,
                SaldoGolos = -25,
                GolosPro = 20,
                Status = "Manutenção",
                TemChampions = false
            },
            new Equipa
            {
                Id = 9,
                Nome = "FC Arouca",
                Pontos = 20,
                Jogos = 30,
                Vitorias = 5,
                Empates = 5,
                Derrotas = 20,
                SaldoGolos = -30,
                GolosPro = 15,
                Status = "Manutenção",
                TemChampions = false
            },
            new Equipa
            {
                Id = 10,
                Nome = "CD Nacional",
                Pontos = 15,
                Jogos = 30,
                Vitorias = 4,
                Empates = 3,
                Derrotas = 23,
                SaldoGolos = -35,
                GolosPro = 10,
                Status = "Manutenção",
                TemChampions = false
            },
            new Equipa()
            {
                Id = 11,
                Nome = "Casa Pia AC",
                Pontos = 28,
                Jogos = 30,
                Vitorias = 7,
                Empates = 7,
                Derrotas = 16,
                SaldoGolos = -18,
                GolosPro = 22,
                Status = "Manutenção",
                TemChampions = false
            },
            new Equipa()
            {
                Id = 12,
                Nome = "FC Famalicão",
                Pontos = 33,
                Jogos = 30,
                Vitorias = 9,
                Empates = 6,
                Derrotas = 15,
                SaldoGolos = -12,
                GolosPro = 30,
                Status = "Manutenção",
                TemChampions = false
            },
            new Equipa()
            {
                Id = 13,
                Nome = "Rio Ave FC",
                Pontos = 38,
                Jogos = 30,
                Vitorias = 11,
                Empates = 5,
                Derrotas = 14,
                SaldoGolos = -8,
                GolosPro = 33,
                Status = "Manutenção",
                TemChampions = false
            },
            new Equipa()
            {
                Id = 14,
                Nome = "Marítimo CS",
                Pontos = 22,
                Jogos = 30,
                Vitorias = 6,
                Empates = 4,
                Derrotas = 20,
                SaldoGolos = -28,
                GolosPro = 18,
                Status = "Manutenção",
                TemChampions = false
            },
            new Equipa()
            {
                Id = 15,
                Nome = "Moreirense FC",
                Pontos = 35,
                Jogos = 30,
                Vitorias = 10,
                Empates = 5,
                Derrotas = 15,
                SaldoGolos = -10,
                GolosPro = 28,
                Status = "Manutenção",
                TemChampions = false
            },
            new Equipa()
            {
                Id = 16,
                Nome = "FC Paços de Ferreira",
                Pontos = 27,
                Jogos = 30,
                Vitorias = 7,
                Empates = 6,
                Derrotas = 17,
                SaldoGolos = -22,
                GolosPro = 21,
                Status = "Descida",
                TemChampions = false
            },
            new Equipa()
            {
                Id = 17,
                Nome = "SC Farense",
                Pontos = 29,
                Jogos = 30,
                Vitorias = 8,
                Empates = 5,
                Derrotas = 17,
                SaldoGolos = -19,
                GolosPro = 24,
                Status = "Descida",
                TemChampions = false
            },
            new Equipa()
            {
                Id = 18,
                Nome = "CD Santa Clara",
                Pontos = 31,
                Jogos = 30,
                Vitorias = 9,
                Empates = 4,
                Derrotas = 17,
                SaldoGolos = -15,
                GolosPro = 26,
                Status = "Descida",
                TemChampions = false
            }
        );
    }
}