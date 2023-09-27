using EjemploRepartos_database.Entities;
using EjemploRepartos_repository.Interface;
using EjemploRepartos_service.Interface;
using EjemploRepartos_service.Request.Pedido;

namespace EjemploRepartos_service.Service
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
    
        public async Task<int> CreatePedido(RequestNuevoPedido request)
        {
            Pedido pedidoInsert = new Pedido()
            {
                IdCliente = 1,
                IdEstadoPedido = 1,
                Destino = request.Destino,
                Observaciones = request.Observaciones,
                FechaCreacion = DateTime.UtcNow,
                FechaModificacion = DateTime.UtcNow
            };

            if(request.Comidas.Count() > 0)
            {
                PedidoComida pedidoComidasInsert;

                foreach(var item in request.Comidas)
                {
                    pedidoComidasInsert = new PedidoComida()
                    {
                        IdComida = item.IdComida,
                        Cantidad = item.Cantidad,
                        FechaCreacion = DateTime.UtcNow,
                        FechaModificacion = DateTime.UtcNow,
                        IdPedido = pedidoInsert.IdPedido
                    };

                    pedidoInsert.PedidoComida.Add(pedidoComidasInsert);
                }
            }

            _pedidoRepository.CreateGeneric(pedidoInsert);

            if (await _pedidoRepository.SaveChangesAsync() > 0)
            {
                return pedidoInsert.IdPedido;
            }
            else
            {
                throw new Exception("Error al crear el pedido");
            }
        }
    }
}
