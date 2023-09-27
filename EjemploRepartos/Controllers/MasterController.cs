using EjemploRepartos_service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EjemploRepartos_API.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class MasterController : Controller
    {
        private readonly IMasterService _masterService;

        public MasterController(IMasterService masterService)
        {
            _masterService = masterService;
        }

        [HttpGet]
        [Route("EstadosPedido")]
        public async Task<IActionResult> GetEstadosPedido()
        {
            return Ok(await _masterService.GetEstadoPedidoAsync());
        }

        [HttpGet]
        [Route("Comidas")]
        public async Task<IActionResult> GetComidas()
        {
            return Ok(await _masterService.GetComidasAsync());
        }
    }
}
