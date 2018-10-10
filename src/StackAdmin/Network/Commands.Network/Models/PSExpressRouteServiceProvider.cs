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

    public class PSExpressRouteServiceProvider
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public string Type { get; set; }

        public List<string> PeeringLocations { get; set; }

        public List<PSExpressRouteServiceProviderBandwidthsOffered> BandwidthsOffered { get; set; }

        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string BandwidthsOfferedText
        {
            get { return JsonConvert.SerializeObject(BandwidthsOffered, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string PeeringLocationsText
        {
            get { return JsonConvert.SerializeObject(PeeringLocations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
