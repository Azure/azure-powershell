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

    public class PSSubnet : PSChildResource
    {
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public List<string> AddressPrefix { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSIpamPoolPrefixAllocation> IpamPoolPrefixAllocations { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSIPConfiguration> IpConfigurations { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSServiceAssocationLink> ServiceAssociationLinks { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSResourceNavigationLink> ResourceNavigationLinks { get; set; }

        [JsonProperty(Order = 1)]
        [Ps1Xml(Label = "NetworkSecurityGroup Name", Target = ViewControl.Table, ScriptBlock = "$_.NetworkSecurityGroup.Name")]
        public PSNetworkSecurityGroup NetworkSecurityGroup { get; set; }

        [JsonProperty(Order = 1)]
        [Ps1Xml(Label = "RouteTable Name", Target = ViewControl.Table, ScriptBlock = "$_.RouteTable.Name")]
        public PSRouteTable RouteTable { get; set; }

        [JsonProperty(Order = 1)]
        [Ps1Xml(Label = "NatGateway Name", Target = ViewControl.Table, ScriptBlock = "$_.NatGateway.Name")]
        public PSResourceId NatGateway { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSServiceEndpoint> ServiceEndpoints { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSServiceEndpointPolicy> ServiceEndpointPolicies { get; set; }

        public List<PSDelegation> Delegations { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSPrivateEndpoint> PrivateEndpoints { get; set; }

        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string PrivateEndpointNetworkPolicies { get; set; }

        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string PrivateLinkServiceNetworkPolicies { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSResourceId> IpAllocations { get; set; }

        [JsonProperty(Order = 1)]
        public bool? DefaultOutboundAccess { get; set; }

        [JsonIgnore]
        public string IpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(IpConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ServiceAssociationLinksText
        {
            get { return JsonConvert.SerializeObject(ServiceAssociationLinks, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
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
        public string NatGatewayText
        {
            get { return JsonConvert.SerializeObject(NatGateway, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeIpConfigurations()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeServiceEndpointPolicies()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeServiceEndpoints()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeResourceNavigationLinks()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializePrivateEndpoints()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeDelegations()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeServiceAssociationLinks()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        [JsonIgnore]
        public string ServiceEndpointText
        {
            get { return JsonConvert.SerializeObject(ServiceEndpoints, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ServiceEndpointPoliciesText
        {
            get { return JsonConvert.SerializeObject(ServiceEndpointPolicies, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string PrivateEndpointsText
        {
            get { return JsonConvert.SerializeObject(PrivateEndpoints, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string DelegationsText
        {
            get { return JsonConvert.SerializeObject(Delegations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string IpAllocationsText
        {
            get { return JsonConvert.SerializeObject(IpAllocations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string DefaultOutboundAccessText
        {
            get { return JsonConvert.SerializeObject(DefaultOutboundAccess, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string IpamPoolPrefixAllocationsText
        {
            get { return JsonConvert.SerializeObject(IpamPoolPrefixAllocations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}