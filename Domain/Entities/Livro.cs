using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Livro
    {
        [Key]
        public Guid Id { get; set; }
        public required string Codigo {  get; set; }

        [StringLength(255)]
        public required string Nome { get; set; }

        [StringLength(500)]
        public required string Resumo { get; set; }
        public required string Idioma { get; set; }
        public required int QuantidadeDisponivel { get; set; }
        public List<Categoria> Categorias { get; set; } = new List<Categoria>();

        [ForeignKey(nameof(Autor))]
        public Guid IdAutor { get; set; }

        [JsonIgnore]
        public Autor? Autor { get; set; }


    }
}
