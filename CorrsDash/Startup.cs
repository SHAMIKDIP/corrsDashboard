using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorrsDash.IRepositories;
using CorrsDash.Models;
using CorrsDash.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CorrsDash
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
               
            });
           // services.AddApplicationInsightsTelemetry(Configuration["APPINSIGHTS_INSTRUMENTATIONKEY"]);
            services.AddApplicationInsightsTelemetry();
            services.AddMvc();
           // services.AddControllers().AddNewtonsoftJson();
            var connection = Configuration.GetConnectionString("databaseconnection");
            //services.AddDbContextPool<corrsdatabaseContext>(options => options.UseNpgsql(connection));
            services.AddDbContext<corrsdatabaseContext>(options => options.UseNpgsql(connection));
            services.AddScoped<ICorrsplants,corrsplantscs>();
            services.AddScoped<IMetricsview,metricsview>();
            services.AddScoped<IShopFloorComformance,Shopfloorcomformance>();
            services.AddScoped<IAddreasoncode,Addreasoncode>();
            

            //services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            // app.UseCors(options => options.AllowAnyOrigin());
            app.UseHttpsRedirection();
            // app.UseMvc();
           
            app.UseRouting();
            //app.UseCors();
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
