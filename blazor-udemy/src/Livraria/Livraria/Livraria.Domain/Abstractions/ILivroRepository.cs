using Livraria.Domain.Entities;

namespace Livraria.Domain.Abstractions;

public interface ILivroRepository
{
    Task<IEnumerable<Livro>> GetLivrosAsync();
    Task<Livro> GetLivroAsync(int id);
    Task<Livro> AdicionarLivroAsync(Livro livro);
    Task AtualizarLivroAsync(Livro livro);
    Task<Livro> RemoverLivroAsync(int id);
}