using MudBlazorAlunos.Entities;

namespace MudBlazorAlunos.Services;

public interface IAlunosService
{
    Task<IEnumerable<Aluno>> ListarAlunosAsync();
    Task<Aluno> ObterAlunoPorIdAsync(int id);
    Task GuardarAlunoAsync(Aluno aluno);
    Task RemoverAlunoAsync(int id);
}