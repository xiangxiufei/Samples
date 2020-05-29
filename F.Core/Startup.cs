using Autofac;
using F.Core.IRepository;
using F.Core.IService;
using F.Core.Model;
using F.Core.Repository;
using F.Core.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace F.Core
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
            services.AddControllers();

            var basePath = AppContext.BaseDirectory;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "V1",
                    Title = "F.Core",
                });

                c.IncludeXmlComments(Path.Combine(basePath, "Core.xml"), true);
                c.IncludeXmlComments(Path.Combine(basePath, "Model.xml"), true);
            });

            services.AddDbContext<MySqlContext>(options => options.UseMySQL(Configuration["ConnectionStrings:MySql"]));

            //services.AddScoped<IStudentRepository, StudentRepository>();
            //services.AddScoped<ITeacherRepository, TeacherRepository>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IStudentService, StudentService>();
            //services.AddScoped<ITeacherService, TeacherService>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var basePath = AppContext.BaseDirectory;
            var service = Path.Combine(basePath, "F.Core.Service.dll");
            var repository = Path.Combine(basePath, "F.Core.Repository.dll");

            builder.RegisterAssemblyTypes(Assembly.LoadFrom(service))
                      .AsImplementedInterfaces()
                      .InstancePerDependency();

            builder.RegisterAssemblyTypes(Assembly.LoadFrom(repository))
                   .AsImplementedInterfaces()
                   .InstancePerDependency();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "F.Core API V1");
                c.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}