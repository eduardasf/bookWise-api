
using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IAutorRepository
    {
        List<Autor> BuscarTodos();
        Autor BuscarPorId(Guid id);
        Autor InserirAutor(Autor autor);
        Autor AtualizarAutor(Guid id, Autor autor);
        Autor RemoverAutor(Guid id);

    }
}
