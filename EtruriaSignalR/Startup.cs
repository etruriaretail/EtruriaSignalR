using EtruriaSignalR.Hub;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtruriaSignalR
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
            services.AddCors();
            services.AddControllers();
            services.AddSignalR();
            
            //services.AddCors(options =>
            //{
            //    //options.AddDefaultPolicy(builder =>
            //    //{
            //    //    builder
            //    //        .WithOrigins("http://localhost:4201", "http://localhost")
            //    //        .AllowCredentials()
            //    //        .AllowAnyMethod()
            //    //        .AllowAnyHeader();
            //    //});

            //    options.AddPolicy(name: "CorsPolicy", builder =>
            //     {
            //         builder
            //             .WithOrigins("http://localhost:4201", "http://localhost")
            //             .AllowCredentials()
            //             .AllowAnyMethod()
            //             .AllowAnyHeader();
            //     });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseCors(x =>
            {
                x.WithOrigins("http://localhost:4201");
                x.AllowAnyMethod();
                x.AllowAnyHeader();
                x.AllowCredentials();
            });

            app.UseRouting();

            //app.UseCors("CorsPolicy");

            app.UseAuthorization();

            //var webSocketOptions = new WebSocketOptions()
            //{
            //    KeepAliveInterval = TimeSpan.FromSeconds(120),
            //};
            //webSocketOptions.AllowedOrigins.Add("*");

            //app.UseWebSockets(webSocketOptions);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chathub");
            });
        }
    }
}
