using Shared.Commands;
using Shared.Notifications;
using Shared.Validation;
using System.Text.Json.Serialization;

namespace Domain.Commands
{
    public class RemoverAutorCommand : Notifiable, ICommand
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public bool Validate()
        {
            AddNotifications(new ValidationContract()
                .IsNotNullOrEmpty(Id.ToString(), "Autor", "Autor não encontrado"));

            return Valid;
        }
    }
}
