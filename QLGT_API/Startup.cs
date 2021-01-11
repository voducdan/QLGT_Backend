using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using QLGT_API.Data;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace QLGT_API
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
            services.AddDbContextPool<QLGTDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("QLGTDB"));
            });
            services.AddScoped<IKhachHangData, SqlKhachHangData>();
            services.AddScoped<IBangLaiData, SqlBangLaiData>();
            services.AddScoped<IPhuongTienData, SqlPhuongTienData>();
      
            services.AddAuthorization(options => 
            {
                options.AddPolicy("CheckToken", policy =>
                {
                    policy.RequireAssertion(httpctx =>
                    {
                        if (true)
                        {
                            return true;
                        }
                    });
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //         Path.Combine(Directory.GetCurrentDirectory(), "static")),
            //    RequestPath = "/static"
            //});

            app.UseCors(c => { c.AllowAnyOrigin(); });

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
