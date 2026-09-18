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


namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Management.Automation;

    public class PSNetworkManagerRoutingRuleCollection : PSNetworkManagerBaseResource
    {
        public string NetworkManagerName { get; set; }
        public string RoutingConfigurationName { get; set; }

        [JsonProperty(Order = 1)]
        public IList<PSNetworkManagerRoutingGroupItem> AppliesTo { get; set; }

        public string DisableBgpRoutePropagation { get; set; }

        [JsonIgnore]
        public string AppliesToText
        {
            get { return JsonConvert.SerializeObject(AppliesTo, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
