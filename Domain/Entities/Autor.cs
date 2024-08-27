
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Autor
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(255)]
        public required string Nome { get; set; }

        [StringLength(255)]
        public required string Email { get; set; }
        public List<Livro> Livros { get; set; } = new List<Livro>();
    }
}
