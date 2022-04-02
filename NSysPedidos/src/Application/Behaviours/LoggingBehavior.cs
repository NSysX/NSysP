using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Application.Behaviours
{
    public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        private readonly ILogger<TRequest> _logger;

        public LoggingBehavior(ILogger<TRequest> logger)
        {
            this._logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            this._logger.LogInformation("Api Peticion : {Name} , {@Request}", requestName, request);
            return Task.CompletedTask;
        }
    }
}
