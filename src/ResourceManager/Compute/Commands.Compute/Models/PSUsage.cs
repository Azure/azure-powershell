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
    public class PSUsage
    {
        // Gets or sets the property of 'CurrentValue'
        public int CurrentValue { get; set; }

        // Gets or sets the property of 'Limit'
        public uint Limit { get; set; }

        // Gets or sets the property of 'Name'
        public UsageName Name { get; set; }

        [JsonIgnore]
        public string NameText
        {
            get { return JsonConvert.SerializeObject(Name, Formatting.Indented); }
        }

        // Gets or sets the property of 'Unit'
        public UsageUnit Unit { get; set; }

        [JsonIgnore]
        public string UnitText
        {
            get { return JsonConvert.SerializeObject(Unit, Formatting.Indented); }
        }
    }
}
