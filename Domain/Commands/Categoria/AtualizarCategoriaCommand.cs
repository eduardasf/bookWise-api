using Shared.Commands;
using Shared.Notifications;
using Shared.Validation;

namespace Domain.Commands
{
    public class AtualizarCategoriaCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }

        public bool Validate()
        {

            AddNotifications(new ValidationContract()

            .IsNotNullOrEmpty(Id.ToString(), "Categoria", "Categoria não encontrada.")
            .IsNotNullOrEmpty(Nome.Trim(), "Categoria", "Por favor, insira o nome do categoria.")
            .HasMaxLen(Nome.Trim(), 255, "Categoria", "Por favor, insira um nome com no máximo 255 caracteres.")
            .IsNotNullOrEmpty(Descricao.Trim(), "Categoria", "Por favor, insira o nome do categoria.")
            .HasMaxLen(Descricao.Trim(), 500, "Categoria", "Por favor, insira um nome com no máximo 255 caracteres."));

            return Valid;
        }

    }
}
