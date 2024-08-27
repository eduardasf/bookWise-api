using Domain.Commands;
using Domain.Commands.Livro;
using Domain.Handlers;
using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Commands;

namespace Api.Controllers
{
    [Route("api/autor")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly AutorHandler _handler;
        private readonly IAutorRepository _autorRepository;

        public AutorController(AutorHandler autorHandler, IAutorRepository autorRepository)
        {
            _handler = autorHandler;
            _autorRepository = autorRepository;
        }

        [HttpGet]
        public ICommandResult BuscarTodos()
        {
            var autor = _autorRepository.BuscarTodos();
            return new CommandResult(true, "Autor buscados com sucesso", autor);
        }

        [HttpGet("{id}")]
        public ICommandResult BuscarPorId([FromRoute] Guid id)
        {
            var command = new BuscarAutorPorIdCommand
            {
                Id = id
            };
            return _handler.Handle(command);
        }

        [HttpPost]
        public ICommandResult Inserir([FromBody] InserirAutorCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut("{id}")]
        public ICommandResult Atualizar([FromRoute] Guid id, [FromBody] AtualizarAutorCommand command)
        {
            command.Id = id;
            return _handler.Handle(command);
        }

        [HttpDelete("remover/{id}")]
        public ICommandResult Remover([FromRoute] Guid id)
        {
            var command = new RemoverAutorCommand { Id = id };
            return _handler.Handle(command);
        }
    }
}
