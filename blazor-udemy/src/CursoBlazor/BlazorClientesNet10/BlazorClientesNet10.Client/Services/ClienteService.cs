using System.Net.Http.Json;
using System.Text.Json;
using BlazorClientesNet10.Shared.Entities;
using BlazorClientesNet10.Shared.Interfaces;

namespace BlazorClientesNet10.Client.Services;

public class ClienteService : IClienteRepository
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public ClienteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<Cliente> AddClienteAsync(Cliente model)
    {
        var cliente = await _httpClient.PostAsJsonAsync("api/clientes/add", model);
        var responseContent = await cliente.Content.ReadFromJsonAsync<Cliente>();
        return responseContent!;
    }

    public async Task<Cliente> UpdateClienteAsync(Cliente model)
    {
        var request = await _httpClient.PutAsJsonAsync("api/clientes/update", model);
        var response = await request.Content.ReadFromJsonAsync<Cliente>();
        return response!;
    }

    public async Task<Cliente> DeleteClientAsync(int id)
    {
        var request = await _httpClient.DeleteAsync($"api/clientes/{id}");
        var response = await request.Content.ReadFromJsonAsync<Cliente>();
        return response!;
    }

    public async Task<List<Cliente>> GetAllClientesAsync()
    {
        var request = await _httpClient.GetAsync("api/clientes");
        request.EnsureSuccessStatusCode();
        var response = await request.Content.ReadFromJsonAsync<List<Cliente>>();
        return response!;
    }

    public async Task<Cliente> GetClientesByIdAsync(int id)
    {
        var request = await _httpClient.GetAsync($"api/clientes/{id}");
        request.EnsureSuccessStatusCode();
        var response = await request.Content.ReadFromJsonAsync<Cliente>();
        return response!;
    }
    
}