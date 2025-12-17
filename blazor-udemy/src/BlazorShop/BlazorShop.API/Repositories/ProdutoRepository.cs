using BlazorShop.API.Context;
using BlazorShop.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.API.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Produto>> GetAllAsync()
    {
        if (_context.Produtos is not null) 
            return await _context.Produtos
                .Include(p => p.Categoria)
                .ToListAsync();

        return [];
    }

    public async Task<Produto> GetByIdAsync(int id)
    {
        var produto = await _context.Produtos
            .Include(p => p.Categoria)
            .SingleOrDefaultAsync(p => p.Id == id);

        return produto;
    }

    public async Task<IEnumerable<Produto>> GetByCategoriaAsync(int categoriaId)
    {
        if (_context.Produtos is not null) 
            return await _context.Produtos
                .Include(p => p.Categoria)
                .Where(p => p.CategoriaId == categoriaId)
                .ToListAsync();

        return [];
    }

    public async Task<IEnumerable<Categoria>> GetAllCategoriasAsync()
    {
        return await _context.Categorias.ToListAsync();
    }
}