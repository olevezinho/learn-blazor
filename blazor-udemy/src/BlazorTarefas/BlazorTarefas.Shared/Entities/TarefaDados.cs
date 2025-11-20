using BlazorTarefas.Shared.Data;
using System;
using System.Collections.Generic;

namespace BlazorTarefas.Shared.Entities;

public static class TarefaDados
{
    public static List<Tarefa> ObterTarefas() => new()
    {
        new Tarefa { Descricao = "Estudar .NET Core", Concluida = false, DataCriacao = DateTime.Now },
        new Tarefa { Descricao = "Estudar Blazor WebAssembly", Concluida = false, DataCriacao = DateTime.Now.AddDays(-1) },
        new Tarefa { Descricao = "Estudar Blazor Server", Concluida = false, DataCriacao = DateTime.Now.AddDays(-2) },
        new Tarefa { Descricao = "Estudar Cibersegurança", Concluida = false, DataCriacao = DateTime.Now.AddHours(-1) },
        new Tarefa { Descricao = "Estudar Linux", Concluida = false, DataCriacao = DateTime.Now.AddHours(-1).AddMinutes(-1) },
        new Tarefa { Descricao = "Agendar exames LPIC", Concluida = false, DataCriacao = DateTime.Now.AddMinutes(-10) }
    };
}
