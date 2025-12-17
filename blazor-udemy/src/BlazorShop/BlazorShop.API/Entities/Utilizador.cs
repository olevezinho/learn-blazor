using System.ComponentModel.DataAnnotations;

namespace BlazorShop.API.Entities;

public class Utilizador
{
    public int Id { get; set; }
    
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;
    
    public Carrinho? Carrinho { get; set; }
}