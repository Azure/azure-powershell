namespace Microsoft.Azure.Commands.Network.Models
{
    using Management.Network.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSP2SVpnGateway : PSTopLevelResource
    {
        public PSResourceId P2SVpnServerConfiguration { get; set; }

        [Ps1Xml(Label = "Address Space", Target = ViewControl.Table, ScriptBlock = "$_.VpnClientAddressPool.AddressPrefixes")]
        public PSAddressSpace VpnClientAddressPool { get; set; }

        [Ps1Xml(Label = "Virtual Hub", Target = ViewControl.Table, ScriptBlock = "$_.VirtualHub.Id")]
        public PSResourceId VirtualHub { get; set; }

        [Ps1Xml(Label = "Scale Unit", Target = ViewControl.Table)]
        public int VpnGatewayScaleUnit { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }
    }
}