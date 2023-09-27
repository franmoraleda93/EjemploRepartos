using EjemploRepartos_database.Context;
using EjemploRepartos_infrastructure.Filter;
using EjemploRepartos_repository.Interface;
using EjemploRepartos_repository.Repository;
using EjemploRepartos_service.Interface;
using EjemploRepartos_service.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Net.Http.Headers;

namespace EjemploRepartos_infrastructure.Startup
{
    public static class ConfigureServiceExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IMasterService, MasterService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IAuthorizeService, AuthorizeService>();
            services.AddScoped<IRepartoService, RepartoService>();

            services.AddScoped<IMasterRepository, MasterRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IHeaderRepository, HeaderRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IRepartidorRepository, RepartidorRepository>();
            services.AddScoped<IGeoLocationRepository, GeoLocationRepository>();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EjemploRepartosContext>();
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"EjemploRepartos Services {groupName}",
                    Version = groupName,
                    Description = "EjemploRepartos API",
                    Contact = new OpenApiContact
                    {
                        Name = "EjemploRepartos",
                        Email = "fran.moraleda93@gmail.com",
                        
                    }
                });

                options.OperationFilter<CustomHeaderSwaggerAttribute>();

            });
        }


        public static void AddHttpClientConfigure(this IServiceCollection services)
        {
            services.AddHttpClient("httpcertificate", c =>
            {
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
                {
                    NoCache = true,
                    NoStore = true,
                    MaxAge = new TimeSpan(0),
                    MustRevalidate = true
                };
            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                }

            });

            services.AddHttpClient();
        }
    }
}
