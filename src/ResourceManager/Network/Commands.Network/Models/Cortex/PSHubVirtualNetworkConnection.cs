namespace Microsoft.Azure.Commands.Network.Models
{
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PSHubVirtualNetworkConnection : PSChildResource
    {
        [Ps1Xml(Label = "Remote VirtualNetwork Id", Target = ViewControl.Table, ScriptBlock = "$_.RemoteVirtualNetwork.Id")]
        public PSResourceId RemoteVirtualNetwork { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [Ps1Xml(Label = "Internet Security Enabled", Target = ViewControl.Table)]
        public bool EnableInternetSecurity { get; set; }
    }
}
