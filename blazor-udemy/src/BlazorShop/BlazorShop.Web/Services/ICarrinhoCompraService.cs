using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services;

public interface ICarrinhoCompraService
{
    Task<List<CarrinhoItemDto>> GetCarrinhoItensUtilizadorAsync(int utilizadorId);
    Task<CarrinhoItemDto> AdicionaItemAsync(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);
    Task<CarrinhoItemDto> RemoveItemAsync(int id);
    Task<CarrinhoItemDto> AtualizaQuantidadeAsync(CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto);
    event Action<int> OnCarrinhoCompraChanged;
    void RaiseEventOnCarrinhoCompraChanged(int totalQuantidade);
}