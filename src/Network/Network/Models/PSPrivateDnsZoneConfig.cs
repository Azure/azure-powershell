using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSPrivateDnsZoneConfig
    {
        public string Name { get; set; }

        public string PrivateDnsZoneId { get; set; }

        public string ProvisioningState { get; set; }
    }
}
