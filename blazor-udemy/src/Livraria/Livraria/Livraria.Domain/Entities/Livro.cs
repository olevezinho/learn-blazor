using System.ComponentModel.DataAnnotations;
using Livraria.Domain.Enums;

namespace Livraria.Domain.Entities;

public class Livro
{
    public Livro(int livroId, string? titulo, string? autor, 
        DateTime lancamento, string? capa, Editora editora, Categoria categoria)
    {
        LivroId = livroId;
        Titulo = titulo;
        Autor = autor;
        Lancamento = lancamento;
        Capa = capa;
        Editora = editora;
        Categoria = categoria;
    }

    public int LivroId { get; set; }
    
    [Required(ErrorMessage = "Insira o título do livro")]
    [StringLength(150)]
    public string? Titulo { get; set; }

    [Required(ErrorMessage = "Insira o autor do livro")]
    [StringLength(200)]
    public string? Autor { get; set; }
    
    [Required(ErrorMessage = "Insira a data de lançamento do livro")]
    public DateTime Lancamento { get; set; }
    
    [Required(ErrorMessage = "Insira a imagem de capa do livro")]
    [StringLength(200)]
    public string? Capa { get; set; }
    
    [Required]
    [EnumDataType(typeof(Editora), ErrorMessage = "Insira o editora do livro")]
    public Editora Editora { get; set; }
    
    [Required]
    [EnumDataType(typeof(Categoria), ErrorMessage = "Insira a categoria do livro")]
    public Categoria Categoria { get; set; }
}