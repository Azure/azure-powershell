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

    public class PSInboundNatRule : PSInboundRule
    {
        [JsonProperty(Order = 1)]
        public int FrontendPort { get; set; }

        [JsonProperty(Order = 1)]
        public int? IdleTimeoutInMinutes { get; set; }

        [JsonProperty(Order = 1)]
        public bool? EnableFloatingIP { get; set; }

        [JsonProperty(Order = 1)]
        public PSNetworkInterfaceIPConfiguration BackendIPConfiguration { get; set; }

        [JsonIgnore]
        public string BackendIPConfigurationText
        {
            get { return JsonConvert.SerializeObject(BackendIPConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeFrontendPort()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}
