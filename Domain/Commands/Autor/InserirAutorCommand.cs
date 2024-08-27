using Shared.Commands;
using Shared.Notifications;
using Shared.Validation;

namespace Domain.Commands
{
    public class InserirAutorCommand : Notifiable, ICommand
    {
        public required string Nome { get; set; }
        public required string Email {  get; set; }

        public bool Validate()
        {

            AddNotifications(new ValidationContract()

            .IsNotNullOrEmpty(Nome.Trim(), "Autor", "Por favor, insira o nome do autor.")
            .HasMaxLen(Nome.Trim(), 255, "Autor", "Por favor, insira um nome com no máximo 255 caracteres.")
            .IsNotNullOrEmpty(Email.Trim(), "Autor", "Por favor, insira o nome do autor.")
            .HasMaxLen(Email.Trim(), 255, "Autor", "Por favor, insira um nome com no máximo 255 caracteres."));

            return Valid;
        }

    }
}
