using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Programming_Reference_Website.Factories;
using Programming_Reference_Website.Factories.Interfaces;
using Programming_Reference_Website.Models;
using Programming_Reference_Website.Persistance;
using Programming_Reference_Website.Services;
using Programming_Reference_Website.Services.Interfaces;

namespace Programming_Reference_Website
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            // this.Configuration = builder.Build();
        }        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ProgrammingReferenceDbContext>(options => {
                options.UseSqlServer("Server=localhost,5100;Database=SportsStore;User Id=sa;Password=mySecret123;MultipleActiveResultSets=true");
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddScoped<IPasswordProtectionService, PasswordProtectionService>();
            services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }            

            var context = serviceProvider.GetService<ProgrammingReferenceDbContext>();

            context.Users.Add(new User { Email = "test" });

            context.SaveChanges();

            Debug.WriteLine(context.Users.ToListAsync().Result[0].Email);

            foreach(var user in context.Users.ToListAsync().Result)
            {
                context.Users.Remove(user);
            }

            context.SaveChanges();
            

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }

}
