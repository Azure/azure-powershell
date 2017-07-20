using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSPrivateAccessService
    {
        [JsonProperty(Order = 1)]
        public string ProvisioningState { get; set; }

        [JsonProperty(Order = 1)]
        public string Service { get; set; }

        [JsonProperty(Order = 1)]
        public List<string> Locations { get; set; }
    }
}
