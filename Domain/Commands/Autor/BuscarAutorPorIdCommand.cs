
using Shared.Commands;
using Shared.Notifications;
using Shared.Validation;

namespace Domain.Commands
{
    public class BuscarAutorPorIdCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public bool Validate()
        {
            AddNotifications(new ValidationContract()
                .IsNotNullOrEmpty(Id.ToString(), "Autor", "Autor não encontrado"));
            return Valid;
        }
    }
}
