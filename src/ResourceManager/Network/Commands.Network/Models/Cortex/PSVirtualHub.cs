namespace Microsoft.Azure.Commands.Network.Models
{
    using System.Collections.Generic;
    
    public class PSVirtualHub : PSTopLevelResource
    {
        public PSResourceId VirtualWan { get; set; }

        public PSResourceId VpnGateway { get; set; }

        public PSResourceId ExpressRouteGateway { get; set; }

        public List<PSHubVirtualNetworkConnection> VirtualNetworkConnections { get; set; }

        public string AddressPrefix { get; set; }

        public string ProvisioningState { get; set; }
    }
}