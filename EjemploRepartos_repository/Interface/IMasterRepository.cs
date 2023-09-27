using EjemploRepartos_database.Entities;

namespace EjemploRepartos_repository.Interface
{
    public interface IMasterRepository
    {
        IQueryable<MaeEstadoPedido> GetMaeEstadoPedidos();
        IQueryable<MaeComida> GetMaeComidas();
    }
}
