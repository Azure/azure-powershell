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

using Azure.Analytics.Synapse.Artifacts.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLinkConnectionQueryTableStatus
    {
        public PSLinkConnectionQueryTableStatus(LinkConnectionQueryTableStatus linkConnectionQueryTableStatus)
        {
            this.Value = linkConnectionQueryTableStatus?.Value.Select(element => new PSLinkTableStatus(element)).ToList();
            this.ContinuationToken = linkConnectionQueryTableStatus?.ContinuationToken;
        }

        public IReadOnlyList<PSLinkTableStatus> Value { get; }

        public object ContinuationToken { get; }

        [JsonIgnore]
        public string ValueText
        {
            get { return JsonConvert.SerializeObject(Value, Formatting.Indented, new JsonSerializerSettings()); }
        }
    }
}
