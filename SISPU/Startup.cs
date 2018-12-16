using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SISPU.Models;
using Microsoft.AspNetCore.Identity;
using System.Buffers;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;
using NLog.Web;
using Hangfire;
using SISPU.ViewModel;

namespace SISPU
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();


            // services.AddQuartz(new QuartezOptions {});
            // получаем строку подключения из файла конфигурации
            string connection = Configuration.GetConnectionString("DefaultConnection");

            // TODO - move connection string outside from appsettings - to file, that excluded from git
            // добавляем контекст в качестве сервиса в приложение
            services.AddDbContext<Context>(options => options.UseSqlServer(connection));

            // HangFire add
            //services.AddHangfire(x => x.UseSqlServerStorage(connection));

            // Сервисы для Identity
            //  services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<Context>();

            services.AddCors(options =>
            {
                options.AddPolicy(
                    "CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            // Add framework services.
            // Disabling self referencing loop when transfering JSON
            services.AddMvc(options =>
            {
              

                 options.OutputFormatters.Clear();
                 options.OutputFormatters.Add(new JsonOutputFormatter(
                    new JsonSerializerSettings()
                 {
                  ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                 }, ArrayPool<char>.Shared));

            }).AddJsonOptions(opts =>
            {
                opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });



            // services.Configure<S2SAppSettings>(Configuration.GetSection("AdoxioConnect:dynS2S"));
            //  services.AddSingleton<CrmContextCore>();

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
            });

            services.AddScoped<IGrouptimetableRepository, GrouptimetableRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IFacultyRepository, FacultyRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            // for logging
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseHangfireDashboard();
            //app.UseHangfireServer();
            app.UseCors("CorsPolicy");

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 &&
                   !Path.HasExtension(context.Request.Path.Value) &&
                   !context.Request.Path.Value.StartsWith("/api/"))
                {
                    await next();
                }
            });

        }
    }
}
