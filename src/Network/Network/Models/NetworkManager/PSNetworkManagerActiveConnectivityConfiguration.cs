using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    public class PSNetworkManagerActiveConnectivityConfiguration:PSNetworkManagerEffectiveConnectivityConfiguration
    {
        public System.DateTime? CommitTime { get; set; }

        public string Region { get; set; }
    }
}
