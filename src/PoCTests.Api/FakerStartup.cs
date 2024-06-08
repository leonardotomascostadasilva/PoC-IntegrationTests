using Refit;

namespace PoCTests.Api
{
    public class FakerStartup
    {
        public FakerStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ILogin, Login>();

            services
                .AddRefitClient<IValidate>()
                .ConfigureHttpClient(c =>
                {
                    var url = Configuration.GetSection("ValidateConfiguration:url").Value;
                    c.BaseAddress = new Uri(url);
                });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRouting(options => options.LowercaseUrls = true);
        }

        public void Configure(IApplicationBuilder app)
        {

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(e =>
            {
                e.MapControllers();
            });
        }
    }
}
