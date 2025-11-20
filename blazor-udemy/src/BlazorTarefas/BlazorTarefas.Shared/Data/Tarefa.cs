using System;

namespace BlazorTarefas.Shared.Data;

public class Tarefa
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Descricao { get; set; } = null!;
    public bool Concluida { get; set; } = false;
    public DateTime DataCriacao { get; set; }
}
