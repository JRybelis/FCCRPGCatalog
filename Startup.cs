using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCCRPGCatalog.Repositiories;
using FCCRPGCatalog.Repositories;
using FCCRPGCatalog.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

namespace FCCRPGCatalog
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
            services.AddSingleton<IMongoClient>(ServiceProvider =>
            {
                var settings = Configuration.GetSection(nameof(MongoDBSettings))
                    .Get<MongoDBSettings>(); // contains the connection settings from MongoDBSettings.cs, where it builds the connection string from appsettings.json
                
                return new MongoClient(settings.ConnectionString);
            });
            
            services.AddSingleton<IItemsRepository, MongoDBItemsRepository>();//dependency on MongoDregistered
            
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FCCRPFCatalog"
                    , Description = null
                    , Version = "Version 1"
                    , TermsOfService = null
                    , Contact = null
                    , License = null
                    , Extensions = null
                    ,
                });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Endpoints" ));
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

