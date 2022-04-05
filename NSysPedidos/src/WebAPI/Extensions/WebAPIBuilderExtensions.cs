using WebAPI.Middleware;

namespace WebAPI.Extensions
{
    public static class WebAPIBuilderExtensions
    {
        public static void UsarManejadorErroresMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ManejadorErroresMiddleware>();
        }
    }
}