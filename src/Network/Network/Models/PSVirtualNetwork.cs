﻿// ----------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Management.Internal.Network.Common;
    using Newtonsoft.Json;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSVirtualNetwork : PSTopLevelResource, IResourceReference, IVirtualNetwork
    {
        public PSAddressSpace AddressSpace { get; set; }

        public PSDhcpOptions DhcpOptions { get; set; }

        public List<PSSubnet> Subnets { get; set; }

        public PSVirtualNetworkBgpCommunities BgpCommunities { get; set; }

        public List<PSVirtualNetworkPeering> VirtualNetworkPeerings { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool? EnableDdosProtection { get; set; }

        public PSResourceId DdosProtectionPlan { get; set; }

        public List<PSResourceId> IpAllocations { get; set; }

        [JsonIgnore]
        public string AddressSpaceText
        {
            get { return JsonConvert.SerializeObject(AddressSpace, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string DhcpOptionsText
        {
            get { return JsonConvert.SerializeObject(DhcpOptions, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SubnetsText
        {
            get { return JsonConvert.SerializeObject(Subnets, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string BgpCommunitiesText
        {
            get { return JsonConvert.SerializeObject(BgpCommunities, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VirtualNetworkPeeringsText
        {
            get { return JsonConvert.SerializeObject(VirtualNetworkPeerings, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string EnableDdosProtectionText
        {
            get { return JsonConvert.SerializeObject(EnableDdosProtection, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string DdosProtectionPlanText
        {
            get { return JsonConvert.SerializeObject(DdosProtectionPlan, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string IpAllocationsText
        {
            get { return JsonConvert.SerializeObject(IpAllocations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
