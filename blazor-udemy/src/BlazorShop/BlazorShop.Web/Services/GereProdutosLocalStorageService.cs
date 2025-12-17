using Blazored.LocalStorage;
using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services;

public class GereProdutosLocalStorageService : IGereProdutosLocalStorageService
{
    private const string LocalStorageKey = "ProdutoCollection";
    private readonly IProdutoService _produtoService;
    private readonly ILocalStorageService _localStorageService; 

    public GereProdutosLocalStorageService(IProdutoService produtoService, ILocalStorageService localStorageService)
    {
        _produtoService = produtoService;
        _localStorageService = localStorageService;
    }

    public async Task<IEnumerable<ProdutoDto>> GetProdutosLocalStorageAsync()
    {
        return await _localStorageService.GetItemAsync<IEnumerable<ProdutoDto>>(LocalStorageKey) ?? 
               await AddCollectionAsync();
    }

    public async Task RemoveProdutosLocalStorageAsync()
    {
        await _localStorageService.RemoveItemAsync(LocalStorageKey);
    }

    private async Task<IEnumerable<ProdutoDto>> AddCollectionAsync()
    {
        var produtoCollection = await _produtoService.GetAllAsync();
        if (produtoCollection is not null)
        {
            await _localStorageService.SetItemAsync(LocalStorageKey, produtoCollection);
        }

        return produtoCollection;
    }
}