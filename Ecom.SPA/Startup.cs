using VueCliMiddleware;

namespace Iwcp.Web.SPA.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSpaStaticFiles(opt => opt.RootPath = "ClientApp/dist");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var isTestingEnv = env.IsEnvironment("Test");

            if (env.IsDevelopment() || isTestingEnv)
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                if (env.IsDevelopment() || isTestingEnv)
                    spa.Options.SourcePath = "ClientApp/dist";
                else
                    spa.Options.SourcePath = "dist";

                if (env.IsDevelopment())
                    spa.UseVueCli(npmScript: "serve", port: 8000, false, ScriptRunnerType.Npm, "ready in", true);
                else if (isTestingEnv)
                    spa.UseVueCli(npmScript: "test", port: 7000, false, ScriptRunnerType.Npm, "ready in", true);
            });
        }
    }
}