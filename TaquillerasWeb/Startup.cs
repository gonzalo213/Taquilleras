using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Taquilleras.Data;
using TaquillerasWeb.Models;
using TaquillerasWeb.Services;
namespace TaquillerasWeb
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
            services.AddControllersWithViews();
            //services.AddDbContext<taquillerassContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TaquillerasWebContextConnection")));
            //services.AddScoped<CRUD1>();

            

            //services.AddTransient<ILogger, Implementacions>();

            //object factoryWrapper(IServiceProvider x) => new DefaultFactory(Configuration, () => factory(x));

            //services.TryAdd(new ServiceDescriptor(typeof(IDbConnectionFactory), factoryWrapper, lifetime));

            services.AddDbConnectionFactory((sp) => new System.Data.SqlClient.SqlConnection(), Configuration, ServiceLifetime.Scoped);
            //Serilog - implemetacones para bitacora
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
