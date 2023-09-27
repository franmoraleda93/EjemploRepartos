using EjemploRepartos_database.Context;
using EjemploRepartos_database.Entities;
using EjemploRepartos_repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EjemploRepartos_repository.Repository
{
    public class MasterRepository : IMasterRepository
    {
        private readonly EjemploRepartosContext _context;

        public MasterRepository(EjemploRepartosContext context)
        {
            _context = context;
        }

        public IQueryable<MaeEstadoPedido> GetMaeEstadoPedidos()
        {
            return _context.MaeEstadoPedido.Where(m => m.Habilitado).AsNoTracking();
        }

        public IQueryable<MaeComida> GetMaeComidas()
        {
            return _context.MaeComida.Where(m => m.Habilitado).AsNoTracking();
        }
    }
}
