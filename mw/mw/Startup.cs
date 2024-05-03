using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace mw
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add any services you need here
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>  //create a middleware
            {
                await context.Response.WriteAsync("Hello 1 middleware");
                await next();
                await context.Response.WriteAsync("1 middleware response");
            });

            app.Use(async (context, next) =>  //create a middleware
            {
                await context.Response.WriteAsync("2 middleware ");
                await next(); // callback argument
                await context.Response.WriteAsync("2 middleware response");
            });

            app.Use(async (context, next) =>  //create a middleware
            {
                await context.Response.WriteAsync("3 middleware ");
                await next(); // callback argument
                await context.Response.WriteAsync("3 middleware response");
            });

            app.UseRouting(); // routing is used to map a url to particular resource

            //without routing there is shown error whe we use useendpoint there must be routing

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => // here we are mapping //mapget-mapping a particular url to particular resource  (also we use map function)
                {
                    await context.Response.WriteAsync("Hello Bhawna"); //("/"= default ) domain is hitten to a output 
                });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/bhawna", async context => 
                {
                    await context.Response.WriteAsync("bye Bhawna"); //if we wrie in url / than only show hello bhawna when we write in url /bhawna than shown bye  bhawna 
                });
            });
        }
    }
}

// mapget will only handle the get request which are coming from the particular route(mapget will written default there)
// map will handle all the request which are coming from the particular route
