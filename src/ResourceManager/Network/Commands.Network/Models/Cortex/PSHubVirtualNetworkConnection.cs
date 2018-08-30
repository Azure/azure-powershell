namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSHubVirtualNetworkConnection : PSChildResource
    {
        public PSResourceId RemoteVirtualNetwork { get; set; }

        public string ProvisioningState { get; set; }

        public bool EnableInternetSecurity { get; set; }
    }
}
