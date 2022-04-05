using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class PedidoDet : AuditableBase
    {
        public EstatusPedido Estatus { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public decimal Cantidad { get; set; }
        public int ProdMaestroId { get; set; }
        public int MarcaId { get; set; }
        public bool EsCadaUno { get; set; }
        public string Notas { get; set; } = string.Empty;
    }
}
