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
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PSServiceEndpointPolicy : PSTopLevelResource
    {
        [JsonProperty(Order = 1)]
        public List<PSServiceEndpointPolicyDefinition> ServiceEndpointPolicyDefinitions { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSSubnet> Subnets { get; set; }

        [JsonIgnore]
        public string ServiceEndpointPolicyDefinitionsText
        {
            get { return JsonConvert.SerializeObject(ServiceEndpointPolicyDefinitions, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SubnetsText
        {
            get { return JsonConvert.SerializeObject(Subnets, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        public bool ShouldSerializeSubnets()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeServiceEndpointPolicyDefinitions()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}
