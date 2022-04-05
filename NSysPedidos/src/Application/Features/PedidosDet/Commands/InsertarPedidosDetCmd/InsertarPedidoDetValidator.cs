using FluentValidation;

namespace Application.Features.PedidosDet.Commands.InsertarPedidosDetCmd
{
    public class InsertarPedidoDetValidator : AbstractValidator<InsertarPedidoDetCommand>
    {
        public InsertarPedidoDetValidator()
        {
            RuleFor(p => p.ClienteId)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser Nulo")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros mayores a 0");

            RuleFor(p => p.EmpleadoId)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser Nulo")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros Mayores a 0");

            RuleFor(p => p.Cantidad)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser Nulo")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros mayores a 0");

            RuleFor(p => p.ProdMaestroId)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser Nulo")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo Numeros Mayores a 0");

            RuleFor(p => p.MarcaId)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser Nulo")
                .GreaterThan(0).WithMessage("'{PropertyName}' : Solo numeros mayores a 0");

            RuleFor(p => p.EsCadaUno)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser Nulo");

            RuleFor(p => p.Notas)
                .NotNull().WithMessage("'{PropertyName}' : No debe ser Nulo");
        }
    }
}
