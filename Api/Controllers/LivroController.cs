using Domain.Commands;
using Domain.Commands.Livro;
using Domain.Handlers;
using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Commands;

namespace Api.Controllers
{
    [Route("api/livro")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly LivroHandler _handler;
        private readonly ILivroRepository _livroRepository;

        public LivroController(LivroHandler livroHandler, ILivroRepository livroRepository)
        {
            _handler = livroHandler;
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public ICommandResult BuscarTodos()
        {
            var livro = _livroRepository.BuscarTodos();
            return new CommandResult(true, "Livros buscados com sucesso", livro);
        }

        [HttpGet("{id}")]
        public ICommandResult BuscarPorId([FromRoute] Guid id)
        {
            var command = new BuscarLivroPorIdCommand
            {
                Id = id
            };
            return _handler.Handle(command);
        }

        [HttpPost]
        public ICommandResult Inserir([FromBody] InserirLivroCommand command)
        { 
            return _handler.Handle(command);
        }

        [HttpPut("{id}")]
        public ICommandResult Atualizar([FromRoute] Guid id, [FromBody] AtualizarLivroCommand command)
        {
            command.Id = id;
            return _handler.Handle(command);
        }

        [HttpDelete("remover/{id}")]
        public ICommandResult Remover([FromRoute] Guid id)
        {
            var command = new RemoverLivroCommand { Id = id };
            return _handler.Handle(command);
        }

        [HttpPost("{id}/adicionar-categoria")]
        public ICommandResult AdicionarCategorias([FromRoute] Guid id, [FromBody] AdicionarCategoriaLivroCommand command)
        {
            command.Id = id;
            return _handler.Handle(command);
        }

        [HttpPost("{id}/remover-categoria")]
        public ICommandResult RemoverCategorias([FromRoute] Guid id, [FromBody] RemoverCategoriaLivroCommand command)
        {
            command.Id = id;
            return _handler.RemoverCategoria(command);
        }


    }
}
