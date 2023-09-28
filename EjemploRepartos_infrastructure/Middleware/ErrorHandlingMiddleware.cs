using EjemploRepartos_infrastructure.Exception;
using Microsoft.AspNetCore.Http;

namespace EjemploRepartos_infrastructure.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));           
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (System.Exception exception)
            {
                await this.HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, System.Exception exception)
        {
            context.Response.Clear();
            context.Response.ContentType = "application/json";

            var (Status, Message) = exception.CreateResponseMessage();
            context.Response.StatusCode = Status;
           

            return context.Response.WriteAsync(Message);
        }
    }
}
