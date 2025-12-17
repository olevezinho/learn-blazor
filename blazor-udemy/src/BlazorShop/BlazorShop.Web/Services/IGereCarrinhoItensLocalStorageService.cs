using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services;

public interface IGereCarrinhoItensLocalStorageService
{
    Task<List<CarrinhoItemDto>> GetCarrinhoItemsLocalStorageAsync();
    Task GuardaCarrinhoItensLocalStorageAsync(List<CarrinhoItemDto> carrinhoItensDto);
    Task RemoveCarrinhoItensLocalStorageAsync();
}