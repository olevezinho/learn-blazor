namespace BlazorShop.API.Entities;

public class Carrinho
{
    public int Id { get; set; }
    public int UtilizadorId { get; set; }
    
    public ICollection<CarrinhoItem> Itens { get; set; } = [];
}