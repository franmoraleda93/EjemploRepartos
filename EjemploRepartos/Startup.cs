using EjemploRepartos_infrastructure.Startup;
using EjemploRepartos_service.Dto.DtoMapper;
using Microsoft.AspNetCore.Mvc;

[assembly: ApiController]
[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace EjemploRepartos_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(x => x.AllowEmptyInputInBodyModelBinding = true);

            services.AddAutoMapper(typeof(DtoMappingMaster));            

            services.AddSwagger();

            services.AddDependencyInjection();

            services.AddDbContext(Configuration);

            services.AddHttpClientConfigure();

            services.AddHttpContextAccessor();
            services.AddApplicationInsightsTelemetry();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());               // allow credentials

            app.UseSwagger(Configuration);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();        

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
