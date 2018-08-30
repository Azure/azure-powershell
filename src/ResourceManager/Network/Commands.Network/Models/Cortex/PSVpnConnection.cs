using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSVpnConnection : PSChildResource
    {
        public PSResourceId RemoteVpnSite { get; set; }

        public string SharedKey { get; set; }

        public string ConnectionStatus { get; set; }

        public long? EgressBytesTransferred { get; set; }

        public long? IngressBytesTransferred { get; set; }

        public string ProvisioningState { get; set; }

        public List<PSIpsecPolicy> IpsecPolicies { get; set; }

        public bool EnableBgp { get; set; }

        public int ConnectionBandwidth { get; set; }

        public bool EnableRateLimiting { get; set; }

        public bool EnableInternetSecurity { get; set; }
    }
}
