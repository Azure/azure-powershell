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
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Internal.Network.Common;
    using Newtonsoft.Json;

    public class PSIpAllocation : PSTopLevelResource, IResourceReference
    {
        public string IpAllocationType { get; set; }

        public string Prefix { get; set; }

        public int? PrefixLength { get; set; }

        public string PrefixType { get; set; }

        public string IpamAllocationId { get; set; }

        public IDictionary<string, string> AllocationTags { get; set; }

        public PSSubnet Subnet { get; set; }

        public PSVirtualNetwork VirtualNetwork { get; set; }

        [JsonIgnore]
        public string SubnetText
        {
            get { return JsonConvert.SerializeObject(Subnet, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VirtualNetworkText
        {
            get { return JsonConvert.SerializeObject(VirtualNetwork, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
