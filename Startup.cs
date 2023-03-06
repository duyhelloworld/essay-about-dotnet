using essay_se_dotnetfw.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using Microsoft.Extensions.Configuration;
namespace essay_se_dotnetfw {
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string? connectionString = Configuration.GetConnectionString("DefaultConnection");

            // services.AddSingleton(new StudentManager(connectionString));
            services.AddTransient(provider => new StudentManager(connectionString));
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors("AllowAllPolicy");
                // endpoints.MapControllerRoute(
                //     name:  "default",
                //     pattern: "api/{controller}/{action}/{id?}"
                // );
                endpoints.MapControllers();
            });
        }
    }
}

