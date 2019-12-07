using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSConnectionMonitorIcmpConfiguration : PSNetworkWatcherConnectionMonitorProtocolConfiguration
    {
        public bool? DisableTraceRoute { get; set; }
    }
}
