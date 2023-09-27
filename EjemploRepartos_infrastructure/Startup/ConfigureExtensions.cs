using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace EjemploRepartos_infrastructure.Startup
{
    public static class ConfigureExtensions
    {
        public static void UseSwagger(this IApplicationBuilder app, IConfiguration Configuration)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EjemploReparos V1");
                c.DocumentTitle = "Swagger EjemploRepartos Services";
                c.DisplayRequestDuration();
            });

        }
    }
}
