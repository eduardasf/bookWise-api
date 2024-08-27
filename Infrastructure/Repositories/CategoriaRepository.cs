using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly BookWiseDbContext _context;
        public CategoriaRepository(BookWiseDbContext context)
        {
            _context = context;
        }

        public Categoria AtualizarCategoria(Guid id, Categoria categoria)
        {
            var categoriaEncontrado = _context.Categorias
                .FirstOrDefault(x => x.Id == id);

            if (categoriaEncontrado == null)
            {
                return null;
            }

            categoriaEncontrado.Nome = categoria.Nome;
            categoriaEncontrado.Descricao = categoria.Descricao;

            _context.SaveChanges();
            return categoriaEncontrado;
        }

        public Categoria BuscarPorId(Guid id)
        {
            return _context.Categorias
                .Single(x => x.Id == id);
        }

        public List<Categoria> BuscarTodos()
        {
            var categoria = _context.Categorias
                .ToList();
            return categoria;
        }

        public Categoria InserirCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return categoria;
        }

        public Categoria RemoverCategoria(Guid id)
        {
            var categoria = _context.Categorias.FirstOrDefault(x => x.Id == id);

            if (categoria == null)
            {
                return null;
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return categoria;

        }
    }
}
