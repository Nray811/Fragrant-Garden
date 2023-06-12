using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetFragrant_Test.Data;
using PetFragrant_Test.Interface;
using PetFragrant_Test.Interfaces;
using PetFragrant_Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFragrant_Test
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
            services.AddControllersWithViews();

            //�[�JCookie����, �P�ɳ]�w�ﶵ
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        //�w�]�n�J���Һ��}��Account/Login, �Y�Q�ܧ�~�ݭn�]�wLoginPath
                        //options.LoginPath = new PathString("/Account/Login/");
                        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                        options.SlidingExpiration = true;
                        options.AccessDeniedPath = "/Account/Forbidden/";
                    });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsAdmin", policy =>
                {
                    policy.RequireClaim("IsAdmin", "True");
                });
            });
            services.AddDbContext<PetContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("PetContext")));

            services.AddTransient<AccountService>();

            services.AddSingleton<IHashService, HashService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
