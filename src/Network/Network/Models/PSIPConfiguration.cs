// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;

    public class PSIPConfiguration : PSChildResource
    {
        [JsonProperty(Order = 1)]
        public string PrivateIpAddress { get; set; }

        [JsonProperty(Order = 1)]
        public string PrivateIpAllocationMethod { get; set; }

        [JsonProperty(Order = 1)]
        public PSSubnet Subnet { get; set; }

        [JsonProperty(Order = 1)]
        public PSPublicIpAddress PublicIpAddress { get; set; }

        [JsonProperty(Order = 1)]
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string SubnetText
        {
            get { return JsonConvert.SerializeObject(Subnet, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string PublicIpAddressText
        {
            get { return JsonConvert.SerializeObject(PublicIpAddress, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
