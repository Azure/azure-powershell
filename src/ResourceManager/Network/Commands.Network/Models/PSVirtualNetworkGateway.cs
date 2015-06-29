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
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class PSVirtualNetworkGateway : PSTopLevelResource
    {
        public List<PSVirtualNetworkGatewayIpConfiguration> IpConfigurations { get; set; }

        public string GatewayType { get; set; }

        public string VpnType { get; set; }

        public bool EnableBgp { get; set; }
        
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string IpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(IpConfigurations, Formatting.Indented); }
        }
    }
}
