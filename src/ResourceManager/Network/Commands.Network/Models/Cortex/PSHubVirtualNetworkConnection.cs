namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSHubVirtualNetworkConnection : PSChildResource
    {
        public PSVirtualNetwork RemoteVirtualNetwork { get; set; }

        public string ProvisioningState { get; set; }
    }
}
