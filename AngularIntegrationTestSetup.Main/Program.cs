namespace AngularIntegrationTestSetup.Main;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseSetting(WebHostDefaults.ApplicationKey, typeof(Startup).Assembly.GetName().Name);
                webBuilder.UseStartup<Startup>();
            });

}