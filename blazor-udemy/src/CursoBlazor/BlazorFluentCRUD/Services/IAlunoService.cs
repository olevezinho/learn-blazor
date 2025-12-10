using BlazorFluentCRUD.Context;

namespace BlazorFluentCRUD.Services;

public interface IAlunoService
{
    Task<List<Aluno>> GetAlunosAsync();
    Task<Aluno> GetAlunoAsync(int id);
    Task<Aluno> AddAlunoAsync(Aluno aluno);
    Task<Aluno> UpdateAlunoAsync(Aluno aluno);
    Task<Aluno> DeleteAlunoAsync(int id);
}