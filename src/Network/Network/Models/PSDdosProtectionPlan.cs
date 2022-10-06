// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Microsoft.Azure.Commands.Network.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSDdosProtectionPlan : PSTopLevelResource
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        public List<PSResourceId> VirtualNetworks { get; set; }

        public List<PSResourceId> PublicIpAddresses { get; set; }

        [JsonIgnore]
        public string VirtualNetworksText
        {
            get { return JsonConvert.SerializeObject(VirtualNetworks, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string PublicIpAddressesText
        {
            get { return JsonConvert.SerializeObject(PublicIpAddresses, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
