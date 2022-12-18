using AppointmentSystem.Business.Abstract;
using AppointmentSystem.Business.Concrete;
using AppointmentSystem.DataAccess;
using AppointmentSystem.DataAccess.Abstract;
using AppointmentSystem.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentSystem.Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AppointmentSystem.Api", Version = "v1" });
            });

            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(Configuration["ConnectionString"]));
            services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IAppointmentService, AppointmentManager>();

            services.AddScoped<IAppointmentServiceRepository, AppointmentServiceRepository>();
            services.AddScoped<IAppointmentServiceService, AppointmentServiceManager>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<ICoiffeurRepository, CoiffeurRepository>();
            services.AddScoped<ICoiffeurService, CoiffeurManager>();

            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentService, CommentManager>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerManager>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeManager>();

            services.AddScoped<IEmployeeServiceRepository, EmployeeServiceRepository>();
            services.AddScoped<IEmployeeServiceService, EmployeeServiceManager>();

            services.AddScoped<IGalleryRepository, GalleryRepository>();
            services.AddScoped<IGalleryService, GalleryManager>();

            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IServiceService, ServiceManager>();

            services.AddScoped<IWorkingHoursRepository, WorkingHoursRepository>();
            services.AddScoped<IWorkingHoursService, WorkingHoursManager>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AppointmentSystem.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors((o =>
            {
                o.WithOrigins("http://localhost:3000")

                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
            }));
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
