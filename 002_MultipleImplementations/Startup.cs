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

namespace _002_MultipleImplementations
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
            services.AddTransient<AddOperation>();
            services.AddTransient<SubtractOperation>();
            services.AddTransient<MultiplyOperation>();
            services.AddTransient<DivideOperation>();
            services.AddTransient<Func<MathOperationType, IMathOperation>> (serviceProvider => key =>
           {
               switch(key)
               {
                    case MathOperationType.Add:
                       return serviceProvider.GetService<AddOperation>();
                    case MathOperationType.Subtract:
                        return serviceProvider.GetService<SubtractOperation>();
                    case MathOperationType.Multiply:
                        return serviceProvider.GetService<MultiplyOperation>();
                    case MathOperationType.Divide:
                        return serviceProvider.GetService<DivideOperation>();
                    default:
                        throw new KeyNotFoundException();
               }
           });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
