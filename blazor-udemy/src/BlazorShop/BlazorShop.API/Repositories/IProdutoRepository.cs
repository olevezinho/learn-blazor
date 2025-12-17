using BlazorShop.API.Entities;

namespace BlazorShop.API.Repositories;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> GetAllAsync();
    Task<Produto> GetByIdAsync(int id);
    Task<IEnumerable<Produto>> GetByCategoriaAsync(int categoriaId);
    Task<IEnumerable<Categoria>> GetAllCategoriasAsync();
}