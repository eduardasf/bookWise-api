using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly BookWiseDbContext _context;
        public LivroRepository(BookWiseDbContext context)
        {
            _context = context;
        }
        public Livro AdicionarCategorias(Guid idLivro, Guid[] idsCategoria)
        {
            var livroEncontrado = _context.Livros
                .Include(x => x.Categorias)
                .FirstOrDefault(x => x.Id == idLivro);

            if (livroEncontrado == null)
                return null;

            foreach (Guid idCategoria in idsCategoria)
            {
                var categoriaEncontrado = _context.Categorias.FirstOrDefault(x => x.Id == idCategoria);
                livroEncontrado.Categorias.Add(categoriaEncontrado);
            }

            _context.SaveChanges();

            return livroEncontrado;
        }

        public Livro AtualizarLivro(Guid id, Livro livro)
        {
            var livroEncontrado = _context.Livros
                .FirstOrDefault(x => x.Id == id);

            if (livroEncontrado == null)
            {
                return null;
            }

            livroEncontrado.Codigo = livro.Codigo;
            livroEncontrado.Nome = livro.Nome;
            livroEncontrado.Resumo = livro.Resumo;
            livroEncontrado.Idioma = livro.Idioma;
            livroEncontrado.QuantidadeDisponivel = livro.QuantidadeDisponivel;
            livroEncontrado.IdAutor = livro.IdAutor;

            _context.SaveChanges();
            return livroEncontrado;
        }

        public Livro BuscarPorId(Guid id)
        {
            return _context.Livros
                .Single(x => x.Id == id);
        }

        public List<Livro> BuscarTodos()
        {
            var livro = _context.Livros
                .ToList();
            return livro;
        }

        public Livro InserirLivro(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
            return livro;
        }

        public Livro RemoverCategorias(Guid idLivro, Guid[] idsCategoria)
        {
            var livroEncontrado = _context.Livros
                .Include(x => x.Categorias)
                .FirstOrDefault(x => x.Id == idLivro);

            if (livroEncontrado == null)
                return null;

            foreach (Guid idCategoria in idsCategoria)
            {
                var categoriaEncontrado = _context.Categorias.FirstOrDefault(x => x.Id == idCategoria);
                livroEncontrado.Categorias.Remove(categoriaEncontrado);
            }

            _context.SaveChanges();

            return livroEncontrado;
        }

        public Livro? RemoverLivro(Guid id)
        {
            var livro = _context.Livros.FirstOrDefault(x => x.Id == id);

            if (livro == null)
            {
                return null;
            }

            livro.Categorias.Clear();

            _context.Livros.Remove(livro);
            _context.SaveChanges();

            return livro;

        }
    }
}
