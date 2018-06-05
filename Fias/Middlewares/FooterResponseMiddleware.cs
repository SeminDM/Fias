using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fias.Middlewares
{
    public class FooterResponseMiddleware
    {
        private RequestDelegate _next;

        public FooterResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IHostingEnvironment hostEnviroment)
        {
            var appName = hostEnviroment.ApplicationName;
            var contentRootPath = hostEnviroment.ContentRootPath;
            var environmentName = hostEnviroment.EnvironmentName;
            var webRootPath = hostEnviroment.WebRootPath;

            await httpContext.Response.WriteAsync($"{appName}\r\n");

            
        }
    }
}
