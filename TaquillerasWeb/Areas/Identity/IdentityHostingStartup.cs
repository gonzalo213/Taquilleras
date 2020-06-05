using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaquillerasWeb.Data;

[assembly: HostingStartup(typeof(TaquillerasWeb.Areas.Identity.IdentityHostingStartup))]
namespace TaquillerasWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TaquillerasWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TaquillerasWebContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<TaquillerasWebContext>();
            });
        }
    }
}