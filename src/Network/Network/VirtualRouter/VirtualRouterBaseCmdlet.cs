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

using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using CNM = Microsoft.Azure.Commands.Network.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public class VirtualRouterBaseCmdlet : NetworkBaseCmdlet
    {
        // Gateway ASN which gets populated for VirtualHub as VR resides inside GW
        public const int GatewayAsn = 65515;

        public void AddBgpConnectionsToPSVirtualHub(VirtualHub virtualHub,
                                                  CNM.PSVirtualHub virtualHubModel,
                                                  string resourceGroupName,
                                                  string routerName)
        {
            var bgpConnections = this.NetworkClient.NetworkManagementClient.VirtualHubBgpConnections.List(resourceGroupName, routerName);
            var bgpConnectionList = ListNextLink<BgpConnection>.GetAllResourcesByPollingNextLink(bgpConnections, this.NetworkClient.NetworkManagementClient.VirtualHubBgpConnections.ListNext);
            foreach (var connection in bgpConnectionList)
            {
                virtualHubModel.BgpConnections.Add(NetworkResourceManagerProfile.Mapper.Map<CNM.PSBgpConnection>(connection));
            }
        }

        public void AddIpConfigurtaionToPSVirtualHub(CNM.PSVirtualHub virtualHubModel,
                                                    string resourceGroupName,
                                                    string routerName,
                                                    string ipConfigName)
        {
            var ipConfigModel = this.NetworkClient.NetworkManagementClient.VirtualHubIpConfiguration.Get(resourceGroupName, routerName, ipConfigName);
            var ipconfig = NetworkResourceManagerProfile.Mapper.Map<CNM.PSHubIpConfiguration>(ipConfigModel);
            virtualHubModel.IpConfigurations = new List<CNM.PSHubIpConfiguration>();
            virtualHubModel.IpConfigurations.Add(ipconfig);
        }
    }
}