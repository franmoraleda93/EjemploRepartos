using EjemploRepartos_database.Entities;
using EjemploRepartos_repository.Interface;
using EjemploRepartos_service.Interface;
using Microsoft.EntityFrameworkCore;

namespace EjemploRepartos_service.Service
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IRepartidorRepository _repartidorRepository;
        private readonly IHeaderRepository _headerRepository;

        public AuthorizeService(IClienteRepository clienteRepository, 
                                IRepartidorRepository repartidorRepository, 
                                IHeaderRepository headerRepository)
        {
            _clienteRepository = clienteRepository;
            _repartidorRepository = repartidorRepository;
            _headerRepository = headerRepository;
        }

        public async Task ValidateClienteAsync()
        {
            string? oidCliente = _headerRepository.GetOidCliente();
            if (string.IsNullOrEmpty(oidCliente))
            {
                throw new Exception("Oid de cliente erroneo");
            }

            Cliente? cliente = await _clienteRepository.GetClienteByOid(oidCliente).FirstOrDefaultAsync();

            if(cliente == null)
            {
                throw new Exception("Oid de cliente no existe");
            }
        }
        public async Task ValidateRepartidorAsync() 
        {
            string? oidRepartidor = _headerRepository.GetOidRepartidor();
            if (string.IsNullOrEmpty(oidRepartidor))
            {
                throw new Exception("Oid de reparidor erroneo");
            }

            Repartidor? repartidor = await _repartidorRepository.GetRepartidorByOid(oidRepartidor).FirstOrDefaultAsync();

            if (repartidor == null)
            {
                throw new Exception("Oid de repartidor no existe");
            }
        }
    }
}
