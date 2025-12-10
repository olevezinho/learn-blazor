using BlazorUploadsSSR.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorUploadsSSR.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    { }
    public DbSet<FicheiroUpload> FicheirosUploads { get; set; }
}