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
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;

    public class PSVpnServerConfigurationPolicyGroup : PSChildResource
    {
        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [Ps1Xml(Label = "IsDefault", Target = ViewControl.Table)]
        public bool IsDefault { get; set; }

        [Ps1Xml(Label = "Priority", Target = ViewControl.Table)]
        public int Priority { get; set; }

        public List<PSVpnServerConfigurationPolicyGroupMember> PolicyMembers { get; set; }

        [Ps1Xml(Label = "P2SConnectionConfiguration ids", Target = ViewControl.Table)]
        public List<PSResourceId> P2SConnectionConfigurations { get; set; }

        [JsonIgnore]
        public string PolicyMembersText
        {
            get { return JsonConvert.SerializeObject(PolicyMembers, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string P2SConnectionConfigurationsText
        {
            get { return JsonConvert.SerializeObject(P2SConnectionConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
