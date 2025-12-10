using BlazorUploadsSSR.Context;
using BlazorUploadsSSR.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorUploadsSSR.Repositories;

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
        var ficheiro = await GetFicheiroAsync(id);

        if (ficheiro is not null)
        {
            _context.Remove(ficheiro);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<FicheiroUpload> GetFicheiroAsync(int id)
    {
        var ficheiro = await _context.FicheirosUploads.FirstOrDefaultAsync(a => a.Id == id);
        return ficheiro;
    }
}