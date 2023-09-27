using EjemploRepartos_database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploRepartos_repository.Interface
{
    public interface IClienteRepository
    {
        IQueryable<Cliente> GetClienteByOid(string oidCliente);
    }
}
