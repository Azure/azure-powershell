using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    public class PSNetworkManagerRoutingRuleNextHop
    {
        public string NextHopAddress { get; set; }

        public string NextHopType { get; set; }
    }
}
