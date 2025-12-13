using Microsoft.EntityFrameworkCore;
using MudBlazorAlunos.Entities;

namespace MudBlazorAlunos.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Aluno> Alunos { get; set; }
}