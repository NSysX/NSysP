using Application.Interface;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PedidosDet.Commands.InsertarPedidosDetCmd
{
    public class InsertarPedidoDetCommand : IRequest<Respuesta<int>>
    {
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public decimal Cantidad { get; set; }
        public int ProdMaestroId { get; set; }
        public int MarcaId { get; set; }
        public bool EsCadaUno { get; set; } = false;
        public string Notas { get; set; } = string.Empty;
    }

    public class InsertarPedidoDet_Handler : IRequestHandler<InsertarPedidoDetCommand, Respuesta<int>>
    {
        private readonly IRepositoryAsync<PedidoDet> _repositoryAsync;
        private readonly IMapper _mapper;
        private readonly IPedidosDetRepositoryAsync _pedidosDetRepositoryAsync;

        public InsertarPedidoDet_Handler(IRepositoryAsync<PedidoDet> repositoryAsync, IMapper mapper, IPedidosDetRepositoryAsync pedidosDetRepositoryAsync)
        {
            this._repositoryAsync = repositoryAsync;
            this._mapper = mapper;
            this._pedidosDetRepositoryAsync = pedidosDetRepositoryAsync;
        }

        public async Task<Respuesta<int>> Handle(InsertarPedidoDetCommand request, CancellationToken cancellationToken)
        {
            PedidoDet pedidoDet = this._mapper.Map<PedidoDet>(request);
            var data = await this._repositoryAsync.AddAsync(pedidoDet);
            return new Respuesta<int>(data.Id);
        }
    }
}
