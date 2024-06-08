using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace PoCTests.Api.IntegrationTest
{
    public class CustomWebApplicationFactory : WebApplicationFactory<FakerStartup>
    {
        protected override IHostBuilder? CreateHostBuilder()
        {
            return Host
                .CreateDefaultBuilder()
                .ConfigureAppConfiguration((_, configuration) =>
                {
                    configuration.Sources.Clear();
                    configuration.SetBasePath(AppContext.BaseDirectory);
                    configuration.AddJsonFile("testsAppsettings.json", true, true);
                })
                .ConfigureWebHostDefaults(w => w.UseStartup<FakerStartup>().UseTestServer())
                .UseEnvironment("test");
        }
    }
}
