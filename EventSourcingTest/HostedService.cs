using EventStore.ClientAPI;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace EventSourcingTest
{
    public class HostedService : IHostedService
    {
        private readonly IEventStoreConnection _esConnection;

        public HostedService(IEventStoreConnection esConnection)
        {
            _esConnection = esConnection;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _esConnection.ConnectAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _esConnection.Close();
            return Task.CompletedTask;
        }
    }
}
