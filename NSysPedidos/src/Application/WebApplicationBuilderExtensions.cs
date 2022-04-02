using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Events;

namespace Application
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AgregaSerilog(this ConfigureHostBuilder host)
        {
            host.UseSerilog();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
