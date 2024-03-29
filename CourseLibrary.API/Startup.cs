using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourseLibrary.API.DbContexts;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MediatR.Pipeline;
using MediatR;

namespace CourseLibrary.API
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
            services.AddControllers(setupAction =>
                {
                    setupAction.ReturnHttpNotAcceptable = true;
                }).AddXmlDataContractSerializerFormatters();

           
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
           // services.AddScoped<ICourseLibraryRepository, CourseLibraryRepository>();
            services.AddSingleton<IBooksRepository, BooksRepository>();
            services.AddSingleton<IArtistsRepository, ArtistsRepository>();

            //services.AddDbContext<CourseLibraryContext>(options =>
            //{
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("CourseLibraryDB"));
            //});

            //services.AddDbContext<CourseLibraryContext>(options =>
            //{
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("CourseLibraryDB"));
            //});

            //services.AddDbContext<AppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMediatR(typeof(Startup));
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
