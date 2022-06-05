using Autofac;
using Autofac.Extensions.DependencyInjection;
using GameProject.Infra;
using GameProject.Infra.Configs;
using GameProject.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Configuration;
using System.Globalization;

namespace xUnit
{
    public class Startup
    {

        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.Configure<DatabaseSettings>(
                 Configuration.GetSection(LaunchEnvironment.DbConnection));

            services.AddSingleton<MongoContext>();

            services.AddResponseCaching();

            services.AddMvc();
            services.AddLogging();
            services.AddMemoryCache();

            services.AddCors();


            services.AddControllers();

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

            var allowedOrigins = LaunchEnvironment.AllowedOrigins.Split(',');


            app.UseCors(builder =>
                builder.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod().AllowCredentials());

            var supportedCultures = new[] { new CultureInfo("pt-BR"), new CultureInfo("en") };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(new CultureInfo("pt-BR")),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            //app.UseMiddleware(typeof(ErrorHandlingMiddleware));

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
