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

namespace Microsoft.Azure.Commands.Network
{
    public class VirtualRouterBaseCmdlet : NetworkBaseCmdlet
    {
        // Gateway ASN which gets populated for VirtualHub as VR resides inside GW
        public const int GatewayAsn = 65515;

        public void AddBgpConnectionsToPSVirtualHub (VirtualHub vVirtualHub, 
                                                  CNM.PSVirtualHub vVirtualHubModel,
                                                  string resourceGroupName,
                                                  string routerName)
        {
            if (vVirtualHubModel.BgpConnections != null && vVirtualHubModel.BgpConnections.Count > 0)
            {
                var bgpConnections = this.NetworkClient.NetworkManagementClient.VirtualHubBgpConnections.List(resourceGroupName, routerName);
                var bgpConnectionList = ListNextLink<BgpConnection>.GetAllResourcesByPollingNextLink(bgpConnections, this.NetworkClient.NetworkManagementClient.VirtualHubBgpConnections.ListNext);
                    foreach (var connection in bgpConnectionList)
                    {
                        vVirtualHubModel.BgpConnections.Add(NetworkResourceManagerProfile.Mapper.Map<CNM.PSBgpConnection>(connection));
                    }
                }
        }
    }
}