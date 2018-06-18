using System;
using System.IO;
using DatabaseAPI;
using DatabaseAPI.Interfaces;
using DatabaseAPI.Models;
using DatabaseAPI.Services;
using Fias.Infrastructure.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
            // add mvc services
            services.AddMvc(options => options.MaxModelValidationErrors = 50);
            // add database context
            services.AddDbContext<FiasDatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("FiasDatabaseConnection"), b => b.MigrationsAssembly("Fias")));
            // add identity to database context
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<FiasDatabaseContext>()
                .AddDefaultTokenProviders();
            // add application services
            services.AddScoped<IAddressObjectService, AddressObjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<AddressObjectMapper>();
            services.AddSingleton<UserMapper>();
            // configure authentication
            services.Configure<IdentityOptions>(options =>
            {
                // password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;

                // lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // user settings
                options.User.RequireUniqueEmail = true;
            });
            // configue cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
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

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseFileServer(new FileServerOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules")),
                RequestPath = "/node_modules",
                EnableDirectoryBrowsing = false
            });
        }
    }
}
