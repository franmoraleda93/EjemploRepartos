using Microsoft.AspNetCore.Mvc;

namespace EjemploRepartos_API.Authorization
{
    public class AuthorizeCliente : TypeFilterAttribute
    {
        public AuthorizeCliente() : base(typeof(AsyncAuthorizationFilterCliente))
        {
            Arguments = new object[] { };
        }
    }
}
