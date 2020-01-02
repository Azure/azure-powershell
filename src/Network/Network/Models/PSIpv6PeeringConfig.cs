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
    using Microsoft.Azure.Management.Network.Models;

    using Newtonsoft.Json;

    public class PSIpv6PeeringConfig : PSChildResource
    {
        [JsonProperty(Order = 1)]
        public string State { get; set; }

        [JsonProperty(Order = 1)]
        public string PrimaryPeerAddressPrefix { get; set; }

        [JsonProperty(Order = 1)]
        public string SecondaryPeerAddressPrefix { get; set; }

        [JsonProperty(Order = 1)]
        public PSPeeringConfig MicrosoftPeeringConfig { get; set; }

        [JsonProperty(Order = 1)]
        public PSRouteFilter RouteFilter { get; set; }

        [JsonIgnore]
        public string MicrosoftPeeringConfigText
        {
            get { return JsonConvert.SerializeObject(MicrosoftPeeringConfig, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RouteFilterText
        {
            get { return JsonConvert.SerializeObject(RouteFilter, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
