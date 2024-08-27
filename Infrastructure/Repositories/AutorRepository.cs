using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly BookWiseDbContext _context;
        public AutorRepository(BookWiseDbContext context)
        {
            _context = context;
        }
        
        public Autor AtualizarAutor(Guid id, Autor autor)
        {
            var autorEncontrado = _context.Autores
                .FirstOrDefault(x => x.Id == id);

            if (autorEncontrado == null)
            {
                return null;
            }

            autorEncontrado.Nome = autor.Nome;
            autorEncontrado.Email = autor.Email;

            _context.SaveChanges();
            return autorEncontrado;
        }

        public Autor BuscarPorId(Guid id)
        {
            return _context.Autores
                .Single(x => x.Id == id);
        }

        public List<Autor> BuscarTodos()
        {
            var autor = _context.Autores
                .ToList();
            return autor;
        }

        public Autor InserirAutor(Autor autor)
        {
            _context.Autores.Add(autor);
            _context.SaveChanges();
            return autor;
        }

        public Autor RemoverAutor(Guid id)
        {
            var autor = _context.Autores.FirstOrDefault(x => x.Id == id);

            if (autor == null)
            {
                return null;
            }

            _context.Autores.Remove(autor);
            _context.SaveChanges();

            return autor;

        }
    }
}
