using Confitec.Application.Commands.AtualizarUsuario;
using Confitec.Application.Commands.CadastrarUsuario;
using Confitec.Application.Commands.RemoverUsuario;
using Confitec.Application.Queries.BuscarTodosUsuarios;
using Confitec.Application.Queries.BuscarUsuario;
using Confitec.Application.ViewModels.Page;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Confitec.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos([FromQuery] PageFilter pageFilter)
        {
            var query = new BuscarTodosUsuariosQuery(pageFilter);
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var query = new BuscarUsuarioQuery(id);
            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarUsuarioCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(BuscarPorId), new { id = 1 }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarUsuarioCommand command)
        {
            var result = await _mediator.Send(command);
            if(result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var command = new RemoverUsuarioCommand(id);
            var result = await _mediator.Send(command);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
