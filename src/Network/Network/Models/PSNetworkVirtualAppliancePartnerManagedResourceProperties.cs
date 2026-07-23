using Microsoft.Azure.Management.Network.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSNetworkVirtualAppliancePartnerManagedResourceProperties
    {
        public string Id { get; set; }

        public string InternalLoadBalancerId { get; set; }

        public string StandardLoadBalancerId { get; set; }
    }
}
