// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PSVirtualNetworkPeering : PSChildResource
    {
        [JsonProperty(Order = 1)]
        public string ResourceGroupName { get; set; }

        [JsonProperty(Order = 1)]
        public string VirtualNetworkName { get; set; }

        [JsonProperty(Order = 1)]
        public string PeeringState { get; set; }

        [JsonProperty(Order = 1)]
        public bool? AllowVirtualNetworkAccess { get; set; }

        [JsonProperty(Order = 1)]
        public bool? AllowForwardedTraffic { get; set; }

        [JsonProperty(Order = 1)]
        public bool? AllowGatewayTransit { get; set; }

        [JsonProperty(Order = 1)]
        public bool? UseRemoteGateways { get; set; }

        [JsonProperty(Order = 1)]
        public PSResourceId RemoteVirtualNetwork { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSResourceId> RemoteGateways { get; set; }

        [JsonProperty(Order = 1)]
        public PSAddressSpace RemoteVirtualNetworkAddressSpace { get; set; }

        [JsonProperty(Order = 1)]
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string RemoteVirtualNetworkText
        {
            get { return JsonConvert.SerializeObject(RemoteVirtualNetwork, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RemoteGatewaysText
        {
            get { return JsonConvert.SerializeObject(RemoteGateways, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RemoteVirtualNetworkAddressSpaceText
        {
            get { return JsonConvert.SerializeObject(RemoteVirtualNetworkAddressSpace, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }        
    }
}
