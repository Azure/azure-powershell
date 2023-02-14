using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSPrivateEndpointCustomDnsConfig
    {
        public string Fqdn { get; set; }

        public List<string> IpAddresses { get; set; }
    }
}
