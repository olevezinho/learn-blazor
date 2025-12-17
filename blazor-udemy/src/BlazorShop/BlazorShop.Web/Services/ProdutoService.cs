using BlazorShop.Models.DTOs;
using System.Net.Http.Json;

namespace BlazorShop.Web.Services;

public class ProdutoService : IProdutoService
{
    public ProdutoService(ILogger<ProdutoService> logger, HttpClient httpClient)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(httpClient);
        
        _logger = logger;
        _httpClient = httpClient;
    }
 
    private readonly HttpClient _httpClient;
    private ILogger<ProdutoService> _logger { get; }
    
    public async Task<IEnumerable<ProdutoDto>> GetAllAsync()
    {
        try
        {
            var produtosDto = await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoDto>>("api/produtos");
            return produtosDto;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, "Erro ao aceder aos produtos");
            throw;
        }
    }

    public async Task<ProdutoDto> GetByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/produtos/{id}");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return null;
                }
                
                return await response.Content.ReadFromJsonAsync<ProdutoDto>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                _logger.LogError($"Erro ao obter o produto com id '{id}' - '{message}'.");
                throw new Exception($"Status code : {response.StatusCode} - {message}.");
            }
                
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, $"Erro ao aceder ao produto com id '{id}'!");
            throw;
        }
    }

    public async Task<IEnumerable<CategoriaDto>> GetCategoriasAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/produtos/getcategorias");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return [];
                }
                
                return await response.Content.ReadFromJsonAsync<IEnumerable<CategoriaDto>>();
            }

            var message = await response.Content.ReadAsStringAsync();
            _logger.LogError($"Erro ao obter categorias - {message}'.");
            throw new Exception($"Status code : {response.StatusCode} - {message}.");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, "Erro ao obter as categorias.");
            throw;
        }
    }

    public async Task<IEnumerable<ProdutoDto>> GetItensPorCategoriaAsync(int categoriaId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/produtos/getitensporcategoria/{categoriaId}");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return [];
                }
                
                return await response.Content.ReadFromJsonAsync<IEnumerable<ProdutoDto>>();
            }

            var message = await response.Content.ReadAsStringAsync();
            _logger.LogError($"Erro ao obter produtos da categoria {categoriaId} - {message}'.");
            throw new Exception($"Status code : {response.StatusCode} - {message}.");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, "Erro ao obter produtos por categoria.");
            throw;
        }
    }
}