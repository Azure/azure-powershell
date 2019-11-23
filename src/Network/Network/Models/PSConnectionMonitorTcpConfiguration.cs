using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    class PSConnectionMonitorTcpConfiguration
    {
        public int? Port { get; set; }
        public bool? DisableTraceRoute { get; set; }
    }
}
