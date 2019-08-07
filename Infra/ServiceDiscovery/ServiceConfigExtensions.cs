using System;
using Microsoft.Extensions.Configuration;

namespace Infrastruct.ServiceDiscovery
{
    public static class ServiceConfigExtensions
    {
        public static ServiceConfig GetServiceConfig(this IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var serviceConfig = new ServiceConfig
            {
                ServiceDiscoveryAddress = configuration.GetValue<string>("ServiceConfig:GlobalConfiguration:ServiceDiscoveryProvider:Host") ?? new ServiceConfig().ServiceDiscoveryAddress,
                ServiceAddress = configuration.GetValue<string>("ServiceConfig:ServiceAddress") ?? new ServiceConfig().ServiceAddress,
                ServiceName = configuration.GetValue<string>("ServiceConfig:ServiceName") ?? new ServiceConfig().ServiceName,
                ServiceId = configuration.GetValue<string>("ServiceConfig:ServiceId") ?? new ServiceConfig().ServiceId
            };

            return serviceConfig;
        }
    }
}