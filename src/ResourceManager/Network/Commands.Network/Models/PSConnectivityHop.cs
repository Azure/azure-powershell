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

    public class PSConnectivityHop
    {
        [JsonProperty(Order = 2)]
        public string Type { get; set; }

        [JsonProperty(Order = 2)]
        public string Id { get; set; }

        [JsonProperty(Order = 2)]
        public string Address { get; set; }

        [JsonProperty(Order = 2)]
        public string ResourceId { get; set; }

        [JsonProperty(Order = 2)]
        public List<string> NextHopIds { get; set; }

        [JsonProperty(Order = 2)]
        public List<PSConnectivityIssue> Issues { get; set; }

        [JsonIgnore]
        public string IssuesText
        {
            get { return JsonConvert.SerializeObject(this.Issues, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
