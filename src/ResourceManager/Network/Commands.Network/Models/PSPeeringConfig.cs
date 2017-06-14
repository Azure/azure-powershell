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
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PSPeeringConfig
    {
        public List<string> AdvertisedPublicPrefixes { get; set; }

        [JsonProperty(Order = 1)]
        public string AdvertisedPublicPrefixesState { get; set; }

        [JsonProperty(Order = 1)]
        public int CustomerASN { get; set; }

        [JsonProperty(Order = 1)]
        public string RoutingRegistryName { get; set; }

        [JsonIgnore]
        public string AdvertisedPublicPrefixesSText
        {
            get { return JsonConvert.SerializeObject(AdvertisedPublicPrefixes, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
