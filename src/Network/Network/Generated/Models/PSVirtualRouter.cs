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
using System.Linq;


namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSVirtualRouter : PSTopLevelResource
    {
        public PSVirtualRouter()
        {
        }

        public PSVirtualRouter(PSVirtualHub virtualHub)
        {
            this.Name = virtualHub.Name;
            this.Id = virtualHub.Id;
            this.ResourceGroupName = virtualHub.ResourceGroupName;
            this.Location = virtualHub.Location;
            this.ResourceGuid = virtualHub.ResourceGuid;
            this.Type = virtualHub.Type;
            var ipconfig = virtualHub.IpConfigurations.FirstOrDefault<PSHubIpConfiguration>();
            this.HostedSubnet = ipconfig.Subnet.Id;
            this.VirtualRouterAsn = virtualHub.VirtualRouterAsn;
            this.VirtualRouterIps = virtualHub.VirtualRouterIps;
            this.ProvisioningState = virtualHub.ProvisioningState;
            this.Peerings = new List<PSVirtualRouterPeer>();
            foreach (var connection in virtualHub.BgpConnections)
            {
                var peering = new PSVirtualRouterPeer()
                {
                    Name = connection.Name,
                    PeerIp = connection.PeerIp,
                    PeerAsn = connection.PeerAsn,
                    ProvisioningState = connection.ProvisioningState
                };
                this.Peerings.Add(peering);
            }
            this.AllowBranchToBranchTraffic = virtualHub.AllowBranchToBranchTraffic;
        }

        [Ps1Xml(Target = ViewControl.Table)]
        public uint VirtualRouterAsn { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public List<string> VirtualRouterIps { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }
        public string HostedSubnet { get; set; }
        public List<PSVirtualRouterPeer> Peerings { get; set; }
        public bool AllowBranchToBranchTraffic { get; set; }

        [JsonIgnore]
        public string PeeringsText
        {
            get { return JsonConvert.SerializeObject(Peerings, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}