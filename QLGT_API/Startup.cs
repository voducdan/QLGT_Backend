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
using QLGT_API.Repository;
using QLGT_API.Services;
using QLGT_API.Constants;
using System.Text;

namespace QLGT_API
{
    public class Startup
    {
        private const string AllowAllOriginsPolicy = "AllowAllOriginsPolicy";
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

            // Khai báo các service và các Repository đc dùng
            services.AddScoped<UserService, UserService>();
            services.AddScoped<UserRepository, UserRepository>();
            services.AddScoped<JWTService, JWTService>();
            services.AddScoped<KhachHangRepository, KhachHangRepository>();

            ////configure strongly typed settings object
            var authSettingsSection = Configuration.GetSection("AuthSettings");
            services.Configure<AuthSettings>(authSettingsSection);

            var appSettings = authSettingsSection.Get<AuthSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.AuthSecret);

            services.AddCors(options =>
            {
                options.AddPolicy(AllowAllOriginsPolicy,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

                });
            });

            //services.AddScoped<IKhachHangData, SqlKhachHangData>();
            //services.AddScoped<IBangLaiData, SqlBangLaiData>();
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
