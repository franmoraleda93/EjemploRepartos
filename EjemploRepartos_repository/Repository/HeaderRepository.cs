using EjemploRepartos_repository.Interface;
using Microsoft.AspNetCore.Http;


namespace EjemploRepartos_repository.Repository
{
    public class HeaderRepository : IHeaderRepository
    {
        private readonly IHttpContextAccessor _httpContext;

        public HeaderRepository(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public string GetOidCliente()
        {
            return _httpContext.HttpContext.Request.Headers["OidCliente"].ToString();
        }

        public string GetOidRepartidor()
        {
            return _httpContext.HttpContext.Request.Headers["OidRepartidor"].ToString();
        }

    }
}
