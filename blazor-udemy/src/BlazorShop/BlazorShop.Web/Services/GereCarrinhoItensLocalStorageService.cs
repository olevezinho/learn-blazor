using Blazored.LocalStorage;
using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services;

public class GereCarrinhoItensLocalStorageService : IGereCarrinhoItensLocalStorageService
{
    public const string LocalStorageKey = "CarrinhoItemCollection";
    
    private readonly ILocalStorageService _localStorageService;
    private readonly ICarrinhoCompraService _carrinhoCompraService;

    public GereCarrinhoItensLocalStorageService(
        ILocalStorageService localStorageService, 
        ICarrinhoCompraService carrinhoCompraService)
    {
        _localStorageService = localStorageService;
        _carrinhoCompraService = carrinhoCompraService;
    }

    public async Task<List<CarrinhoItemDto>> GetCarrinhoItemsLocalStorageAsync()
    {
        return await _localStorageService.GetItemAsync<List<CarrinhoItemDto>>(LocalStorageKey) ??
               await AddCollectionAsync();
    }

    public async Task GuardaCarrinhoItensLocalStorageAsync(List<CarrinhoItemDto> carrinhoItensDto)
    {
        await _localStorageService.SetItemAsync(LocalStorageKey, carrinhoItensDto);
    }

    public async Task RemoveCarrinhoItensLocalStorageAsync()
    {
        await _localStorageService.RemoveItemAsync(LocalStorageKey);
    }

    private async Task<List<CarrinhoItemDto>> AddCollectionAsync()
    {
        var carrinhoCompraCollection =
            await _carrinhoCompraService.GetCarrinhoItensUtilizadorAsync(UtilizadorLogado.UtilizadorId);

        if (carrinhoCompraCollection is not null)
        {
            await _localStorageService.SetItemAsync(LocalStorageKey, carrinhoCompraCollection);
        }
        
        return carrinhoCompraCollection;
    }
}