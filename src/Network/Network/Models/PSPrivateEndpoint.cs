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
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSPrivateEndpoint : PSTopLevelResource
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }
        [Ps1Xml(Label = "Subnet", Target = ViewControl.Table, ScriptBlock = "$_.Subnet.Name")]
        public PSSubnet Subnet { get; set; }
        public List<PSNetworkInterface> NetworkInterfaces { get; set; }
        public List<PSPrivateLinkServiceConnection> PrivateLinkServiceConnections { get; set; }
        public List<PSPrivateLinkServiceConnection> ManualPrivateLinkServiceConnections { get; set; }
        public List<PSPrivateEndpointCustomDnsConfig> CustomDnsConfigs { get; set; }
        public PSExtendedLocation ExtendedLocation { get; set; }

        public List<PSApplicationSecurityGroup> ApplicationSecurityGroups { get; set; }

        public List<PSPrivateEndpointIPConfiguration> IpConfigurations { get; set; }

        public string CustomNetworkInterfaceName { get; internal set; }

        [JsonIgnore]
        public string SubnetText
        {
            get { return JsonConvert.SerializeObject(Subnet, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string NetworkInterfacesText
        {
            get { return JsonConvert.SerializeObject(NetworkInterfaces, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string PrivateLinkServiceConnectionsText
        {
            get { return JsonConvert.SerializeObject(PrivateLinkServiceConnections, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ManualPrivateLinkServiceConnectionsText
        {
            get { return JsonConvert.SerializeObject(ManualPrivateLinkServiceConnections, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string CustomDnsConfigsText
        {
            get { return JsonConvert.SerializeObject(CustomDnsConfigs, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ExtendedLocationText
        {
            get { return JsonConvert.SerializeObject(ExtendedLocation, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ApplicationSecurityGroupsText
        {
            get { return JsonConvert.SerializeObject(ApplicationSecurityGroups, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string IpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(IpConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeNetworkInterfaces()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializePrivateLinkServiceConnections()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeManualPrivateLinkServiceConnections()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

    }
}
