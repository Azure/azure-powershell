using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSAzureFirewallHubPublicIpAddresses
    {
        public int Count { get; set; }

        public PSAzureFirewallPublicIpAddress[] Addresses { get; set; }
    }
}
