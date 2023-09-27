using EjemploRepartos_database.Context;
using EjemploRepartos_database.Entities;
using EjemploRepartos_repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EjemploRepartos_repository.Repository
{
    public class PedidoRepository : GenericRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(EjemploRepartosContext context) : base(context)
        {

        }

        public IQueryable<Pedido> GetPedidoById(int idPedido)
        {
            return _context.Pedido.
                Include(i => i.Reparto)
                    .ThenInclude(t => t.RepartoUbicacion)
               .Where(x => x.IdPedido == idPedido)
               .AsNoTracking();
        }

        public IQueryable<Pedido> GetPedidoByIdPedidoAndOidCliente(int idPedido, string oidCliente)
        {
            return _context.Pedido.
                Include(i => i.Reparto)
                    .ThenInclude(t => t.RepartoUbicacion)
               .Include(i => i.IdClienteNavigation)
               .Where(x => x.IdPedido == idPedido && x.IdClienteNavigation.OidCliente == oidCliente)
               .AsNoTracking();
        }

        public IQueryable<Pedido> GetPedidoExtByIdPedidoAndOidCliente(int idPedido, string oidCliente)
        {
            return _context.Pedido
               .Include(i => i.PedidoComida) 
               .Include(i => i.Reparto)
                    .ThenInclude(t => t.RepartoUbicacion)
               .Include(i => i.IdClienteNavigation)
               .Where(x => x.IdPedido == idPedido && x.IdClienteNavigation.OidCliente == oidCliente)
               .AsNoTracking();
        }
    }
}
