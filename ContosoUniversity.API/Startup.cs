using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.API.Data;
using NJsonSchema;
using NSwag.AspNetCore;
using System.Reflection;

namespace ContosoUniversity.API
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
            // Add framework services.
            ConfigureDatabase(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
        }

        public virtual void ConfigureDatabase(IServiceCollection services)
        {
            if (Configuration["DBHOST"] != null)
            {
                //https://hk.saowen.com/a/c28ce380a9ef33bdacd04a1a6c1f8ca396b7caa5c5bd7ee1445bce0d609b64d5
                var host = Configuration["DBHOST"];
                var db = Configuration["DBNAME"];
                var port = Configuration["DBPORT"];
                var username = Configuration["DBUSERNAME"];
                var password = Configuration["DBPASSWORD"];

                string connStr = String.Format("Data Source={0},{1};Integrated Security=False; User ID={2};Password={3};Database={4}; Connect Timeout=30; Encrypt=False; TrustServerCertificate=True; ApplicationIntent=ReadWrite; MultiSubnetFailover=False", host, port, username, password, db );
                services.AddDbContext<ContosoUniversityAPIContext>(options => options.UseSqlServer(connStr));
            }
            else
            {
                services.AddDbContext<ContosoUniversityAPIContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ContosoUniversityAPIContext")));
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable the Swagger UI middleware and the Swagger generator
            app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
                settings.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Contoso University API";
                    document.Info.Description = "ASP.NET Core web API for Contoso University Web Application";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.SwaggerContact
                    {
                        Name = "Leandro Prado",
                        Email = "Leandro.Prado@microsoft.com",
                        Url = "https://twitter.com/blog_prado"
                    };
                    document.Info.License = new NSwag.SwaggerLicense
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    };
                };
            });
            
            app.UseMvc();
        }
    }
}