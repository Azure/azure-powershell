using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    public class PSNetworkManagerConnectivityCapabilities
    {
        [ValidateSet("Standard", "HighScale")]
        public string ConnectedGroupPrivateEndpointScale {get; set; } = "Standard";

        [ValidateSet("Allowed", "Disallowed")]    
        public string ConnectedGroupAddressOverlap { get; set; } = "Allowed";

        [ValidateSet("Unenforced", "Enforced")]
        public string PeeringEnforcement { get; set; } = "Unenforced";
    }
}