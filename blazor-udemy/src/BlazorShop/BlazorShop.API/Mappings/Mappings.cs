using BlazorShop.API.Entities;
using BlazorShop.Models.DTOs;

namespace BlazorShop.API.Mappings;

public static class Mappings
{
    public static IEnumerable<CategoriaDto> ConverterCategoriasParaDto(this IEnumerable<Categoria> categorias) =>
        categorias.Select(categoria => new CategoriaDto
        {
            Id = categoria.Id,
            Nome =  categoria.Nome,
            IconCSS = categoria.IconCSS
        }).ToList();
    
    public static IEnumerable<ProdutoDto> ConverterProdutosParaDtos(this IEnumerable<Produto> produtos) =>
        produtos.Select(produto => new ProdutoDto
        {
            Id = produto.Id,
            Nome =  produto.Nome,
            CategoriaId = produto.Categoria.Id,
            CategoriaNome =  produto.Categoria.Nome,
            Descricao =  produto.Descricao,
            ImagemUrl =  produto.ImagemUrl,
            Preco =  produto.Preco,
            Quantidade =   produto.Quantidade
        }).ToList();

    public static ProdutoDto ConverterProdutoParaDto(this Produto produto) =>
        new ProdutoDto
        {
            Id = produto.Id,
            Nome = produto.Nome,
            CategoriaId = produto.Categoria.Id,
            CategoriaNome = produto.Categoria.Nome,
            Descricao = produto.Descricao,
            ImagemUrl = produto.ImagemUrl,
            Preco = produto.Preco,
            Quantidade = produto.Quantidade
        };
    
    public static IEnumerable<CarrinhoItemDto> ConverterCarrinhoItensParaDto(this IEnumerable<CarrinhoItem> carrinhoItens,
        IEnumerable<Produto> produtos)
    {
        return (from carrinhoItem in carrinhoItens
                join produto in produtos
                on carrinhoItem.ProdutoId equals produto.Id
                select new CarrinhoItemDto
                {
                    Id = carrinhoItem.Id,
                    ProdutoId = carrinhoItem.ProdutoId,
                    ProdutoNome = produto.Nome,
                    ProdutoDescricao = produto.Descricao,
                    ProdutoImagemUrl = produto.ImagemUrl,
                    Preco = produto.Preco,
                    CarrinhoId = carrinhoItem.CarrinhoId,
                    Quantidade = carrinhoItem.Quantidade,
                    PrecoTotal = produto.Preco * carrinhoItem.Quantidade
                }).ToList();
    }
    
    public static CarrinhoItemDto ConverterCarrinhoItemParaDto(this CarrinhoItem carrinhoItem,
        Produto produto)
    {
        return new CarrinhoItemDto
        {
            Id = carrinhoItem.Id,
            ProdutoId = carrinhoItem.ProdutoId,
            ProdutoNome = produto.Nome,
            ProdutoDescricao = produto.Descricao,
            ProdutoImagemUrl = produto.ImagemUrl,
            Preco = produto.Preco,
            CarrinhoId = carrinhoItem.CarrinhoId,
            Quantidade = carrinhoItem.Quantidade,
            PrecoTotal = produto.Preco * carrinhoItem.Quantidade
        };
    }
}