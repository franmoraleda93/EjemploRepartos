using EjemploRepartos_database.Entities;

namespace EjemploRepartos_repository.Interface
{
    public interface IPedidoRepository : IGenericRepository<Pedido>
    {
        IQueryable<Pedido> GetPedidoById(int idPedido);
        IQueryable<Pedido> GetPedidoByIdPedidoAndOidCliente(int idPedido, string oidCliente);
        IQueryable<Pedido> GetPedidoExtByIdPedidoAndOidCliente(int idPedido, string oidCliente);
    }
}
