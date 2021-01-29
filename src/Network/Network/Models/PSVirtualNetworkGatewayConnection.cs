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

    public class PSVirtualNetworkGatewayConnection : PSTopLevelResource
    {
        public string AuthorizationKey { get; set; }
        public PSVirtualNetworkGateway VirtualNetworkGateway1 { get; set; }

        public PSVirtualNetworkGateway VirtualNetworkGateway2 { get; set; }

        public PSLocalNetworkGateway LocalNetworkGateway2 { get; set; }

        public PSResourceId Peer { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string ConnectionType { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public int RoutingWeight { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public int DpdTimeoutSeconds { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string ConnectionMode { get; set; }

        public string SharedKey { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool EnableBgp { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool UseLocalAzureIpAddress { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string ConnectionStatus { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public long? EgressBytesTransferred { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public long? IngressBytesTransferred { get; set; }

        public List<PSTunnelConnectionHealth> TunnelConnectionStatus { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool UsePolicyBasedTrafficSelectors { get; set; }

        public List<PSIpsecPolicy> IpsecPolicies { get; set; }

        public List<PSTrafficSelectorPolicy> TrafficSelectorPolicies { get; set; }

        public bool ExpressRouteGatewayBypass { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string ConnectionProtocol { get; set; }

        [JsonIgnore]
        public string VirtualNetworkGateway1Text
        {
            get { return JsonConvert.SerializeObject(VirtualNetworkGateway1.Id, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VirtualNetworkGateway2Text
        {
            get { return VirtualNetworkGateway2 == null ? string.Empty : JsonConvert.SerializeObject(VirtualNetworkGateway2.Id, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string LocalNetworkGateway2Text
        {
            get { return LocalNetworkGateway2 == null ? string.Empty : JsonConvert.SerializeObject(LocalNetworkGateway2.Id, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string PeerText
        {
            get { return Peer == null ? string.Empty : JsonConvert.SerializeObject(Peer.Id, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string TunnelConnectionStatusText
        {
            get { return TunnelConnectionStatus == null ? string.Empty : JsonConvert.SerializeObject(TunnelConnectionStatus, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
