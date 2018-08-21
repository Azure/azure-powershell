namespace Microsoft.Azure.Commands.Network.Models
{
    using System.Collections.Generic;

    public class PSVpnGateway : PSTopLevelResource
    {
        public List<PSVpnConnection> VpnConnections { get; set; }

        public PSBgpSettings BgpSettings { get; set; }

        public PSVirtualHub VirtualHub { get; set; }

        public int VpnGatewayScaleUnit { get; set; }

        public string ProvisioningState { get; set; }
    }
}