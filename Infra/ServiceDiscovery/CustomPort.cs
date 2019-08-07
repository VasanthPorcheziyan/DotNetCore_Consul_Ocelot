using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Infrastruct.ServiceDiscovery
{
    public class CustomPort
    {
        public static int GetRandomPort(int startPort, int endPort)
        {
            start: Random randomizer = new Random();
            int port = randomizer.Next(startPort, endPort);

            try
            {
                System.Net.Sockets.TcpClient tcpClient = new System.Net.Sockets.TcpClient();
                tcpClient.Connect("localhost", port);
            }
            catch
            {
                return port;
            }

            goto start;
        }

        internal static string GetAssemblyName()
        {
            return Assembly.GetEntryAssembly().GetName().Name.ToLower().Trim();
        }
    }
}
