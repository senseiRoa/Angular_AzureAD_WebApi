using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using GestorTutelas.webApi.DBContext;
using GestorTutelas.webApi.DBContext.Repository.Implementations;
using GestorTutelas.webApi.Services;

namespace GestorTutelas.webApi
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
            services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
                .AddAzureADBearer(options => Configuration.Bind("AzureAd", options));

            services.AddCors((options =>
            {
                options.AddDefaultPolicy(builder =>
               builder.SetIsOriginAllowed(_ => true)
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials()
               .WithOrigins("http:localhost:4200", "http://accionesvirtuales.cortesuprema.gov.co/")
               );
            }));

            var conectionStringPostgres = Configuration.GetValue<string>("ConnectionStrings:DBPostgres");
            services.AddDbContext<ApiDbContext>(options => options.UseNpgsql(conectionStringPostgres));


            services.AddScoped<ArchivoExpedienteRepository>();
            services.AddScoped<DepartamentoRepository>();
            services.AddScoped<ExpedienteDigitalRepository>();
            services.AddScoped<MunicipioRepository>();
            services.AddScoped<ParametroRepository>();
            services.AddScoped<PersonaRepository>();
            services.AddScoped<PersonaRolRepository>();
            services.AddScoped<PersonasExpedienteRepository>();
            services.AddScoped<ProcesoExpedienteRepository>();
            services.AddScoped<RolRepository>();
            services.AddScoped<UsuarioRepository>();
            services.AddScoped<ExpedienteService>();

            services.AddScoped<IFileClient, LocalFileClient>(client =>
            {
                var fileRoot = Configuration.GetValue<string>("fileRoot");
                return new LocalFileClient(fileRoot);
            });
            //singleton
            // services.AddSingleton<IUsuarioRepository, UsuarioRepository>();

            //services.AddControllers();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            // services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");                  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.	               
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            // app.UseRouting();
            // app.UseAuthentication();
            // app.UseAuthorization();

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllers();
            // });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
