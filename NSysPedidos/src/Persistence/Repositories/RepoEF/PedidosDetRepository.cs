using Application.Interface;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Persistence.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.RepoEF
{
    public class PedidosDetRepository : IPedidosDetRepositoryAsync
    {
        private readonly AplicacionDbContext _dbContext;
        private readonly ILogger<PedidosDetRepository> _logger;

        public PedidosDetRepository(AplicacionDbContext dbContext, ILogger<PedidosDetRepository> logger)
        {
            this._dbContext = dbContext;
            this._logger = logger;
        }

        public Task<bool> ActualizarPedidosDetAsync(int id, string estatus)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarPedidosDetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertarPedidosDetAsync(List<PedidoDet> pedidosDet)
        {
            this._logger.LogInformation("Insertar PedidosDet Async");
            await this._dbContext.AddRangeAsync(pedidosDet);
            await this._dbContext.SaveChangesAsync();
            return true;
        }

        public Task<List<PedidoDet>> ListarPedidoDetXClienteIdAsync(int id, string estatus)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoDet> PedidoDetXIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
