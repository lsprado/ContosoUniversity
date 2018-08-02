using ContosoUniversity.API;
using ContosoUniversity.XUnitTest.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.XUnitTest
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        public override void ConfigureDatabase(IServiceCollection services)
        {
            // Replace default database connection with In-Memory database
            services.AddDbContext<ContosoUniversity.API.Data.ContosoUniversityAPIContext>(options => options.UseInMemoryDatabase("test_db"));

            // Register the database seeder
            services.AddTransient<DatabaseSeeder>();
        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Perform all the configuration in the base class
            base.Configure(app, env);

            // Now seed the database
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var seeder = serviceScope.ServiceProvider.GetService<DatabaseSeeder>();
                seeder.Seed().Wait();
            }
        }
    }
}
