using System.ComponentModel.DataAnnotations;

namespace BlazorFormularios.Entities;

public class Aluno
{
    public int Id { get; set; }
    
    [Required(ErrorMessage =  "Informe o nome do Aluno")]
    [StringLength(50, ErrorMessage =  "O nome do Aluno deve ter no máximo 50 caracteres")]
    public string Nome { get; set; } = string.Empty;
    
    [Required(ErrorMessage =  "Informe o email do Aluno")]
    [EmailAddress(ErrorMessage =  "Informe um email válido")]
    public string Email { get; set; } = string.Empty;
    
    [Range(1, 120, ErrorMessage =  "A idade do Aluno deve estar entre 1 e 120")]
    public int Idade { get; set; }
    
    [Required(ErrorMessage =  "O género é obrigatório")]
    [RegularExpression("M|F", ErrorMessage = "O género deve ser 'M' ou 'F'")]
    public string Genero { get; set; } = string.Empty;
    
    [Required(ErrorMessage =  "A data da matrícula é obrigatória")]
    public DateTime Matricula { get; set; } = DateTime.Now;
    
    [Range(0, 5000, ErrorMessage =  "A mensalidade deve estar entre 0 e 5000")]
    public decimal Mensalidade { get; set; }

    public bool Ativo { get; set; }
}