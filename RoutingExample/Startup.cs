using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace RoutingExample
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RoutingExample", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RoutingExample v1"));
            }

            app.UseRouting();           

            app.UseAuthorization();

            //app.UseEndpoints(ConfigureRoute);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureRoute(IEndpointRouteBuilder routeBuilder)
        {
            routeBuilder.MapControllerRoute("Default", "{controller=Value}/{action=Index}/{id?}");
            
            routeBuilder.MapControllerRoute(
                name: "WithInt",
                pattern: "RandomName/{value:int}",
                defaults: new { controller = "Values", action = "WithInt", value = RouteParameter.Optional });
            
            routeBuilder.MapControllerRoute(
                name: "WithBoolean",
                pattern: "RandomName2/{value:bool}",
                defaults: new { controller = "Values", action = "WithBoolean", value = RouteParameter.Optional });
            
            routeBuilder.MapControllerRoute(
               name: "UserExample1",
               pattern: "UserJson",
               defaults: new { controller = "Values", action = "UserFromBody", value = RouteParameter.Optional });
            
            routeBuilder.MapControllerRoute(
               name: "UserExample2",
               pattern: "UserQuery",
               defaults: new { controller = "Values", action = "UserFromQuery", value = RouteParameter.Optional });
            
            routeBuilder.MapControllerRoute(
               name: "UserExample3",
               pattern: "UserForm",
               defaults: new { controller = "Values", action = "UserFromForm", value = RouteParameter.Optional });

            routeBuilder.MapControllerRoute(
               name: "UserExample4",
               pattern: "PostFile",
               defaults: new { controller = "Values", action = "HandlePostFile", value = RouteParameter.Optional });
        }
    }
}
