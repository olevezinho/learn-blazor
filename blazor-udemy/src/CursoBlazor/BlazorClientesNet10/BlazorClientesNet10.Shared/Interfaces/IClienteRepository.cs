using BlazorClientesNet10.Shared.Entities;

namespace BlazorClientesNet10.Shared.Interfaces;

public interface IClienteRepository
{
    Task<Cliente> AddClienteAsync(Cliente model);
    Task<Cliente> UpdateClienteAsync(Cliente model);
    Task<Cliente> DeleteClientAsync(int id);
    Task<List<Cliente>> GetAllClientesAsync();
    Task<Cliente> GetClientesByIdAsync(int id);
}