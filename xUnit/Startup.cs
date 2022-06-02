using Autofac;
using Autofac.Extensions.DependencyInjection;
using Game.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;
using System.Linq;

namespace xUnit
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>();
            services.AddResponseCaching();

            //AutoMapperConfiguration.RegisterMappings(services);
            //NativeInjectorBootStrapper.RegisterServices(services);

            services.AddControllers()
              .AddNewtonsoftJson(options =>
              {});

            services.AddMvc();
            services.AddLogging();
            services.AddMemoryCache();
           
            services.AddCors();

          
          
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSignalR();

            var container = new ContainerBuilder();
            container.RegisterModule(new AutoFacModule());
            container.Populate(services);
            return new AutofacServiceProvider(container.Build());

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();

            //Os arquivos estáticos são publicamente armazenáveis em cache por 600 segundos:
            const string cacheMaxAge = "600";
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append(
                         "Cache-Control", $"public, max-age={cacheMaxAge}");
                },

            });


            app.UseCors(builder =>
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());

            var supportedCultures = new[] { new CultureInfo("pt-BR"), new CultureInfo("en") };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(new CultureInfo("pt-BR")),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapHub<AppHub>("/apphub");
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();

            });

        }
    }
}
