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
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PSInterfaceEndpoint : PSTopLevelResource
    {
        [JsonProperty(Order = 1)]
        public string Fqdn { get; set; }

        [JsonProperty(Order = 1)]
        public PSEndpointService EndpointService { get; set; }

        [JsonProperty(Order = 1)]
        public string Owner { get; set; }

        [JsonProperty(Order = 1)]
        public PSSubnet Subnet { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSNetworkInterface> NetworkInterfaces { get; set; }

        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string NetworkInterfacesText
        {
            get { return JsonConvert.SerializeObject(NetworkInterfaces, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SubnetText
        {
            get { return JsonConvert.SerializeObject(Subnet, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string EndpointServiceText
        {
            get { return JsonConvert.SerializeObject(EndpointService, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
