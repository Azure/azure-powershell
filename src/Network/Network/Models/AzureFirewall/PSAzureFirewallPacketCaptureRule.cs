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

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSAzureFirewallPacketCaptureRule
    {
        [JsonProperty(Order = 1)]
        public List<string> Sources { get; set; }

        [JsonProperty(Order = 2)]
        public List<string> Destinations { get; set; }

        [JsonProperty(Order = 3)]
        public List<string> DestinationPorts { get; set; }

        [JsonIgnore]
        public string SourcesText
        {
            get { return JsonConvert.SerializeObject(Sources, Formatting.Indented); }
        }

        [JsonIgnore]
        public string DestinationsText
        {
            get { return JsonConvert.SerializeObject(Destinations, Formatting.Indented); }
        }

        [JsonIgnore]
        public string DestinationPortsText
        {
            get { return JsonConvert.SerializeObject(DestinationPorts, Formatting.Indented); }
        }
    }
}
