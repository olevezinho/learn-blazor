using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services;

public interface IGereProdutosLocalStorageService
{
    Task<IEnumerable<ProdutoDto>> GetProdutosLocalStorageAsync();
    Task RemoveProdutosLocalStorageAsync();
}