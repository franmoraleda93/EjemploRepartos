using EjemploRepartos_service.Request.Pedido;

namespace EjemploRepartos_service.Interface
{
    public interface IPedidoService
    {
        Task<int> CreatePedido(RequestNuevoPedido request);
    }
}
