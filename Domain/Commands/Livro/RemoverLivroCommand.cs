using Shared.Commands;
using Shared.Notifications;
using Shared.Validation;
using System.Text.Json.Serialization;

namespace Domain.Commands
{
    public class RemoverLivroCommand : Notifiable, ICommand
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public bool Validate()
        {
            AddNotifications(new ValidationContract()
                .IsNotNullOrEmpty(Id.ToString(), "Livro", "Livro não encontrado"));

            return Valid;
        }
    }
}
