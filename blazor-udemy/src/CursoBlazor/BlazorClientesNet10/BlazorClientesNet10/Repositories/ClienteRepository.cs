using BlazorClientesNet10.Context;
using BlazorClientesNet10.Shared.Entities;
using BlazorClientesNet10.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorClientesNet10.Repositories;

public class ClienteRepository : IClienteRepository
{
    private ClienteContext _context;

    public ClienteRepository(ClienteContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<Cliente> AddClienteAsync(Cliente model)
    {
        if (model is null) return null!;

        var check = await _context.Clientes
            .Where(c => c.Nome.ToLower().Equals(model.Nome.ToLower()))
            .FirstOrDefaultAsync();
        
        if (check is not null) return null!;
        
        var novoCliente = _context.Clientes.Add(model).Entity;
        await _context.SaveChangesAsync();
        return novoCliente;
    }

    public async Task<Cliente> UpdateClienteAsync(Cliente model)
    {
        if (model is null) return null!;

        var check = await _context.Clientes
            .Where(c => c.Nome.ToLower().Equals(model.Nome.ToLower()))
            .FirstOrDefaultAsync();
        
        if (check is not null) return null!;
        
        var novoCliente = _context.Clientes.Update(model).Entity;
        await _context.SaveChangesAsync();
        return novoCliente;
    }

    public async Task<Cliente> DeleteClientAsync(int id)
    {
        var cliente = await _context.Clientes
            .FirstOrDefaultAsync(c => c.Id == id);
        
        if(cliente is null) return null!;
        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<List<Cliente>> GetAllClientesAsync()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Cliente> GetClientesByIdAsync(int id)
    {
        var cliente = await _context.Clientes
            .FirstOrDefaultAsync(c => c.Id == id);

        if (cliente is null) return null!;
        return cliente;
    }
}