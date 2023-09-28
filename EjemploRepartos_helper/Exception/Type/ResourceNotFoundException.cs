using System.Net;

namespace EjemploRepartos_helper.Exception.Type
{
    public class ResourceNotFoundException : BaseException
    {
        public ResourceNotFoundException(string mensaje = "El recurso solicitado no existe.") : base(mensaje)
        {
            this.StatusCode = HttpStatusCode.NotFound;
        }
    }
}
