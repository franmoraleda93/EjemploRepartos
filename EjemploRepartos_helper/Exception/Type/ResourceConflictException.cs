using System.Net;

namespace EjemploRepartos_helper.Exception.Type
{
    public class ResourceConflictException : BaseException
    {
        public ResourceConflictException(string mensaje = "Ha ocurrido un problema al crear el usuario") : base(mensaje)
        {
            this.StatusCode = HttpStatusCode.Conflict;
        }
    }
}
