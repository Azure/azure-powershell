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

    public class PSP2SConnectionConfiguration : PSChildResource
    {
        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        public PSAddressSpace VpnClientAddressPool { get; set; }

        public PSRoutingConfiguration RoutingConfiguration { get; set; }

        [Ps1Xml(Label = "Internet Security Enabled", Target = ViewControl.Table)]
        public bool? EnableInternetSecurity { get; set; }
        
        [Ps1Xml(Label = "ConfigurationPolicyGroupAssociation ids", Target = ViewControl.Table)]
        public List<PSResourceId> ConfigurationPolicyGroupAssociations { get; set; }

        public List<PSVpnServerConfigurationPolicyGroup> PreviousConfigurationPolicyGroupAssociations { get; set; }

        [JsonIgnore]
        public string VpnClientAddressPoolText
        {
            get { return JsonConvert.SerializeObject(VpnClientAddressPool, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RoutingConfigurationText
        {
            get { return JsonConvert.SerializeObject(RoutingConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ConfigurationPolicyGroupAssociationsText
        {
            get { return JsonConvert.SerializeObject(ConfigurationPolicyGroupAssociations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string PreviousConfigurationPolicyGroupAssociationsText
        {
            get { return JsonConvert.SerializeObject(PreviousConfigurationPolicyGroupAssociations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
