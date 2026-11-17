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

using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSInterconnectGroup : PSTopLevelResource
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [Ps1Xml(Label = "Scope", Target = ViewControl.Table)]
        public string Scope { get; set; }

        [Ps1Xml(Label = "VMSize", Target = ViewControl.Table, ScriptBlock = "$_.SubgroupProfile.VMSize")]
        public PSSubgroupProfile SubgroupProfile { get; set; }

        public List<PSSubgroup> Subgroups { get; set; }

        [JsonIgnore]
        public string SubgroupProfileText
        {
            get { return JsonConvert.SerializeObject(SubgroupProfile, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SubgroupsText
        {
            get { return JsonConvert.SerializeObject(Subgroups, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
