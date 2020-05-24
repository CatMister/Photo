using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using HuxingService.Login;
using Autofac.Extensions.DependencyInjection;
using HuxingMvc.Config;
using HuxingEntity;
using Microsoft.AspNetCore.Authentication.Cookies;
using HuxingService;
using System.IO;
using HuxingModel.Global;
using Microsoft.Extensions.FileProviders;

namespace HuxingMvc
{


    public class Startup
    {


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.RegisterConfig(Configuration);
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc(options =>
            {
                options.Filters.Add<ExceptionFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
           {
               option.LoginPath = new PathString("/Login");
           });

            var builder = new ContainerBuilder();
            builder.RegisterType<PhotoClient>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(LoginService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.Populate(services);
            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();
            app.UseAuthentication();
            var folderName = $"{AppDomain.CurrentDomain.BaseDirectory}\\{SystemConfigModel.PhotoFileName}";
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            app.UseFileServer(new FileServerOptions()
            {
                FileProvider = new PhysicalFileProvider(folderName),
                RequestPath = new PathString($"/{SystemConfigModel.PhotoFileName}"),
                EnableDirectoryBrowsing = true
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
