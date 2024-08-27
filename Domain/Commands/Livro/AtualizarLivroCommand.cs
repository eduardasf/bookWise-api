using Shared.Commands;
using Shared.Notifications;
using Shared.Validation;

namespace Domain.Commands.Livro
{
    public class AtualizarLivroCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public required string Codigo {  get; set; }
        public required string Nome { get; set; }
        public required string Resumo { get; set; }
        public required string Idioma { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public Guid IdAutor { get; set; }

        public bool Validate()
        {

            AddNotifications(new ValidationContract()

            .IsNotNullOrEmpty(Id.ToString(),"Livro", "Livro não encontrado.")
            .IsNotNullOrEmpty(Codigo.Trim(),"Livro", "Por favor, insira o código do livro.")
            .IsNotNullOrEmpty(Nome.Trim(), "Livro", "Por favor, insira o nome do livro.")
            .HasMaxLen(Nome.Trim(), 255, "Livro", "Por favor, insira um nome com no máximo 255 caracteres.")
            .IsNotNullOrEmpty(Resumo.Trim(), "Livro", "Por favor, insira um resumo.")
            .HasMaxLen(Resumo.Trim(), 500, "Livro", "Por favor, insira um resumo com no máximo 500 caracteres.")
            .IsNotNullOrEmpty(Idioma.Trim(), "Livro", "Por favor, insira um idioma.")
            .HasMaxLen(Idioma.Trim(), 100, "Livro", "Por favor, insira um idioma com no máximo 100 caracteres.")
            .IsNotNullOrEmpty(QuantidadeDisponivel.ToString().Trim(), "Livro", "Por favor, insira a quantidade disponível.")
            .IsNotNullOrEmpty(IdAutor.ToString(), "Livro", "Por favor, insira o nome do autor."));

            return Valid;
        }

    }
}
