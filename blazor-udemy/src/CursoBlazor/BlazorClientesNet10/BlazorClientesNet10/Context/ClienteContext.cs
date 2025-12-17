using BlazorClientesNet10.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorClientesNet10.Context;

public class ClienteContext : DbContext
{
    public ClienteContext(DbContextOptions<ClienteContext> options) : base(options) { }
        
    public DbSet<Cliente> Clientes => Set<Cliente>();
}