using FluentValidation.AspNetCore;
using GestorUsuarios.Core.Interfaces;
using GestorUsuarios.Infraestructure.Data;
using GestorUsuarios.Infraestructure.Filter;
using GestorUsuarios.Infraestructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace GestorUsuarios.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers().AddNewtonsoftJson(options => 
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; 
            }).ConfigureApiBehaviorOptions(options => {
                //options.SuppressModelStateInvalidFilter = true;
            });
            //obtener cadena de conexion a bd
            services.AddDbContext<GestionContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Gestor")));
            // inyeccion de dependencias
            services.AddTransient<IUsuarioRepository, UsuariosRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<ITareaRepository, TareaRepository>();

            // a?adiendo swagger al proyecto

            services.AddSwaggerGen(s => s.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "1.0",
                Title = "Api Gestor",
                Description = "api gestor de tareas y usuarios"

            }));
            services.AddCors(options => options.AddPolicy("AllowWebApp",
                                                                        builder => builder.AllowAnyOrigin()
                                                                                            .AllowAnyMethod()
                                                                                            .AllowAnyHeader()));

            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(options => {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());            
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(sw => {

                sw.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Gestor");
                sw.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();
            app.UseCors("AllowWebApp");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
