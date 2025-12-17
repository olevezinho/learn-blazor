using BlazorUploadsSSR.Entities;

namespace BlazorUploadsSSR.Repositories;

public interface IUploadRepository
{
    Task UploadFicheiroDbAsync(FicheiroUpload ficheiro);
    Task<IEnumerable<FicheiroUpload>> GetFicheirosAsync();
    Task<FicheiroUpload> GetFicheiroAsync(int id);
    Task DeleteFicheiroAsync(int id);
}