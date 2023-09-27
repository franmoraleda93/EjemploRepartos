using EjemploRepartos_API.Authorization;
using EjemploRepartos_service.Interface;
using EjemploRepartos_service.Request.Pedido;
using Microsoft.AspNetCore.Mvc;

namespace EjemploRepartos_API.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class PedidosController : Controller
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [AuthorizeCliente]
        [HttpPost]
        [Route("NuevoPedido")]
        public async Task<IActionResult> CreatePedido([FromBody] RequestNuevoPedido request)
        {
            return Ok(await _pedidoService.CreatePedido(request));
        }

        [AuthorizeCliente]
        [HttpDelete]        
        public async Task<IActionResult> DeletePedido (int idPedido)
        {
            return Ok(await _pedidoService.DeletePedido(idPedido));
        }

    }
}
