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
        // Gateway ASN which gets populated for VirtualRouter as VR resides inside GW
        public const int GatewayAsn = 65515;

        public void AddPeeringsToPSVirtualRouter (VirtualRouter vVirtualRouter, 
                                                  CNM.PSVirtualRouter vVirtualRouterModel,
                                                  string resourceGroupName,
                                                  string routerName)
        {
            if (vVirtualRouter.Peerings != null && vVirtualRouter.Peerings.Count > 0)
            {
                var vVirtualRouterPeering = this.NetworkClient.NetworkManagementClient.VirtualRouterPeerings.List(resourceGroupName, routerName);
                var vVirtualRouterPeeringList = ListNextLink<VirtualRouterPeering>.GetAllResourcesByPollingNextLink(vVirtualRouterPeering, this.NetworkClient.NetworkManagementClient.VirtualRouterPeerings.ListNext);
                foreach (var peering in vVirtualRouterPeeringList)
                {
                    vVirtualRouterModel.Peerings.Add(NetworkResourceManagerProfile.Mapper.Map<CNM.PSVirtualRouterPeer>(peering));
                }
            }
        }
    }
}