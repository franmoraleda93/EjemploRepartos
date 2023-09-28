using System.Net;

namespace EjemploRepartos_helper.Exception.Type
{
    public class ResourceBadRequestException : BaseException
    {
        public ResourceBadRequestException(string mensaje = "Solicitud Incorrecta.") : base(mensaje)
        {
            this.StatusCode = HttpStatusCode.BadRequest;
        }
    }
}
