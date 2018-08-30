namespace Microsoft.Azure.Commands.Network.Models
{
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PSVirtualHub : PSTopLevelResource
    {
        [Ps1Xml(Label = "Virtual Wan Id", Target = ViewControl.Table, ScriptBlock = "$_.VirtualWan.Id")]
        public PSResourceId VirtualWan { get; set; }

        public PSResourceId VpnGateway { get; set; }

        public PSResourceId ExpressRouteGateway { get; set; }

        public List<PSHubVirtualNetworkConnection> VirtualNetworkConnections { get; set; }

        [Ps1Xml(Label = "Address Prefix", Target = ViewControl.Table)]
        public string AddressPrefix { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }
    }
}