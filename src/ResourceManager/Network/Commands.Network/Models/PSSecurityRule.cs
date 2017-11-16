﻿//
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

    public class PSSecurityRule : PSChildResource
    {
        [JsonProperty(Order = 1)]
        public string Description { get; set; }

        [JsonProperty(Order = 1)]
        public string Protocol { get; set; }

        [JsonProperty(Order = 1)]
        public IList<string> SourcePortRange { get; set; }

        [JsonProperty(Order = 1)]
        public IList<string> DestinationPortRange { get; set; }

        [JsonProperty(Order = 1)]
        public IList<string> SourceAddressPrefix { get; set; }

        [JsonProperty(Order = 1)]
        public IList<string> DestinationAddressPrefix { get; set; }

        [JsonProperty(Order = 1)]
        public string Access { get; set; }

        [JsonProperty(Order = 1)]
        public int Priority { get; set; }

        [JsonProperty(Order = 1)]
        public string Direction { get; set; }

        [JsonProperty(Order = 1)]
        public string ProvisioningState { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSApplicationSecurityGroup> SourceApplicationSecurityGroups { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSApplicationSecurityGroup> DestinationApplicationSecurityGroups { get; set; }

        [JsonIgnore]
        public string SourceApplicationSecurityGroupsText
        {
            get { return JsonConvert.SerializeObject(SourceApplicationSecurityGroups, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string DestinationApplicationSecurityGroupsText
        {
            get { return JsonConvert.SerializeObject(DestinationApplicationSecurityGroups, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
