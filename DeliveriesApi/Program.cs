using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Infrastruct.ServiceDiscovery;

namespace Deliveries
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int port = CustomPort.GetRandomPort(1000, 1099);
            CreateWebHostBuilder(args).UseUrls($"http://localhost:{port}").Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseKestrel()
                .UseStartup<Startup>();
    }
}
