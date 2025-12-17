using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoDto>> GetAllAsync();
    Task<ProdutoDto> GetByIdAsync(int id);
    Task<IEnumerable<CategoriaDto>> GetCategoriasAsync();
    Task<IEnumerable<ProdutoDto>> GetItensPorCategoriaAsync(int categoriaId);
}