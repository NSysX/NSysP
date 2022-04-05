using Application.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contextos;
using Persistence.Repositories.RepoEF;
using Persistence.Repositories.Spec;

namespace Persistence
{
    public static class ServicesPersistenceExtensions
    {
        public static void AgregaPersistenciaInfra(this IServiceCollection services, IConfiguration configuration)
        {
            string cadenaConexion = configuration.GetConnectionString("defaultConnection");
            services.AddDbContext<AplicacionDbContext>(opt => opt.UseSqlServer(cadenaConexion, b =>
                          b.MigrationsAssembly(typeof(AplicacionDbContext).Assembly.FullName))
                                                      );

            #region Repositorios
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(MyRepositoryAsync<>));
            services.AddTransient<IPedidosDetRepositoryAsync, PedidosDetRepository>();
            #endregion
        }

    }
}
