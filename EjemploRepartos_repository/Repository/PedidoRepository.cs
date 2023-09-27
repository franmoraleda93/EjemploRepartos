using EjemploRepartos_database.Context;
using EjemploRepartos_database.Entities;
using EjemploRepartos_repository.Interface;

namespace EjemploRepartos_repository.Repository
{
    public class PedidoRepository : GenericRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(EjemploRepartosContext context) : base(context)
        {

        }
    }
}
