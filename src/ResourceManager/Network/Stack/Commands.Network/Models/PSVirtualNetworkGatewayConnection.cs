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

    public class PSVirtualNetworkGatewayConnection : PSTopLevelResource
    {
        public string AuthorizationKey { get; set; }
        public PSVirtualNetworkGateway VirtualNetworkGateway1 { get; set; }

        public PSVirtualNetworkGateway VirtualNetworkGateway2 { get; set; }

        public PSLocalNetworkGateway LocalNetworkGateway2 { get; set; }

        public PSResourceId Peer { get; set; }

        public string ConnectionType { get; set; }

        public int RoutingWeight { get; set; }

        public string SharedKey { get; set; }

        public bool EnableBgp { get; set; }

        public string ConnectionStatus { get; set; }

        public ulong EgressBytesTransferred { get; set; }

        public ulong IngressBytesTransferred { get; set; }

        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string VirtualNetworkGateway1Text
        {
            get { return JsonConvert.SerializeObject(VirtualNetworkGateway1.Id, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VirtualNetworkGateway2Text
        {
            get { return JsonConvert.SerializeObject(VirtualNetworkGateway2.Id, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string LocalNetworkGateway2Text
        {
            get { return JsonConvert.SerializeObject(LocalNetworkGateway2.Id, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string PeerText
        {
            get { return JsonConvert.SerializeObject(Peer.Id, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
