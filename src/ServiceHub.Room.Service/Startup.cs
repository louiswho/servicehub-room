using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using ServiceHub.Room.Context.Repository;
using Swashbuckle.AspNetCore.Swagger;

namespace ServiceHub.Room.Service
{

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            const string demodb = @"mongodb://db";
            
            services.AddSingleton(mc =>
                new MongoClient(demodb).GetDatabase("rooms").GetCollection<Context.Models.Room>("rooms"));

            services.AddTransient<IRoomsRepository, RoomsRepository>();

            services.AddMvc();

            services.AddSwaggerGen(doc => doc.SwaggerDoc("ServiceHub-Room", new Info {Title = "Room Service Hub"}));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddApplicationInsights(app.ApplicationServices);

            ServiceLogging.Configure("service");
            ServiceLogging.LoggerFactory = loggerFactory;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(doc =>
            {
                const string url = "/swagger/ServiceHub-Room/swagger.json";
                doc.SwaggerEndpoint(url, "ServiceHub-Room");
            });

            app.UseMvc();
        }
    }

}