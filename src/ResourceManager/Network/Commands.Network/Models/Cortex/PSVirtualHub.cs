namespace Microsoft.Azure.Commands.Network.Models
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Models;

    public class PSVirtualHub : PSTopLevelResource
    {
        public SubResource VirtualWan { get; set; }

        public List<PSHubVirtualNetworkConnection> HubVirtualNetworkConnections { get; set; }

        public string AddressPrefix { get; set; }

        public string ProvisioningState { get; set; }
    }
}