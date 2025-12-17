using BlazorUploads.Context;
using BlazorUploads.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorUploads.Repositories;

public class UploadRepository : IUploadRepository
{
    private readonly AppDbContext _context;
    public UploadRepository(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task UploadFicheiroDbAsync(FicheiroUpload ficheiro)
    {
        _context.FicheirosUploads.Add(ficheiro);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<FicheiroUpload>> GetFicheirosAsync()
    {
        return await _context.FicheirosUploads.ToListAsync();
    }

    public async Task DeleteFicheiroAsync(int id)
    {
        var Ficheiro = await GetFicheiroAsync(id);

        if (Ficheiro is not null)
        {
            _context.Remove(Ficheiro);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<FicheiroUpload> GetFicheiroAsync(int id)
    {
        var Ficheiro = await _context.FicheirosUploads.FirstOrDefaultAsync(a => a.Id == id);
        return Ficheiro;
    }
}