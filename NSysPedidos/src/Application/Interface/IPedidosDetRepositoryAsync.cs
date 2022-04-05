using Domain.Entities;

namespace Application.Interface
{
    public interface IPedidosDetRepositoryAsync
    {
        Task<PedidoDet> PedidoDetXIdAsync(int id);
        Task<List<PedidoDet>> ListarPedidoDetXClienteIdAsync(int id, string estatus);
        Task<bool> InsertarPedidosDetAsync(List<PedidoDet> pedidosDet);
        Task<bool> ActualizarPedidosDetAsync(int id, string estatus);
        Task<bool> EliminarPedidosDetAsync(int id);
    }
}