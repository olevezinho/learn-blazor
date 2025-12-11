using Livraria.Domain.Abstractions;
using Livraria.Domain.Entities;
using Livraria.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infrastructure.Repositories;

public class LivroRepository : ILivroRepository
{
    private readonly ApplicationDbContext _context;
    
    public LivroRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Livro>> GetLivrosAsync()
    {
        if (_context.Livros.Any())
            return await _context.Livros.ToListAsync();

        return [];
    }

    public async Task<Livro> GetLivroAsync(int id)
    {
        var livro = await _context.Livros.FirstOrDefaultAsync(l => l.LivroId == id);
        if (livro is null)
            throw new InvalidOperationException($"Livro {id} not found");
        
        return livro;
    }

    public async Task<Livro> AdicionarLivroAsync(Livro livro)
    {
        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();
        return livro;
    }

    public async Task AtualizarLivroAsync(Livro livro)
    {
        if (_context.Livros.Any())
        {
            var existing = await _context.Livros.FirstOrDefaultAsync(l => l.LivroId == livro.LivroId);
            if (existing is null)
                throw new InvalidOperationException($"Livro {existing.LivroId} not found");
            
            _context.Entry(existing).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Livro> RemoverLivroAsync(int id)
    {
        var livro = await _context.Livros.FirstOrDefaultAsync(l => l.LivroId == id);
        if (livro is null)
            throw new InvalidOperationException($"Livro {id} not found");

        _context.Remove(livro);
        await _context.SaveChangesAsync();
            
        return livro;
    }
}