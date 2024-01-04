using Finanzauto.Pagos.Application.Features.Pays.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finanzauto.Pagos.Controllers
{
    [ApiController]
    [Route("/pays")]
    public class PaysController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaysController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("pay")]
        public async Task<ActionResult> Pay([FromBody] CreatePay command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
