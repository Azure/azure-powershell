//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PSSecurityRuleAssociations
    {
        [JsonProperty(Order = 1)]
        public PSNetworkInterfaceAssociation NetworkInterfaceAssociation { get; set; }

        [JsonProperty(Order = 1)]
        public PSSubnetAssociation SubnetAssociation { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSSecurityRule> DefaultSecurityRules { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSEffectiveSecurityRule> EffectiveSecurityRules { get; set; }

        [JsonIgnore]
        public string NetworkInterfaceAssociationText
        {
            get { return JsonConvert.SerializeObject(this.NetworkInterfaceAssociation, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SubnetAssociationText
        {
            get { return JsonConvert.SerializeObject(this.SubnetAssociation, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string DefaultSecurityRuleText
        {
            get { return JsonConvert.SerializeObject(this.DefaultSecurityRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string EffectiveSecurityRuleText
        {
            get { return JsonConvert.SerializeObject(this.EffectiveSecurityRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}