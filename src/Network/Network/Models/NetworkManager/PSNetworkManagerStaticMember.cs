using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    public class PSNetworkManagerStaticMember : PSNetworkManagerBaseResource
    {
        public string ResourceId { get; set; }
    }
}
