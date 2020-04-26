using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSPrivateDnsZoneGroup : PSChildResource
    {
        public string ProvisioningState { get; set; }

        public List<PSPrivateDnsZoneConfig> PrivateDnsZoneConfigs { get; set; }
    }
}
