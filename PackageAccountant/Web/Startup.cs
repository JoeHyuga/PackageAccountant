﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Web.Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Web
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

            services.AddCors(options=> {
                options.AddPolicy("any",builder=> {
                    builder.AllowAnyOrigin().//允许任何来源的主机访问
                    AllowAnyMethod().
                    AllowAnyHeader().AllowCredentials();//指定处理cookie
                });
            });

            var connection = Configuration.GetConnectionString("PackageDatabase");
            services.AddDbContext<EFDbContext>(options => options.UseSqlServer(connection));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc(route=> 
            {
                route.MapRoute(
                        name: "default",
                        template: "{controller=values}/{action=Index}/{id?}"
                    );
            });
        }
    }
}