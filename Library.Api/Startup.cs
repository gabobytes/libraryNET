using FluentValidation.AspNetCore;
using Library.Core.Interfaces;
using Library.Core.Services;
using Library.Infrastructure.Data;
using Library.Infrastructure.Filters;
using Library.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Library.Api
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers(
                
                options =>
                {
                    options.Filters.Add<GlobalExceptionFilter>();
                }
                ).AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            })
            .ConfigureApiBehaviorOptions(options => 
            {
                //options.SuppressModelStateInvalidFilter = true;
            });            ;


            services.AddTransient<IBookService, BookService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IEditorialService, EditorialService>();
            //services.AddTransient<ICityRepository, CityRepository>();
            //services.AddTransient<IBookRepository, BookRepository>();            
            services.AddTransient<IEditorialRepository, EditorialRepository>();
            //services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddScoped(typeof (IRepository<>), typeof(BaseRepository<>));
            
            services.AddTransient<IUnitOfWork, UnitOfWork>();


            //using database connection
            services.AddDbContext<libraryContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("libraryConnection"))
            );


           services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            }) ;

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
