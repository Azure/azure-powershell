using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSConnectionMonitorTcpConfiguration : PSNetworkWatcherConnectionMonitorProtocolConfiguration
    {
        public int? Port { get; set; }
        public bool?  DisableTraceRoute { get; set; }
    }
}
