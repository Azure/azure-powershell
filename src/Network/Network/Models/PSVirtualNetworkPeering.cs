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
    using WindowsAzure.Commands.Common.Attributes;

    public class PSVirtualNetworkPeering : PSChildResource
    {
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table, Position = 0)]
        public string ResourceGroupName { get; set; }

        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table, Position = 1)]
        public string VirtualNetworkName { get; set; }

        [JsonProperty(Order = 1)]
        public string PeeringState { get; set; }

        [JsonProperty(Order = 1)]
        public string PeeringSyncLevel { get; set; }

        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public bool? AllowVirtualNetworkAccess { get; set; }

        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public bool? AllowForwardedTraffic { get; set; }

        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public bool? AllowGatewayTransit { get; set; }

        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public bool? UseRemoteGateways { get; set; }

        [JsonProperty(Order = 1)]
        public PSResourceId RemoteVirtualNetwork { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSResourceId> RemoteGateways { get; set; }

        [JsonProperty(Order = 1)]
        public PSAddressSpace PeeredRemoteAddressSpace { get; set; }

        [JsonProperty(Order = 1)]
        public PSAddressSpace RemoteVirtualNetworkAddressSpace { get; set; }

        [JsonProperty(Order = 1)]
        public PSVirtualNetworkBgpCommunities RemoteBgpCommunities { get; set; }

        [JsonProperty(Order = 1)]
        public PSVirtualNetworkEncryption RemoteVirtualNetworkEncryption { get; set; }

        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
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
        public string PeeredRemoteAddressSpaceText
        {
            get { return JsonConvert.SerializeObject(PeeredRemoteAddressSpace, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RemoteVirtualNetworkAddressSpaceText
        {
            get { return JsonConvert.SerializeObject(RemoteVirtualNetworkAddressSpace, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RemoteBgpCommunitiesText
        {
            get { return JsonConvert.SerializeObject(RemoteBgpCommunities, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RemoteVirtualNetworkEncryptionText
        {
            get { return JsonConvert.SerializeObject(RemoteVirtualNetworkEncryption, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
