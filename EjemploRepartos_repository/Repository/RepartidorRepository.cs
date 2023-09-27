using EjemploRepartos_database.Context;
using EjemploRepartos_database.Entities;
using EjemploRepartos_repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EjemploRepartos_repository.Repository
{
    public class RepartidorRepository : IRepartidorRepository
    {
        private readonly EjemploRepartosContext _context;

        public RepartidorRepository(EjemploRepartosContext context)
        {
            _context = context;
        }

        public IQueryable<Repartidor> GetRepartidorByOid(string oidRepartidor)
        {
            return _context.Repartidor.Where(m => m.OidRepartidor == oidRepartidor).AsNoTracking();
        }
    }
}
