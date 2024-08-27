using Shared.FluentValidator.Validation;
using Shared.Validation;

namespace Shared.Notifications
{
    public abstract class Contract : Notifiable
    {
        protected Contract()
        {
            ValidationContract = new ValidationContract();
        }

        public ValidationContract ValidationContract { get; set; }
    }
}