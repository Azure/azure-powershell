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
using Microsoft.Azure.Management.Network.Models;

using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSLoadBalancerBackendAddress : PSChildResource
    {
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public PSNetworkInterfaceIPConfiguration NetworkInterfaceIpConfiguration { get; set; }

        [JsonProperty(Order = 2)]
        public PSVirtualNetwork VirtualNetwork { get; set; }

        [JsonProperty(Order = 3)]
        public string IpAddress { get; set; }

        [JsonIgnore]
        public string NetworkInterfaceIpConfigurationText
        {
            get { return JsonConvert.SerializeObject(NetworkInterfaceIpConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VirtualNetworkChildResourceText
        {
            get
            {
                // convert to child resource object to limit size of the output seen on the powershell console
                var virtualNetworkChildResource = new PSChildResource
                {
                    Name = VirtualNetwork?.Name,
                    Id = VirtualNetwork?.Id,
                    Etag = VirtualNetwork?.Etag
                };

                return JsonConvert.SerializeObject(virtualNetworkChildResource, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            }
        }
    }
}
