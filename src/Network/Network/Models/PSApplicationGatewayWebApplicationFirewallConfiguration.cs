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

using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSApplicationGatewayWebApplicationFirewallConfiguration
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public bool Enabled { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string FirewallMode { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string RuleSetType { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string RuleSetVersion { get; set; }
        public List<PSApplicationGatewayFirewallDisabledRuleGroup> DisabledRuleGroups { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public bool? RequestBodyCheck { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public int? MaxRequestBodySizeInKb { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public int? FileUploadLimitInMb { get; set; }
        public List<PSApplicationGatewayFirewallExclusion> Exclusions { get; set; }


        [JsonIgnore]
        public string DisabledRuleGroupsText
        {
            get { return JsonConvert.SerializeObject(this.DisabledRuleGroups, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ExclusionsText
        {
            get { return JsonConvert.SerializeObject(this.Exclusions, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
