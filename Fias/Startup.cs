using System;
using System.IO;
using DatabaseAPI;
using DatabaseAPI.Interfaces;
using DatabaseAPI.Models;
using DatabaseAPI.Services;
using Fias.Infrastructure.Mappers;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.OData.Edm;

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
            // add odata services
            services.AddOData();
            // add mvc services
            services.AddMvc(options => options.MaxModelValidationErrors = 50);
            // configure authentication
            services.Configure<IdentityOptions>(options =>
            {
                // password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                // lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = false;

                // user settings
                options.User.RequireUniqueEmail = true;

                // sign in settings
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });
            var authType = Configuration.GetSection("Authentication");
            services.AddAuthentication(authType.Value == "Windows" ? IISDefaults.AuthenticationScheme : CookieAuthenticationDefaults.AuthenticationScheme);

            // configue cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/User/Login";
                options.SlidingExpiration = true;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
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
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                routes.Select().MaxTop(10000).Count().Expand().Filter().OrderBy();
                routes.MapODataServiceRoute("OData", "odata", GetEdmModel());
            });

            app.UseStaticFiles();

            app.UseFileServer(new FileServerOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules")),
                RequestPath = "/node_modules",
                EnableDirectoryBrowsing = false
            });
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<AddressObject>("AddressObjects");
            return builder.GetEdmModel();
        }
    }
}
