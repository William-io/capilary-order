using System;
using System.Threading.Tasks;
using Coravel.Invocable;
using Microsoft.Extensions.Logging;

namespace Capillary.Service
{
    public class ProcessOrder : IInvocable
    {
        private readonly ILogger<ProcessOrder> _logger;
        public ProcessOrder(ILogger<ProcessOrder> Logger)
        {
            this._logger = Logger;
        }

        public async Task Invoke()
        {
            var capillaryId = Guid.NewGuid();
            _logger.LogInformation($"Iniciando hidratação Id {capillaryId}");
            // return Task.FromResult(true);
            await Task.Delay(3000);
            _logger.LogInformation($"Hidratação com Id {capillaryId} foi completada! ");
        }
    }

}