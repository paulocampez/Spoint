using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Spoint.Api.Configurations;
using MediatR;
using Customer.Infra.CrossCutting;
using Core.Domains.CommandHandler;
using Core.Domains.Interfaces;
using Core.Domains.Repository;
using Customer.Command;
using Customer.CommandStack.Handlers;

namespace Spoint.Api
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
            services.AddSwaggerGen();
            services.AddControllers();

            services.AddScoped<IMediatrHandler, MediatrHandler>();
            services.AddScoped<IMongoSequenceRepository, MongoSequenceRepository>();
            services.AddAutoMapperSetup();
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IRequestHandler<CreateCustomerCommand, bool>, CustomerCommandHandler>();
            Bootstrapper.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dg Bar");
            });
        }
    }
}
