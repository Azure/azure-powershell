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

    public class PSSubnet : PSChildResource
    {
        [JsonProperty(Order = 1)]
        public string AddressPrefix { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSIPConfiguration> IpConfigurations { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSResourceNavigationLink> ResourceNavigationLinks { get; set; }

        [JsonProperty(Order = 1)]
        public PSNetworkSecurityGroup NetworkSecurityGroup { get; set; }

        [JsonProperty(Order = 1)]
        public PSRouteTable RouteTable { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSPrivateAccessService> PrivateAccessServices { get; set; }

        [JsonProperty(Order = 1)]
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string IpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(IpConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ResourceNavigationLinksText
        {
            get { return JsonConvert.SerializeObject(ResourceNavigationLinks, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string NetworkSecurityGroupText
        {
            get { return JsonConvert.SerializeObject(NetworkSecurityGroup, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RouteTableText
        {
            get { return JsonConvert.SerializeObject(RouteTable, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string PrivateAccessServicesText
        {
            get { return JsonConvert.SerializeObject(PrivateAccessServices, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeIpConfigurations()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}
