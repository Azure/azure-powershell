// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSExpressRouteCrossConnectionPeering : PSChildResource
    {
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string PeeringType { get; set; }
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string State { get; set; }
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public int? AzureASN { get; set; }
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public long? PeerASN { get; set; }
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string PrimaryPeerAddressPrefix { get; set; }
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string SecondaryPeerAddressPrefix { get; set; }
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string PrimaryAzurePort { get; set; }
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string SecondaryAzurePort { get; set; }
        [JsonProperty(Order = 1)]
        public string SharedKey { get; set; }
        [JsonProperty(Order = 1)]
        public int? VlanId { get; set; }
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }
        [JsonProperty(Order = 1)]
        public string GatewayManagerEtag { get; set; }
        [JsonProperty(Order = 1)]
        public string LastModifiedBy { get; set; }
        [JsonProperty(Order = 1)]
        public PSPeeringConfig MicrosoftPeeringConfig { get; set; }
        [JsonProperty(Order = 1)]
        public PSIpv6PeeringConfig Ipv6PeeringConfig { get; set; }

        [JsonIgnore]
        public string MicrosoftPeeringConfigText
        {
            get { return JsonConvert.SerializeObject(MicrosoftPeeringConfig, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string Ipv6PeeringConfigText
        {
            get { return JsonConvert.SerializeObject(Ipv6PeeringConfig, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
