using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploRepartos_service.Interface
{
    public interface IRepartoService
    {
        Task<bool> AceptarReparto(int idPedido);
        Task<string> GetUbicacionActual(int idPedido);
    }
}
