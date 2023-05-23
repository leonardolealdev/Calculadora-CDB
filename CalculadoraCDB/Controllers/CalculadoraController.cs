using CalculadoraCDB.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraCDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CalculadoraController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<GenericoCommand> Calculo(CalculadoraCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
