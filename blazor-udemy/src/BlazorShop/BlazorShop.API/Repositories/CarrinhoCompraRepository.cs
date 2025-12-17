using BlazorShop.API.Context;
using BlazorShop.API.Entities;
using BlazorShop.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.API.Repositories;

public class CarrinhoCompraRepository : ICarrinhoCompraRepository
{
    private readonly AppDbContext _context;

    public CarrinhoCompraRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CarrinhoItem> AddItemAsync(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
    {
        if (!await CarrinhoItemJaExisteAsync(carrinhoItemAdicionaDto.CarrinhoId, carrinhoItemAdicionaDto.ProdutoId))
        {
            var item = await
                (from produto in _context.Produtos
                    where produto.Id == carrinhoItemAdicionaDto.ProdutoId
                    select new CarrinhoItem
                    {
                        CarrinhoId = carrinhoItemAdicionaDto.CarrinhoId,
                        ProdutoId = produto.Id,
                        Quantidade = carrinhoItemAdicionaDto.Quantidade
                    }).SingleOrDefaultAsync();

            if (item is not null)
            {
                var result = await _context.CarrinhoItens.AddAsync(item);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
        }

        return null;
    }

    public async Task<CarrinhoItem> AtualizaQuantidadeAsync(int id, CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto)
    {
        var carrinhoItem = await _context.CarrinhoItens.FindAsync(id);
        if (carrinhoItem is not null)
        {
            carrinhoItem.Quantidade = carrinhoItemAtualizaQuantidadeDto.Quantidade;
            await _context.SaveChangesAsync();
            return carrinhoItem;
        }

        return null;
    }

    public async Task<CarrinhoItem> RemoveItemAsync(int id)
    {
        var item = await _context.CarrinhoItens.FindAsync(id);
        if (item is not null)
        {
            _context.CarrinhoItens.Remove(item);
            await _context.SaveChangesAsync();
        }
        
        return item;
    }

    public async Task<CarrinhoItem> GetItemByIdAsync(int id)
    {
        return (await
                (from carrinho in _context.Carrinhos
                join carrinhoItem in _context.CarrinhoItens
                on carrinho.Id equals carrinhoItem.CarrinhoId
                where carrinho.Id == id
                select new CarrinhoItem
                {
                    Id = carrinhoItem.Id,
                    ProdutoId = carrinhoItem.ProdutoId,
                    Quantidade = carrinhoItem.Quantidade,
                    CarrinhoId = carrinhoItem.CarrinhoId
                }).SingleOrDefaultAsync())!;
    }

    public async Task<IEnumerable<CarrinhoItem>> GetAllUtilizadorItemsAsync(int utilizadorId)
    {
        return await
            (from carrinho in _context.Carrinhos
            join carrinhoItem in _context.CarrinhoItens
            on carrinho.Id equals carrinhoItem.CarrinhoId
            where carrinho.UtilizadorId == utilizadorId
            select new CarrinhoItem
            {
                Id = carrinhoItem.Id,
                ProdutoId = carrinhoItem.ProdutoId,
                Quantidade = carrinhoItem.Quantidade,
                CarrinhoId = carrinhoItem.CarrinhoId
            }).ToListAsync();
    }
    
    private async Task<bool> CarrinhoItemJaExisteAsync(int carrinhoId, int produtoId)
    {
        return await _context.CarrinhoItens.AnyAsync(c => 
            c.CarrinhoId == carrinhoId &&
            c.ProdutoId == produtoId);
    }
}