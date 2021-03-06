using Application.CustomCQRS;
using Application.CustomCQRS.Commands.Products;
using Application.CustomCQRS.Handlers.Products;
using Application.CustomCQRS.Interfaces;
using Application.CustomCQRS.Models;
using Application.CustomCQRS.Queries.Products;
using Application.Domain.Entities;
using Application.Interfaces;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Persistence.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace API
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
            services.AddSingleton<IDataAccess<Product>, DemoDataAccess>();
           
            //custom CQRS
            services.AddSingleton<Messages>();
            services.AddTransient<ICommandHandler<CreateNewProductCommand>, CreateNewProductCommandHandler>();
            services.AddTransient<IQueryHandler<GetProductByIdCustomQuery,Result<Product>>, GetProductByIdCustomQueryHandler>();
            services.AddTransient<IQueryHandler<GetProductListCustomQuery,Result<List<Product>>>, GetProductListCustomQueryHandler>();
            //services.AddSingleton(typeof(IDataAccess<>),typeof(DemoDataAccess));
      
            
            services.AddMediatR(typeof(GetProductListQuery).Assembly);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
