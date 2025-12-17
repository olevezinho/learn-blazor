using System.ComponentModel.DataAnnotations;

namespace BlazorShop.API.Entities;

public class Categoria
{
    public int Id { get; set; }
    
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;
    
    public string IconCSS { get; set; } = string.Empty;

    public ICollection<Produto> Produtos { get; set; } = [];
}