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

using Microsoft.Azure.Management.Network.Models;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSPrivateLinkService : PSTopLevelResource
    {
        public List<PSFrontendIPConfiguration> LoadBalancerFrontendIpConfigurations { get; set; }
        public List<PSPrivateLinkServiceIpConfiguration> IpConfigurations { get; set; }
        public List<PSNetworkInterface> NetworkInterfaces { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }
        public List<PSPrivateEndpointConnection> PrivateEndpointConnections { get; set; }
        public PSPrivateLinkServiceResourceSet Visibility { get; set; }
        public PSPrivateLinkServiceResourceSet AutoApproval { get; set; }

        public string[] Fqdns { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string Alias { get; set; }

        public bool? EnableProxyProtocol { get; set; }

        public PSExtendedLocation ExtendedLocation { get; set; }

        public string DestinationIPAddress { get; set; }

        [JsonIgnore]
        public string LoadBalancerFrontendIpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(LoadBalancerFrontendIpConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string IpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(IpConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string NetworkInterfacesText
        {
            get { return JsonConvert.SerializeObject(NetworkInterfaces, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string PrivateEndpointConnectionsText
        {
            get { return JsonConvert.SerializeObject(PrivateEndpointConnections, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VisibilityText
        {
            get { return JsonConvert.SerializeObject(Visibility, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string AutoApprovalText
        {
            get { return JsonConvert.SerializeObject(AutoApproval, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ExtendedLocationText
        {
            get { return JsonConvert.SerializeObject(ExtendedLocation, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
