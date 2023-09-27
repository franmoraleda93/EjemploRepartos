using EjemploRepartos_service.Interface;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EjemploRepartos_API.Authorization
{
    public class AsyncAuthorizationFilterCliente : IAsyncAuthorizationFilter
    {
        private readonly IAuthorizeService _authorizeService;

        public AsyncAuthorizationFilterCliente(IAuthorizeService authorizeService)
        {
            _authorizeService = authorizeService;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            await _authorizeService.ValidateClienteAsync();

            return;
        }
    }
}
