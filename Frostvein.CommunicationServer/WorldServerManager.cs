using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frostvein.CommunicationServer
{
    public class WorldServerManager
    {
        private readonly Dictionary<string, WorldServerInfo> _worldServers = new();

        public bool RegisterServer(string serverName, string ip, int port)
        {
            var key = $"{ip}:{port}";
            if (_worldServers.ContainsKey(key)) return false;

            _worldServers[key] = new WorldServerInfo
            {
                Name = serverName,
                Ip = ip,
                Port = port,
                LastHeartbeat = DateTime.UtcNow
            };

            Console.WriteLine($"Server registered: {serverName} ({key})");
            return true;
        }

        public void BroadcastData(string data)
        {
            foreach (var server in _worldServers.Values)
            {
                Console.WriteLine($"Broadcasting data to {server.Name} at {server.Ip}:{server.Port}");
            }
        }

        public void UpdateHeartbeat(string serverName)
        {
            var server = _worldServers.Values.FirstOrDefault(s => s.Name == serverName);
            if (server != null)
            {
                server.LastHeartbeat = DateTime.UtcNow;
                Console.WriteLine($"Heartbeat updated for {serverName}");
            }
        }
    }
}
