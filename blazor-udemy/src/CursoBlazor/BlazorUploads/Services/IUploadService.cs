using Microsoft.AspNetCore.Components.Forms;

namespace BlazorUploads.Services;

public interface IUploadService
{
    Task<(int, string)> FicheiroUploadAsync(IBrowserFile ficheiro, 
        int tamanhoMaximoFicheiro, 
        string[] extensoesPermitidas);
}