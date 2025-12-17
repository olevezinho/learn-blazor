using Microsoft.AspNetCore.Components.Forms;

namespace BlazorUploads.Services;

public class UploadService : IUploadService
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<UploadService> _logger;

    public UploadService(
        IWebHostEnvironment environment, 
        ILogger<UploadService> logger)
    {
        _environment = environment;
        _logger = logger;
    }
    public async Task<(int, string)> FicheiroUploadAsync(
        IBrowserFile ficheiro, 
        int tamanhoMaximoPermitido, 
        string[] extensoesPermitidas)
    {
        var diretorioUpload = Path.Combine(_environment.WebRootPath, "uploads");

        if (!Directory.Exists(diretorioUpload))
        {
            Directory.CreateDirectory(diretorioUpload);
        }

        if (ficheiro.Size > tamanhoMaximoPermitido)
        {
            var mensagem = $"Arquivo: {ficheiro.Name} excede o tamanho máximo permitido.";
            _logger.LogInformation(mensagem);
            return (0, mensagem);
        }

        var arquivoExtensao = Path.GetExtension(ficheiro.Name);

        if (!extensoesPermitidas.Contains(arquivoExtensao))
        {
            var mensagem = $"Arquivo: {ficheiro.Name}, tipo de Arquivo não permitido";
            _logger.LogInformation(mensagem);
            return (0, mensagem);
        }

        //altera o nome do arquivo
        var nomeArquivoSeguro = $"{Guid.NewGuid()}{arquivoExtensao}";
        //obtem o caminho do arquivo em wwwroot 
        var path = Path.Combine(diretorioUpload, nomeArquivoSeguro);
        //cria o arquivo
        await using var fs = new FileStream(path, FileMode.Create);
        // lê e copia paraa memoria
        await ficheiro.OpenReadStream(tamanhoMaximoPermitido).CopyToAsync(fs);
        return (1, nomeArquivoSeguro);
    }
}