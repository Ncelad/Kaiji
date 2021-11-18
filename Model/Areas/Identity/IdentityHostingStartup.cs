using System;
using Kaiji.Areas.Identity.Data;
using Kaiji.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Kaiji.Areas.Identity.IdentityHostingStartup))]
namespace Kaiji.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<KaijiContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("KaijiContextConnection")));

                services.AddDefaultIdentity<KaijiUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<KaijiContext>();
            });
        }
    }
}