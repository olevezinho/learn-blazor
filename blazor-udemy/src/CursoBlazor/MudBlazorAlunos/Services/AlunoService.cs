using Microsoft.EntityFrameworkCore;
using MudBlazorAlunos.Context;
using MudBlazorAlunos.Entities;

namespace MudBlazorAlunos.Services;

public class AlunoService : IAlunosService
{
    private readonly AppDbContext _context;

    public AlunoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Aluno>> ListarAlunosAsync()
    {
        return await _context.Alunos.ToListAsync();
    }

    public async Task<Aluno> ObterAlunoPorIdAsync(int id)
    {
        var aluno = await _context.Alunos.FindAsync(id);
        return aluno!;
    }

    public async Task GuardarAlunoAsync(Aluno aluno)
    {
        if (aluno.Id is 0)
        {
            _context.Alunos.Add(aluno);    
        }
        else
        {
            _context.Alunos.Update(aluno);    
        }
        
        await _context.SaveChangesAsync();
        
    }

    public async Task RemoverAlunoAsync(int id)
    {
        var aluno = await _context.Alunos.FindAsync(id);
        if (aluno is not null)
        {
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }
    }
}