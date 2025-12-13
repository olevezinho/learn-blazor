using System.ComponentModel.DataAnnotations;

namespace MudBlazorGraficos.Entities;


public class Departamento
{
    public int DepartamentoId { get; set; }
    [MaxLength(100)]
    public string? Nome { get; set; }
    public ICollection<Funcionario> Funcionarios { get; set; }=new List<Funcionario>();

}