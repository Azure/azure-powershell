using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    public class PSNetworkManagerRoutingRuleDestination
    {
        public string DestinationAddress { get; set; }

        public string Type { get; set; }
    }
}
