using EjemploRepartos_database.Entities;
using EjemploRepartos_repository.Interface;
using EjemploRepartos_service.Interface;
using EjemploRepartos_service.Request.Pedido;
using Microsoft.EntityFrameworkCore;

namespace EjemploRepartos_service.Service
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IHeaderRepository _headerRepository;
        private readonly IClienteRepository _clienteRepository;

        public PedidoService(IPedidoRepository pedidoRepository,
                             IHeaderRepository headerRepository,
                             IClienteRepository clienteRepository)
        {
            _pedidoRepository = pedidoRepository;
            _headerRepository = headerRepository;
            _clienteRepository = clienteRepository;
        }
    
        public async Task<int> CreatePedido(RequestNuevoPedido request)
        {
            Cliente? cliente = await _clienteRepository.GetClienteByOid(_headerRepository.GetOidCliente()).FirstOrDefaultAsync();

            Pedido pedidoInsert = new Pedido()
            {
                IdCliente = cliente.IdCliente,
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

        public async Task<bool> DeletePedido(int idPedido)
        {
            Pedido? pedidoBDD = await _pedidoRepository.GetPedidoExtByIdPedidoAndOidCliente(idPedido, _headerRepository.GetOidCliente()).FirstOrDefaultAsync();

            if (pedidoBDD == null)
            {
                throw new Exception("No existe el pedido o no tiene acceos");
            }

            if(pedidoBDD.PedidoComida.Count() > 0) 
            { 
                List<PedidoComida> pedidoComidas = pedidoBDD.PedidoComida.ToList();
                _pedidoRepository.RemoveRangeGeneric(pedidoComidas);
            }

            if (pedidoBDD.Reparto != null)
            {
                if (pedidoBDD.Reparto.RepartoUbicacion.Count() > 0) 
                {
                    List<RepartoUbicacion> repartoUbicacion = pedidoBDD.Reparto.RepartoUbicacion.ToList();
                    _pedidoRepository.RemoveRangeGeneric(repartoUbicacion);
                }
                _pedidoRepository.RemoveGeneric(pedidoBDD.Reparto);
            }

            _pedidoRepository.RemoveGeneric(pedidoBDD);

            if(await _pedidoRepository.SaveChangesAsync() > 0)
            {
                return true;
            }
            else
            {
                throw new Exception("Error al borrar los datos");
            }
           
        }
    }
}
