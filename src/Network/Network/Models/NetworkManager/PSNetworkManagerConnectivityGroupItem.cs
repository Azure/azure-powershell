using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    public class PSNetworkManagerConnectivityGroupItem
    {

        public string NetworkGroupId { get; set; }

        public string UseHubGateway { get; set; }

        public string IsGlobal { get; set; }

        public string GroupConnectivity { get; set; }
    }
}
