using ApiPersonajesCore0Auth.Data;
using ApiPersonajesCore0Auth.Repositories;
using ApiPersonajesCore0Auth.Token;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPersonajesCore0Auth
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            String cadena =
                this.Configuration.GetConnectionString("DefaultConnection");
            services.AddTransient<RepositoryPersonajes>();
            services.AddDbContext<PersonajesContext>(options
                => options.UseSqlServer(cadena));
            //SWAGGER
            services.AddSwaggerGen(
                c =>
                {
                    //VERSION 2 Y VERSION 1
                    c.SwaggerDoc(
            name: "v1", new OpenApiInfo
            {
                Title = "Api USUARIOSAZUREs Seguridad OAuth"
            ,
                Version = "v1",
                Description = "Ejemplo de seguridad OAuth Token"
            });
                });

            HelperToken helper = new HelperToken(this.Configuration);
            //AÑADIMOS AUTENTIFICACION A NUESTRO SERVICIO
            services.AddAuthentication(helper.GetAuthOptions())
                .AddJwtBearer(helper.GetJwtOptions());

            services.AddControllers();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            //UI INDICA DONDE VA A VISUALIZAR EL USUARIO LA DOCUMENTACION
            //GENERADA POR SWAGGER EN NUESTRO SERVIDOR
            app.UseSwaggerUI(
                c =>
                {
                    //DEBEMOS CONFIGURAR LA URL DEL SERVIDOR
                    //PARA LA DOCUMENTACION
                    c.SwaggerEndpoint(
                        url: "/swagger/v1/swagger.json"
                        , name: "Api v1");
                    c.RoutePrefix = "";
                });


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
