using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frostvein.CommunicationServer
{
    public class WorldServerInfo
    {
        public string Name { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public DateTime LastHeartbeat { get; set; }
    }
}
