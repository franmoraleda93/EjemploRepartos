using EjemploRepartos_service.Interface;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EjemploRepartos_API.Authorization
{
    public class AsyncAuthorizationFilterRepartidor : IAsyncAuthorizationFilter
    {
        private readonly IAuthorizeService _authorizeService;

        public AsyncAuthorizationFilterRepartidor(IAuthorizeService authorizeService)
        {
            _authorizeService = authorizeService;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            await _authorizeService.ValidateRepartidorAsync();

            return;
        }
    }
}
