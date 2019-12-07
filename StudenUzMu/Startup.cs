using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using StudenUzMu.Interfaces;
using StudenUzMu.Models;
using StudenUzMu.Repository;

namespace StudenUzMu
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
             string conString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(conString));
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),
              @"C:\Users\Eshpo'latov Kamol\source\repos\StudenUzMu\StudenUzMu\wwwroot\Rasm\UqituvchiRasm\")));

            services.AddTransient<IUqituvFanRepository, UqituvFanRepository>();
            services.AddTransient<IJurnalVaqtiRepository, JurnalVaqtiRepository>();
            services.AddTransient<IJurnalRepository, JurnalRepository>();
            services.AddTransient<IYonalishRepository, YonalishRepository>();
            services.AddTransient<IFanlarRepository, FanlarRepository>();
            services.AddTransient<IFakultetRepository, FakultetRepository>();
            services.AddTransient<IUqituvchiRepository, UqituvchiRepository>();
            services.AddTransient<IUquvchiRepository, UquvchiRepository>();
            services.AddMvc();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
