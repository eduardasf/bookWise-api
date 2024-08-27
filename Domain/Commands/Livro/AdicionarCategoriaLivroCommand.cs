using Shared.Commands;
using Shared.Notifications;
using Shared.Validation;

namespace Domain.Commands.Livro
{
    public class AdicionarCategoriaLivroCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public Guid[] IdsCategoria { get; set; }

        public bool Validate()
        {
            AddNotifications(new ValidationContract()
                .IsNotNullOrEmpty(Id.ToString(), "Livro", "Livro não encontrado"));

            return Valid;
        }
    }
}
