using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSServiceEndpoint
    {
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string Service { get; set; }

        [JsonProperty(Order = 1)]
        public List<string> Locations { get; set; }

        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public PSResourceId NetworkIdentifier { get; set; }
    }
}