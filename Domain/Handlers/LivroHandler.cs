using Domain.Commands;
using Domain.Commands.Livro;
using Domain.Entities;
using Domain.IRepositories;
using Shared.Commands;
using Shared.Notifications;

namespace Domain.Handlers
{
    public class LivroHandler : Notifiable
    {
        public readonly ILivroRepository _livroRepository;
        public LivroHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public ICommandResult Handle(BuscarLivroPorIdCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Erro ao buscar livro", Notifications);
            }

            var livro = _livroRepository.BuscarPorId(command.Id);

            return new CommandResult(true, "Livro buscado com sucesso", livro);
        }

        public ICommandResult Handle(InserirLivroCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Erro ao inserir livro", Notifications);
            }

            var livro = new Livro
            {
                Id = Guid.NewGuid(),
                Codigo = command.Codigo,
                Nome = command.Nome.Trim(),
                Resumo = command.Resumo.Trim(),
                Idioma = command.Idioma.Trim(),
                QuantidadeDisponivel = command.QuantidadeDisponivel,
                IdAutor = command.IdAutor

            };

            livro = _livroRepository.InserirLivro(livro);

            return new CommandResult(true, "Livro inserido com sucesso", livro);

        }

        public ICommandResult Handle(AtualizarLivroCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Erro ao atualizar livro", Notifications);
            }

            var livro = new Livro
            {
                Codigo = command.Codigo,    
                Nome = command.Nome.Trim(),
                Resumo = command.Resumo.Trim(),
                Idioma = command.Idioma.Trim(),
                QuantidadeDisponivel = command.QuantidadeDisponivel,
                IdAutor = command.IdAutor
            };

            var resposta = _livroRepository.AtualizarLivro(command.Id, livro);

            if (resposta == null)
            {
                AddNotification("Livro", "Livro não encontrado");
                return new CommandResult(false, "Erro ao atualizar livro", Notifications);
            }

            return new CommandResult(true, "Livro editado com sucesso", "");
        }

        public ICommandResult Handle(RemoverLivroCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Erro ao excluir livro", Notifications);
            }

            var livro = _livroRepository.BuscarPorId(command.Id);

            var resposta = _livroRepository.RemoverLivro(livro.Id);

            if (resposta == null)
            {
                AddNotification("Livro", "Livro não encontrado");
                return new CommandResult(false, "Erro ao excluir livro", Notifications);
            }

            return new CommandResult(true, "Livro excluído com sucesso", "");
        }

        public ICommandResult Handle(AdicionarCategoriaLivroCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Erro ao adicionar categorias ao livro", Notifications);
            }

            var resposta = _livroRepository.AdicionarCategorias(command.Id, command.IdsCategoria);

            if (resposta == null)
            {
                AddNotification("Livro", "Livro não encontrado");
                return new CommandResult(false, "Erro ao adicionar categorias ao livro", Notifications);
            } 
            return new CommandResult(true, "Categorias adicionadas ao livro com sucesso", "");
        }

        public ICommandResult RemoverCategoria(RemoverCategoriaLivroCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Erro ao remover categorias ao livro", Notifications);
            }

            var resposta = _livroRepository.RemoverCategorias(command.Id, command.IdsCategoria);

            if (resposta == null)
            {
                AddNotification("Livro", "Livro não encontrado");
                return new CommandResult(false, "Erro ao remover categorias ao livro", Notifications);
            }

            return new CommandResult(true, "Categorias removidas ao livro com sucesso", "");
        }
    }
}
