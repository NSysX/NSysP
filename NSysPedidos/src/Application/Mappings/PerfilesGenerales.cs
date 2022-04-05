using Application.Features.PedidosDet.Commands.InsertarPedidosDetCmd;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class PerfilesGenerales : Profile
    {
        public PerfilesGenerales()
        {
            #region
            CreateMap<InsertarPedidoDetCommand, PedidoDet>();
            #endregion
        }
    }
}
