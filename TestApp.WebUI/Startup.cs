using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestApp.BusinessLogic.Abstract;
using TestApp.BusinessLogic.Services;
using TestApp.Domain.Abstract;
using TestApp.Domain.Concrete;
using TestApp.Domain.Data;
using System.Security.Principal;

namespace TestApp.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        // В конструкторе класса получаем данные конфигурации из файла appsettings.json
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:ConnectionStrings:TestDb"],
                    o => o.MigrationsAssembly("TestApp.Domain")
                ));

            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IDocumentTypeService, DocumentTypeService>();
            services.AddTransient<IFileEntityService, FileEntityService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddHttpContextAccessor();
            services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseExceptionHandler("/Error/Index");

            app.UseStatusCodePages();

            app.UseStaticFiles();

            app.UseRouting();

            //app.UseSession();

            //app.UseMiddleware<CheckAuthMiddleware>();

            //app.UseAuthentication();

            //app.UseAuthorization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}