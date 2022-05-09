using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTerritoryAPI.DBContexts;
using WebTerritoryAPI.Models;
using WebTerritoryAPI.Repository;
using Microsoft.EntityFrameworkCore;
using WebTerritoryAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace WebTerritoryAPI
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
            services.AddDbContext<TerritoryContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(options => { 
                options.AddPolicy("all", policy => {
                    policy.AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod();
                        //.AllowCredentials(); 
                }); 
            });

            services.AddTransient<IAreaRepository, AreaRepository>();
            services.AddTransient<IDistrictRepository, DistrictRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IStreetRepository, StreetRepository>();
            services.AddTransient<IHouseRepository, HouseRepository>();
            services.AddTransient<ISpotRepository, SpotRepository>();

            services.AddControllers();
        /*    services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebTerritoryAPI", Version = "v1" });
            });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
             //   app.UseSwagger();
             //   app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebTerritoryAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder =>
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
            );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
