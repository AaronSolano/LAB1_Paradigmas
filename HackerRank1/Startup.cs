<<<<<<< HEAD
using LibraryService.WebAPI.Business.Interfaces;
using LibraryService.WebAPI.Business.Services;
using LibraryService.WebAPI.Data.DbContext;
using LibraryService.WebAPI.Data.Repositories;
=======
<<<<<<< HEAD
using LibraryService.WebAPI.Application.Interfaces.Repositories;
using LibraryService.WebAPI.Application.Services;
using LibraryService.WebAPI.Infrastructure.Data;
using LibraryService.WebAPI.Infrastructure.Repositories;
=======
using LibraryService.WebAPI.Application.Services;
using LibraryService.WebAPI.Infrastructure.Data;
>>>>>>> origin/main
>>>>>>> origin/main
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LibraryService.WebAPI
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
            // Add support for Dependency Injection for repositories and internal services
            services.AddTransient<ILibraryRepository, LibraryRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<ILibrariesService, LibrariesService>();
            services.AddTransient<IBooksService, BooksService>();

<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> origin/main
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            if (!string.IsNullOrEmpty(connectionString))
            {
                services.AddDbContext<LibraryContext>(options => options.UseNpgsql(connectionString));
            }
            else
            {
                services.AddDbContext<LibraryContext>(options => options.UseInMemoryDatabase("librarydb"));
            }

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });
<<<<<<< HEAD
=======
=======
            //services.AddDbContext<LibraryContext>(options => options.UseInMemoryDatabase("librarydb"));
            services.AddDbContext<LibraryContext>(options =>
    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
>>>>>>> origin/main
>>>>>>> origin/main

            // Add Swagger generation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "LibraryService API",
                    Version = "v1",
                    Description = "A simple example ASP.NET Core Web API for LibraryService"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsEnvironment("Testing"))
            {
                app.UseDeveloperExceptionPage();

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui, specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryService API v1");
                });
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
