﻿using EjemploRepartos_database.Entities;
using EjemploRepartos_repository.Interface;
using EjemploRepartos_service.Interface;
using Microsoft.EntityFrameworkCore;

namespace EjemploRepartos_service.Service
{
    public class RepartoService : IRepartoService
    {
        private readonly IHeaderRepository _headerRepository;
        private readonly IRepartidorRepository _repartidorRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public RepartoService(IHeaderRepository headerRepository, 
                              IRepartidorRepository repartidorRepository, 
                              IPedidoRepository pedidoRepository)
        {
            _headerRepository = headerRepository;
            _repartidorRepository = repartidorRepository;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<bool> AceptarReparto(int idPedido)
        {
            Pedido? pedidoBDD = await _pedidoRepository.GetPedidoById(idPedido).FirstOrDefaultAsync();

            if(pedidoBDD == null)
            {
                throw new Exception("No existe el pedido");
            }

            if(pedidoBDD.IdEstadoPedido != 1)
            {
                throw new Exception("El pedido ya esta en reparto o entregado");
            }

            pedidoBDD.IdEstadoPedido = 2;
            pedidoBDD.FechaModificacion = DateTime.UtcNow;

            Repartidor? repartidor = await _repartidorRepository.GetRepartidorByOid(_headerRepository.GetOidRepartidor()).FirstOrDefaultAsync();

            Reparto repartoInsert = new Reparto()
            {
                IdPedido = pedidoBDD.IdPedido,
                IdRepartidor = repartidor.IdRepartidor,
                FechaCreacion = DateTime.UtcNow,
                FechaModificacion = DateTime.UtcNow                
            };

            RepartoUbicacion ubicacionInicial = new RepartoUbicacion()
            {
                IdReparto = repartoInsert.IdReparto,
                Ubicacion = "(42.7896,8.2569)",
                Ultima = true,
                FechaCreacion = DateTime.UtcNow,
                FechaModificacion = DateTime.UtcNow
            };

            repartoInsert.RepartoUbicacion.Add(ubicacionInicial);

            pedidoBDD.Reparto = repartoInsert;

            _pedidoRepository.UpdateGeneric(pedidoBDD);

            if (await _pedidoRepository.SaveChangesAsync() > 0)
            {
                return true;
            }
            else
            {
                throw new Exception("Error al guardar los datos");
            }
        }

        public async Task<string> GetUbicacionActual(int idPedido)
        {
            Pedido? pedidoBDD = await _pedidoRepository.GetPedidoByIdPedidoAndOidCliente(idPedido, _headerRepository.GetOidCliente()).FirstOrDefaultAsync();

            if (pedidoBDD == null)
            {
                throw new Exception("No existe el pedido o no tiene acceos");
            }

            if (pedidoBDD.IdEstadoPedido != 2 || pedidoBDD.Reparto == null)
            {
                throw new Exception("El pedido no esta en reparto");
            }

            pedidoBDD.FechaModificacion = DateTime.UtcNow;
            pedidoBDD.Reparto.FechaModificacion = DateTime.UtcNow;
            pedidoBDD.Reparto.RepartoUbicacion.Where(w => w.Ultima == true).ToList().ForEach(r => r.Ultima = false);
            pedidoBDD.Reparto.RepartoUbicacion.Where(w => w.Ultima == true).ToList().ForEach(r => r.FechaModificacion = DateTime.UtcNow);

            string nuevaUbicacion = "(1.1234,2.3456)";

            RepartoUbicacion ubicacionActual = new RepartoUbicacion()
            {
                IdReparto = pedidoBDD.Reparto.IdReparto,
                Ubicacion = nuevaUbicacion,
                Ultima = true,
                FechaCreacion = DateTime.UtcNow,
                FechaModificacion = DateTime.UtcNow
            };

            pedidoBDD.Reparto.RepartoUbicacion.Add(ubicacionActual);

            _pedidoRepository.UpdateGeneric(pedidoBDD);

            if (await _pedidoRepository.SaveChangesAsync() > 0)
            {
                return ubicacionActual.Ubicacion;
            }
            else
            {
                throw new Exception("Error al guardar los datos");
            }
        }
    }
}