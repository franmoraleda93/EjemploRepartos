using Microsoft.AspNetCore.Mvc;

namespace EjemploRepartos_API.Authorization
{
    public class AuthorizeRepartidor : TypeFilterAttribute
    {
        public AuthorizeRepartidor() : base(typeof(AsyncAuthorizationFilterRepartidor))
        {
            Arguments = new object[] { };
        }
    }
}
