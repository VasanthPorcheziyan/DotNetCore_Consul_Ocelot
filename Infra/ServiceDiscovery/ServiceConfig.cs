using System;
using System.Reflection;

namespace Infrastruct.ServiceDiscovery
{
    public class ServiceConfig
    {
        //public Uri ServiceDiscoveryAddress { get; set; }
        //public Uri ServiceAddress { get; set; }
        //public string ServiceName { get; set; }
        //public string ServiceId { get; set; }

        /// <summary>
        /// Gets or sets random port
        /// </summary>
        public int ServicePort { get; set; } = CustomPort.GetRandomPort(1000, 1999);
        /// <summary>
        /// Gets or sets Consul address
        /// </summary>
        public string ServiceDiscoveryAddress { get; set; } = "http://localhost:8500";

        /// <summary>
        /// Gets or sets Service name
        /// </summary>
        public string ServiceName { get; set; } = CustomPort.GetAssemblyName();

        /// <summary>
        /// Gets or sets Service Id
        /// </summary>
        public string ServiceId { get; set; } = CustomPort.GetAssemblyName();

        /// <summary>
        /// Gets or sets ServiceAddress
        /// </summary>
        public string ServiceAddress { get; set; } = "localhost";
    }
}
