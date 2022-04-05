using Application.Features.PedidosDet.Commands.InsertarPedidosDetCmd;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PedidoDetController : BaseApiController
    {
        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(InsertarPedidoDetCommand command)
        {
            return Ok(await Mediator!.Send(command));
        }
    }
}
