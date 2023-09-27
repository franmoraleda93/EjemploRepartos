using EjemploRepartos_database.Context;
using EjemploRepartos_database.Entities;
using EjemploRepartos_repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EjemploRepartos_repository.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly EjemploRepartosContext _context;

        public ClienteRepository(EjemploRepartosContext context)
        {
            _context = context;
        }

        public IQueryable<Cliente> GetClienteByOid(string oidCliente)
        {
            return _context.Cliente.Where(m => m.OidCliente == oidCliente).AsNoTracking();
        }
    }
}
