using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hue.Managers;
using Hue.Managers.Interfaces;
using Hue.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Hue
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
            services.AddMvc();

            //Add interfaces
            services.AddTransient<IApiRequestManager, ApiRequestManager>();
            services.AddTransient<IHueApiLightsManager, HueApiLightsManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<AuthenticationMiddleWare>();

            app.UseMvc();
        }
    }
}
