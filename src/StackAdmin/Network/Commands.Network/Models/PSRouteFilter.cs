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
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class PSRouteFilter: PSTopLevelResource
    {
        public List<PSRouteFilterRule> Rules { get; set; }

        public List<PSPeering> Peerings { get; set; }

        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string RulesText
        {
            get { return JsonConvert.SerializeObject(Rules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore}); }
        }

        [JsonIgnore]
        public string PeeringsText
        {
            get
            {
                return JsonConvert.SerializeObject(Peerings, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });
            }
        }

        public bool ShouldSerializePeerings()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeRules()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}
