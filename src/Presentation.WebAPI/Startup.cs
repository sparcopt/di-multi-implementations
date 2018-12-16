using Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Presentation.WebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //////////////////////////// Default injection ////////////////////////////
            services.AddScoped<IService, ServiceA>();
            services.AddScoped<IService, ServiceB>();
            services.AddScoped<IService, ServiceC>();

            //////////////////////////// Generic injection ////////////////////////////
            //services.AddScoped<IService<int>, GenericServiceA>();
            //services.AddScoped<IService<string>, GenericServiceB>();
            //services.AddScoped<IService<bool>, GenericServiceC>();

            //////////////////////////// Delegate injection ////////////////////////////
            //services.AddScoped<ServiceA>();
            //services.AddScoped<ServiceB>();
            //services.AddScoped<ServiceC>();

            //services.AddTransient<Func<ServiceEnum, IService>>(serviceProvider => key =>
            //{
            //    switch (key)
            //    {
            //        case ServiceEnum.A:
            //            return serviceProvider.GetService<ServiceA>();
            //        case ServiceEnum.B:
            //            return serviceProvider.GetService<ServiceB>();
            //        case ServiceEnum.C:
            //            return serviceProvider.GetService<ServiceC>();

            //        default:
            //            return null;
            //    }
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
