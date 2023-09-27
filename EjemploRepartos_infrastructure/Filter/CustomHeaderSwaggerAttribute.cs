using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EjemploRepartos_infrastructure.Filter
{
    public class CustomHeaderSwaggerAttribute : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "OidCliente",
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema() { Type = "string" },
                Required = false
            });            
        }
    }
}
