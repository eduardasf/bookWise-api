using Domain.Commands;
using Domain.Entities;
using Domain.IRepositories;
using Shared.Commands;
using Shared.Notifications;

namespace Domain.Handlers
{
    public class CategoriaHandler : Notifiable
    {
        public readonly ICategoriaRepository _categoriaRepository;
        public CategoriaHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public ICommandResult Handle(BuscarCategoriaPorIdCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Erro ao buscar categoria", Notifications);
            }

            var categoria = _categoriaRepository.BuscarPorId(command.Id);

            return new CommandResult(true, "Categoria buscado com sucesso", categoria);
        }

        public ICommandResult Handle(InserirCategoriaCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Erro ao inserir categoria", Notifications);
            }

            var categoria = new Categoria
            {
                Id = Guid.NewGuid(),
                Nome = command.Nome.Trim(),
                Descricao = command.Descricao,
            };

            categoria = _categoriaRepository.InserirCategoria(categoria);

            return new CommandResult(true, "Categoria inserido com sucesso", categoria);

        }

        public ICommandResult Handle(AtualizarCategoriaCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Erro ao atualizar categoria", Notifications);
            }

            var categoria = new Categoria
            {
                Nome = command.Nome.Trim(),
                Descricao = command.Descricao,
            };

            var resposta = _categoriaRepository.AtualizarCategoria(command.Id, categoria);

            if (resposta == null)
            {
                AddNotification("Categoria", "Categoria não encontrado");
                return new CommandResult(false, "Erro ao atualizar categoria", Notifications);
            }

            return new CommandResult(true, "Categoria editado com sucesso", "");
        }

        public ICommandResult Handle(RemoverCategoriaCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Erro ao excluir categoria", Notifications);
            }

            var categoria = _categoriaRepository.BuscarPorId(command.Id);

            var resposta = _categoriaRepository.RemoverCategoria(categoria.Id);

            if (resposta == null)
            {
                AddNotification("Categoria", "Categoria não encontrado");
                return new CommandResult(false, "Erro ao excluir categoria", Notifications);
            }

            return new CommandResult(true, "Categoria excluído com sucesso", "");
        }
    }
}
