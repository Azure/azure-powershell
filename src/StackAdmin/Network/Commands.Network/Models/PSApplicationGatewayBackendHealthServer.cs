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

using Newtonsoft.Json;
namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSApplicationGatewayBackendHealthServer
    {
        public string Address { get; set; }

        public PSNetworkInterfaceIPConfiguration IpConfiguration { get; set; }

        public string Health { get; set; }

        [JsonIgnore]
        public string IpConfigurationText
        {
            get { return JsonConvert.SerializeObject(IpConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
