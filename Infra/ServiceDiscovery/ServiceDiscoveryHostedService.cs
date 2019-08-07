using System.Threading;
using System.Threading.Tasks;
using Consul;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using System;
using System.Linq;

namespace Infrastruct.ServiceDiscovery
{
    public class ServiceDiscoveryHostedService : IHostedService
    {
        private readonly IConsulClient _client;
        private readonly ServiceConfig _config;
        private readonly IServer _server;
        private string _registrationId;

        public ServiceDiscoveryHostedService(IConsulClient client, ServiceConfig config, IServer server)
        {
            _client = client;
            _config = config;
            _server = server;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // this.cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            var features = this._server.Features;
            var addresses = features.Get<IServerAddressesFeature>();
            var address = addresses.Addresses.First();

            var uri = new Uri(address);
            _registrationId = $"{this._config.ServiceId}-{uri.Port}";

            // _registrationId = $"{_config.ServiceName}-{_config.ServiceId}";

            var registration = new AgentServiceRegistration
            {
                ID = _registrationId,
                Name = _config.ServiceName,
                Address = _config.ServiceAddress,
                Port = uri.Port
            };

            await _client.Agent.ServiceDeregister(registration.ID, cancellationToken);
            await _client.Agent.ServiceRegister(registration, cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _client.Agent.ServiceDeregister(_registrationId, cancellationToken);
        }
    }
}