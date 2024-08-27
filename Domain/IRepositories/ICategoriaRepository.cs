
using Domain.Entities;

namespace Domain.IRepositories
{
    public interface ICategoriaRepository
    {
        List<Categoria> BuscarTodos();
        Categoria BuscarPorId(Guid id);
        Categoria InserirCategoria(Categoria categoria);
        Categoria AtualizarCategoria(Guid id, Categoria categoria);
        Categoria RemoverCategoria(Guid id);

    }
}
