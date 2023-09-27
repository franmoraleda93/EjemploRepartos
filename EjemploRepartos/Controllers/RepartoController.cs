using EjemploRepartos_API.Authorization;
using EjemploRepartos_service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EjemploRepartos_API.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class RepartoController : Controller
    {
        private readonly IRepartoService _repartoService;

        public RepartoController(IRepartoService repartoService)
        {
            _repartoService = repartoService;
        }

        [AuthorizeRepartidor]
        [HttpPut]
        [Route("Aceptar")]
        public async Task<IActionResult> AceptarReparto(int idPedido)
        {
            return Ok(await _repartoService.AceptarReparto(idPedido));
        }

        [AuthorizeCliente]
        [HttpGet]
        [Route("UbicacionActual")]
        public async Task<IActionResult> GetUbicacionActual(int idPedido)
        {
            return Ok(await _repartoService.GetUbicacionActual(idPedido));
        }

    }
}
