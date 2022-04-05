using Application.Interface;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Contextos
{
    public class AplicacionDbContext : DbContext
    {
        private readonly IFechaHoraServicio _fechaHoraServicio;

        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options, IFechaHoraServicio fechaHoraServicio) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this._fechaHoraServicio = fechaHoraServicio;
        }

        public DbSet<PedidoDet> PedidoDet => Set<PedidoDet>();

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.FechaDeCreacion = this._fechaHoraServicio.Ahora;
                        break;
                    case EntityState.Modified:
                        entry.Entity.FechaModificacion = this._fechaHoraServicio.Ahora;
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Para las configuraciones del Api Fluent
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
