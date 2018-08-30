namespace Microsoft.Azure.Commands.Network.Models
{
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PSVpnGateway : PSTopLevelResource
    {
        public List<PSVpnConnection> Connections { get; set; }

        public PSBgpSettings BgpSettings { get; set; }

        [Ps1Xml(Label = "Virtual Hub", Target = ViewControl.Table, ScriptBlock = "$_.VirtualHub.Id")]
        public PSResourceId VirtualHub { get; set; }

        [Ps1Xml(Label = "Scale Unit", Target = ViewControl.Table)]
        public int VpnGatewayScaleUnit { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }
    }
}