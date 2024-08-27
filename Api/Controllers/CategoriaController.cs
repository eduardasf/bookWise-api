using Domain.Commands;
using Domain.Commands.Livro;
using Domain.Handlers;
using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Commands;

namespace Api.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaHandler _handler;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(CategoriaHandler categoriaHandler, ICategoriaRepository categoriaRepository)
        {
            _handler = categoriaHandler;
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public ICommandResult BuscarTodos()
        {
            var categoria = _categoriaRepository.BuscarTodos();
            return new CommandResult(true, "Autor buscados com sucesso", categoria);
        }

        [HttpGet("{id}")]
        public ICommandResult BuscarPorId([FromRoute] Guid id)
        {
            var command = new BuscarCategoriaPorIdCommand
            {
                Id = id
            };
            return _handler.Handle(command);
        }

        [HttpPost]
        public ICommandResult Inserir([FromBody] InserirCategoriaCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut("{id}")]
        public ICommandResult Atualizar([FromRoute] Guid id, [FromBody] AtualizarCategoriaCommand command)
        {
            command.Id = id;
            return _handler.Handle(command);
        }

        [HttpDelete("remover/{id}")]
        public ICommandResult Remover([FromRoute] Guid id)
        {
            var command = new RemoverCategoriaCommand { Id = id };
            return _handler.Handle(command);
        }
    }
}
