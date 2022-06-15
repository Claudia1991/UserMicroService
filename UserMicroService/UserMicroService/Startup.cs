using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using UserMicroService.Bussiness.Bussiness.Users;
using UserMicroService.DataAccess.Context;
using UserMicroService.DataAccess.DataAccess;
using UserMicroService.EntitiesProvider.DomainEntities;
using UserMicroService.EntitiesProvider.Enums;
using UserMicroService.EntitiesProvider.Interfaces.Bussiness;
using UserMicroService.EntitiesProvider.Interfaces.DataAccess;
using UserMicroService.EntitiesProvider.ModelEntities.Response;

namespace UserMicroService
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
            services.AddDbContext<UserMicroServiceContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UserMicroService")));
            services.AddTransient<IBaseRepository<User>, BaseRepository>();
            services.AddTransient<IUserBussiness, UserBussiness>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "User API",
                    Description = "An ASP.NET Core Web API for managing User",
                    TermsOfService = new Uri("https://example.com/terms")
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = "userApi/swagger";
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "text/html";
                    

                    await context.Response.WriteAsync(ResponseBase.FromFailure(Messages.ERROR).ToString(), System.Text.Encoding.ASCII);
                });
            });
        }
    }
}
