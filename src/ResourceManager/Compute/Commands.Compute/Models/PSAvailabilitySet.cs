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

using Microsoft.Azure.Management.Compute.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSAvailabilitySet
    {
        public string Id { get; set; }

        public string Location { get; set; }

        public string Name { get; set; }

        public int? PlatformFaultDomainCount { get; set; }

        public int? PlatformUpdateDomainCount { get; set; }

        public IList<InstanceViewStatus> Statuses { get; set; }

        [JsonIgnore]
        public string StatusesText
        {
            get { return JsonConvert.SerializeObject(Statuses, Formatting.Indented); }
        }

        public IDictionary<string, string> Tags { get; set; }

        [JsonIgnore]
        public string TagsText
        {
            get { return JsonConvert.SerializeObject(Tags, Formatting.Indented); }
        }

        public string Type { get; set; }

        public IList<VirtualMachineReference> VirtualMachinesReferences { get; set; }

        [JsonIgnore]
        public string VirtualMachinesReferencesText
        {
            get { return JsonConvert.SerializeObject(VirtualMachinesReferences, Formatting.Indented); }
        }
    }
}

