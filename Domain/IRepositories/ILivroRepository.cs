
using Domain.Entities;

namespace Domain.IRepositories
{
    public interface ILivroRepository
    {
        List<Livro> BuscarTodos();
        Livro BuscarPorId(Guid id);
        Livro InserirLivro(Livro livro);
        Livro AtualizarLivro(Guid id, Livro livro);
        Livro RemoverLivro(Guid id);
        Livro AdicionarCategorias(Guid idLivro, Guid[] idsCategoria);
        Livro RemoverCategorias(Guid idLivro, Guid[] idsCategoria);

    }
}
