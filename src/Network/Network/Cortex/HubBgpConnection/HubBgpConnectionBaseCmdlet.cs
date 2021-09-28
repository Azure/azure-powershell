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

namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Management.Network;

    using System.Collections.Generic;
    using System.Linq;

    using MNM = Microsoft.Azure.Management.Network.Models;

    public class HubBgpConnectionBaseCmdlet : NetworkBaseCmdlet
    {
        public PSBgpConnection GetVirtualHubBgpConnection(string resourceGroupName, string virtualHubName, string name)
        {
            var bgpConnection = this.NetworkClient.NetworkManagementClient.VirtualHubBgpConnection
                    .Get(resourceGroupName, virtualHubName, name);
            return this.ConvertToPsBgpConnection(bgpConnection);
        }

        public IEnumerable<PSBgpConnection> ListVirtualHubBgpConnections(string resourceGroupName, string virtualHubName, string nameWithWildcard)
        {
            var allBgpConnections = this.NetworkClient.NetworkManagementClient.VirtualHubBgpConnections
                    .List(resourceGroupName, virtualHubName)
                    .Select(this.ConvertToPsBgpConnection);
            return SubResourceWildcardFilter(nameWithWildcard, allBgpConnections);
        }

        public PSBgpConnection CreateOrUpdateVirtualHubBgpConnection(string resourceGroupName, string virtualHubName, string name, MNM.BgpConnection bgpConnection)
        {
            var createdBgpConnection = this.NetworkClient.NetworkManagementClient.VirtualHubBgpConnection
                .CreateOrUpdate(resourceGroupName, virtualHubName, name, bgpConnection);
            return this.ConvertToPsBgpConnection(createdBgpConnection);
        }

        public bool IsVirtualHubBgpConnectionPresent(string resourceGroupName, string virtualHubName, string name)
        {
            return IsResourcePresent(() => this.GetVirtualHubBgpConnection(resourceGroupName, virtualHubName, name));
        }

        public PSBgpConnection ConvertToPsBgpConnection(MNM.BgpConnection bgpConnection)
        {
            return NetworkResourceManagerProfile.Mapper.Map<PSBgpConnection>(bgpConnection);
        }
    }
}
