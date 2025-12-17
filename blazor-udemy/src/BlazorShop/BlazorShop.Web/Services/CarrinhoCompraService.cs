using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services;

public class CarrinhoCompraService : ICarrinhoCompraService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<CarrinhoCompraService> _logger;

    public CarrinhoCompraService(HttpClient httpClient, ILogger<CarrinhoCompraService> logger)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(httpClient);
        
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<List<CarrinhoItemDto>> GetCarrinhoItensUtilizadorAsync(int utilizadorId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/carrinhocompras/{utilizadorId}/itens");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return [];
                }
                
                return await response.Content.ReadFromJsonAsync<List<CarrinhoItemDto>>();
            }

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http Status Code: {response.StatusCode}, Message: {message}.");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, "Erro ao aceder aos items.");
            throw;
        }
    }

    public async Task<CarrinhoItemDto> AdicionaItemAsync(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/carrinhocompras", carrinhoItemAdicionaDto);
            
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return null;
                }
                
                return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();
            }
            
            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http Status Code: {response.StatusCode}, Message: {message}.");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, "Erro ao adicionar aos items.");
            throw;
        }
    }

    public async Task<CarrinhoItemDto> RemoveItemAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/carrinhocompras/{id}");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return null;
                }
                
                return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();
            }
            
            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http Status Code: {response.StatusCode}, Message: {message}.");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, $"Erro ao remover item {id} dos itens do carrinho.");
            throw;
        }
    }

    public async Task<CarrinhoItemDto> AtualizaQuantidadeAsync(CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto)
    {
        try
        {
            var jsonRequest = JsonSerializer.Serialize(carrinhoItemAtualizaQuantidadeDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PatchAsync($"api/carrinhocompras/{carrinhoItemAtualizaQuantidadeDto.CarrinhoItemId}", content);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();
            }
            
            return null;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, $"Erro ao remover atualizar a quantidade do item {carrinhoItemAtualizaQuantidadeDto.CarrinhoItemId} no carrinho.");
            throw;
        }
    }

    public event Action<int>? OnCarrinhoCompraChanged;
    
    public void RaiseEventOnCarrinhoCompraChanged(int totalQuantidade)
    {
        if (OnCarrinhoCompraChanged is not null)
        {
            OnCarrinhoCompraChanged.Invoke(totalQuantidade);
        }
    }
}