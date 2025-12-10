using BlazorFluentCRUD.Context;
using Microsoft.EntityFrameworkCore;

namespace BlazorFluentCRUD.Services;

public class AlunoService : IAlunoService
{
    private readonly AppDbContext _dbContext;

    public AlunoService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Aluno>> GetAlunosAsync()
    {
        return await _dbContext.Alunos.ToListAsync();
    }

    public async Task<Aluno> GetAlunoAsync(int id)
    {
        var aluno = await _dbContext.Alunos.FirstOrDefaultAsync(x => x.Id == id);
        return aluno ?? new Aluno();
    }

    public async Task<Aluno> AddAlunoAsync(Aluno aluno)
    {
        if(aluno is null)
            throw new ArgumentNullException(nameof(aluno));
        
        _dbContext.Alunos.Add(aluno);
        await _dbContext.SaveChangesAsync();
        return aluno;
    }

    public async Task<Aluno> UpdateAlunoAsync(Aluno aluno)
    {
        if(aluno is null)
            throw new ArgumentNullException(nameof(aluno));
        
        _dbContext.Entry(aluno).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return aluno;
    }

    public async Task<Aluno> DeleteAlunoAsync(int id)
    {
        var aluno = await _dbContext.Alunos.FirstOrDefaultAsync(x => x.Id == id);
        if (aluno is null)
        {
            throw new ArgumentNullException(nameof(aluno));
        }
        
        _dbContext.Alunos.Remove(aluno);
        await _dbContext.SaveChangesAsync();
        return aluno;
    }
}