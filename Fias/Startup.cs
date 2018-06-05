using System.IO;
using DatabaseAPI;
using DatabaseAPI.Interfaces;
using DatabaseAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Fias
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IAddressObjectService, AddressObjectService>();
            services.AddDbContext<FiasDatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("FiasDatabaseConnection"), b => b.MigrationsAssembly("Fias")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("Home/Error");
            }

            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            
            app.UseFileServer(new FileServerOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules")),
                RequestPath = "/node_modules",
                EnableDirectoryBrowsing = false
            });
        }
    }
}
