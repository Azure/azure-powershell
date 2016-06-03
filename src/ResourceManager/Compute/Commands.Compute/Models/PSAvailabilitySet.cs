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
//

using Microsoft.Azure.Management.Compute.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSAvailabilitySet : PSOperation
    {
        // Gets or sets the property of 'ResourceGroupName'
        public string ResourceGroupName
        {
            get
            {
                Regex r = new Regex(@"(.*?)/resourcegroups/(?<rgname>\S+)/providers/(.*?)", RegexOptions.IgnoreCase);
                Match m = r.Match(Id);
                return m.Success ? m.Groups["rgname"].Value : null;
            }
        }

        // Gets or sets the property of 'Id'
        public string Id { get; set; }

        // Gets or sets the property of 'Name'
        public string Name { get; set; }

        // Gets or sets the property of 'Type'
        public string Type { get; set; }

        // Gets or sets the property of 'Location'
        public string Location { get; set; }

        // Gets or sets the property of 'Tags'
        public IDictionary<string, string> Tags { get; set; }

        [JsonIgnore]
        public string TagsText
        {
            get { return JsonConvert.SerializeObject(Tags, Formatting.Indented); }
        }

        // Gets or sets Fault Domain count.
        public int? PlatformFaultDomainCount { get; set; }

        // Gets or sets Update Domain count.
        public int? PlatformUpdateDomainCount { get; set; }

        // Gets or sets the resource status information.
        public IList<InstanceViewStatus> Statuses { get; set; }

        [JsonIgnore]
        public string StatusesText
        {
            get { return JsonConvert.SerializeObject(Statuses, Formatting.Indented); }
        }

        // Gets or sets a list containing reference to all Virtual Machines created under this Availability Set.
        public IList<SubResource> VirtualMachinesReferences { get; set; }

        [JsonIgnore]
        public string VirtualMachinesReferencesText
        {
            get { return JsonConvert.SerializeObject(VirtualMachinesReferences, Formatting.Indented); }
        }
    }
}
