using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class BookWiseDbContext : DbContext
    {
        public BookWiseDbContext(DbContextOptions<BookWiseDbContext> options)
            : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Livro - Autor
            modelBuilder.Entity<Livro>()
                .HasOne(l => l.Autor)         
                .WithMany(a => a.Livros)       
                .HasForeignKey(l => l.IdAutor) 
                .OnDelete(DeleteBehavior.Cascade); 

            // Livro - Categoria
            modelBuilder.Entity<Livro>()
                .HasMany(l => l.Categorias)
                .WithMany(c => c.Livros)
                .UsingEntity<Dictionary<string, object>>(
                    "LivroCategoria",
                    j => j
                        .HasOne<Categoria>()
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .HasConstraintName("FK_LivroCategoria_CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Livro>()
                        .WithMany()
                        .HasForeignKey("LivroId")
                        .HasConstraintName("FK_LivroCategoria_LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
