using Application.Interface;
using Microsoft.Extensions.DependencyInjection;
using Shared.Services;

namespace Shared
{
    public static class ServicesSharedExtensions
    {
        public static void AgregaShared(this IServiceCollection services)
        {
            services.AddTransient<IFechaHoraServicio, FechaHoraServicio>();
        }

    }
}
