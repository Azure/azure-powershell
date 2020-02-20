// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSVirtualRouter : PSTopLevelResource
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public PSResourceId HostedGateway { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public uint VirtualRouterAsn { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public List<string> VirtualRouterIps { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }
        public List<PSVirtualRouterPeer> Peerings { get; set; }

        [JsonIgnore]
        public string PeeringsText
        {
            get { return JsonConvert.SerializeObject(Peerings, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string HostedGatewayText
        {
            get { return JsonConvert.SerializeObject(HostedGateway, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
