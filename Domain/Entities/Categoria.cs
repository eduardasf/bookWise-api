using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Categoria
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(255)]
        public required string Nome { get; set; }

        [StringLength(500)]
        public required string Descricao { get; set; }

        [JsonIgnore]
        public List<Livro> Livros {  get; set; } = new List<Livro>();
    }
}
