using Domain.Commands;
using Domain.Commands.Livro;
using Domain.Entities;
using Domain.IRepositories;
using Shared.Commands;
using Shared.Notifications;

namespace Domain.Handlers
{
    public class AutorHandler : Notifiable
    {
        public readonly IAutorRepository _autorRepository;
        public AutorHandler(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public ICommandResult Handle(BuscarAutorPorIdCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Erro ao buscar autor", Notifications);
            }

            var autor = _autorRepository.BuscarPorId(command.Id);

            return new CommandResult(true, "Autor buscado com sucesso", autor);
        }

        public ICommandResult Handle(InserirAutorCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Erro ao inserir autor", Notifications);
            }

            var autor = new Autor
            {
                Id = Guid.NewGuid(),
                Nome = command.Nome.Trim(),
                Email = command.Email,
            };

            autor = _autorRepository.InserirAutor(autor);

            return new CommandResult(true, "Autor inserido com sucesso", autor);

        }

        public ICommandResult Handle(AtualizarAutorCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Erro ao atualizar autor", Notifications);
            }

            var autor = new Autor
            {
                Nome = command.Nome.Trim(),
                Email = command.Email,
            };

            var resposta = _autorRepository.AtualizarAutor(command.Id, autor);

            if (resposta == null)
            {
                AddNotification("Livro", "Livro não encontrado");
                return new CommandResult(false, "Erro ao atualizar livro", Notifications);
            }

            return new CommandResult(true, "Autor editado com sucesso", "");
        }

        public ICommandResult Handle(RemoverAutorCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Erro ao excluir autor", Notifications);
            }

            var autor = _autorRepository.BuscarPorId(command.Id);

            var resposta = _autorRepository.RemoverAutor(autor.Id);

            if (resposta == null)
            {
                AddNotification("Autor", "Autor não encontrado");
                return new CommandResult(false, "Erro ao excluir autor", Notifications);
            }

            return new CommandResult(true, "Autor excluído com sucesso", "");
        }
    }
}
