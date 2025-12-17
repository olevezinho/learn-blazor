using BlazorShop.API.Entities;
using BlazorShop.Models.DTOs;

namespace BlazorShop.API.Repositories;

public interface ICarrinhoCompraRepository
{
    Task<CarrinhoItem> AddItemAsync(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);
    Task<CarrinhoItem> AtualizaQuantidadeAsync(int id, CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto);
    Task<CarrinhoItem> RemoveItemAsync(int id);
    Task<CarrinhoItem> GetItemByIdAsync(int id);
    Task<IEnumerable<CarrinhoItem>> GetAllUtilizadorItemsAsync(int utilizadorId);
}