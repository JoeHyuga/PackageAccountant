using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using DAL;
using Common;
using BLL.IOperate;
using BLL.Operate;
using Common.ICommon;
using log4net.Repository;
using log4net;
using log4net.Config;
using System.IO;

namespace Web
{
    public class Startup
    {
        public static ILoggerRepository repository { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //load log4net configuration information
            repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSession(
                options =>
                {
                    options.IdleTimeout = TimeSpan.FromMinutes(30);
                }
                );
            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.AllowAnyOrigin().//允许任何来源的主机访问
                    AllowAnyMethod().
                    AllowAnyHeader().AllowCredentials();//指定处理cookie
                });
            });
            services.AddMvc(option =>
            {
                option.Filters.Add<Web.Common.log4net.HttpGlobalExceptionFilter>();
            });
            var connection = Configuration.GetConnectionString("PackageDatabase");
            services.AddDbContext<EFPackageDbContext>(options => options.UseSqlServer(connection));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//每次请求会获取同一个实例，即：在应用程序生命周期内，每次都会获得同一个实例

            #region 依赖注入
            services.AddTransient<IUserInfoBll, UserInfoBll>();
            services.AddTransient<IExcelBackupInofBll, ExcelBackupInofBll>();//每次请求会获取一个新实例
            services.AddTransient<IOfficeHelper, OfficeHelper>();
            services.AddTransient<IAccountItermDetailsBll, AccountItermDetailsBll>();
            #endregion

            UserDefineConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();
            //app.UseDeveloperExceptionPage();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(route =>
            {
                route.MapRoute(
                        name: "default",
                        template: "{controller=values}/{action=Index}/{id?}"
                    );
            });
        }

        public void UserDefineConfiguration()
        {
            var con = new ConfigurationBuilder().AddJsonFile("config.json");
            var config = con.Build();
            AppSetting.excelPath = config["excelPath"].ToString();
        }
    }
}
