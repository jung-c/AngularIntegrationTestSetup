using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace AngularIntegrationTestSetup.DI;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public static void ConfigureWebHostBuilder<TEntrypoint>(IWebHostBuilder webBuilder)
    {
        webBuilder.UseStartup<Startup>();
        webBuilder.UseSetting(WebHostDefaults.ApplicationKey, typeof(TEntrypoint).Assembly.GetName().Name);
    }

    public virtual void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
    }

    public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            endpoints.MapFallbackToFile("index.html");
        });
    }
}