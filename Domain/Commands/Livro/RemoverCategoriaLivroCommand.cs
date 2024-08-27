using Shared.Commands;
using Shared.Notifications;
using Shared.Validation;

namespace Domain.Commands
{
    public class RemoverCategoriaLivroCommand : Notifiable, ICommand
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
