using System.Net;

namespace EjemploRepartos_helper.Exception.Type
{
    public class ResourceForbiddenException : BaseException
    {
        public ResourceForbiddenException(string mensaje = "El recurso solicitado no existe.") : base(mensaje)
        {
            this.StatusCode = HttpStatusCode.Forbidden;
        }
    }
}
