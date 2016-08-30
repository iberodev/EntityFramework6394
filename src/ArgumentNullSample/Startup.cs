using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ArgumentNullSample.SqlServer;
using ArgumentNullSample.Repositories;
using ArgumentNullSample.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ArgumentNullSample
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostEnv;

        public IConfigurationRoot Configuration { get; private set; }

        public Startup(IHostingEnvironment hostEnv)
        {
            _hostEnv = hostEnv;
            ConfigureApplicationSettings();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(routeOptions =>
            {
                routeOptions.AppendTrailingSlash = true;
                routeOptions.LowercaseUrls = true;
            });

            //ASP.NET Core MVC
            services.AddMvc(setup =>
            {
                //no additional setup needed
            });

            // Identity
            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<SampleContext>()
            .AddDefaultTokenProviders();

            //Entity Framework Core
            services
                .AddDbContext<SampleContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                });

            services.AddTransient<SampleContextSeeder>();
            services.AddScoped<ITestRepository, TestRepository>();
        }


        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, SampleContextSeeder seeder)
        {
            loggerFactory.AddDebug(LogLevel.Debug);

            app.UseIdentity(); //ASP.NET Identity (adds cookie authentication)

            app.UseMvcWithDefaultRoute();

            //Seed Database
            seeder.EnsureSeedData();
        }

        private void ConfigureApplicationSettings()
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(_hostEnv.ContentRootPath) // allow the runtime to find configuration
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{_hostEnv.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
    }
}
