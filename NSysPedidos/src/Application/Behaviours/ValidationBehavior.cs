using Application.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Behaviours
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidationBehavior<TRequest,TResponse>> logger)
        {
            this._validators = validators;
            this._logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
             // si hay algun validador implementado
            if (this._validators.Any())
            {
                // reglas de negocio todos los validadores 
                var contexto = new ValidationContext<TRequest>(request);
                _logger.LogInformation($"Contexto de Validacion ==== > { contexto }");
                var resultadoValidacion = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(contexto , cancellationToken)));
                _logger.LogInformation($"ResultadoValidacion ==== > { resultadoValidacion }");
                var fallos = resultadoValidacion.SelectMany(v => v.Errors).Where(f => f != null).ToList();
                _logger.LogInformation($"Fallos ==== > { fallos }");

                if (fallos.Count != 0)
                {
                    throw new ExcepcionDeValidacion(fallos);
                }
            }

            return await next();
        }
    }
}
