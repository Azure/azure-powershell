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

    public class PSLoadBalancingRule : PSInboundRule
    {
        [JsonProperty(Order = 1)]
        public PSResourceId BackendAddressPool { get; set; }

        [JsonProperty(Order = 1)]
        public PSResourceId Probe { get; set; }

        [JsonProperty(Order = 1)]
        public int FrontendPort { get; set; }

        [JsonProperty(Order = 1)]
        public int? IdleTimeoutInMinutes { get; set; }

        [JsonProperty(Order = 1)]
        public string LoadDistribution { get; set; }

        [JsonProperty(Order = 1)]
        public bool? EnableFloatingIP { get; set; }

        [JsonIgnore]
        public string BackendAddressPoolText
        {
            get { return JsonConvert.SerializeObject(BackendAddressPool, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ProbeText
        {
            get { return JsonConvert.SerializeObject(Probe, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeFrontendPort()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}
