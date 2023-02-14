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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Management.Automation;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RouteServerPeer", DefaultParameterSetName = RouteServerPeerParameterSetNames.ByRouteServerPeerName), OutputType(typeof(PSRouteServerPeer))]
    public partial class GetAzureRmRouteServerPeer : NetworkBaseCmdlet
    {
        [Parameter(
            ParameterSetName = RouteServerPeerParameterSetNames.ByRouteServerPeerName,
            Mandatory = true,
            HelpMessage = "The resource group name of the route server.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = RouteServerPeerParameterSetNames.ByRouteServerPeerName,
            Mandatory = true,
            HelpMessage = "The name of the route server peer.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string PeerName { get; set; }

        [Parameter(
            ParameterSetName = RouteServerPeerParameterSetNames.ByRouteServerPeerName,
            Mandatory = true,
            HelpMessage = "The name of the route server.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string RouteServerName { get; set; }

        [Parameter(
            ParameterSetName = RouteServerPeerParameterSetNames.ByRouteServerPeerResourceId,
            Mandatory = true,
            HelpMessage = "ResourceId of the route server peer.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs/bgpConnections")]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (string.Equals(this.ParameterSetName, RouteServerPeerParameterSetNames.ByRouteServerPeerResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceInfo.ResourceGroupName;
                PeerName = resourceInfo.ResourceName;
                RouteServerName = resourceInfo.ParentResource;
            }

            var bgpConnection = this.NetworkClient.NetworkManagementClient.VirtualHubBgpConnection.Get(ResourceGroupName, RouteServerName, PeerName);
            var peerModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSRouteServerPeer>(bgpConnection);

            WriteObject(peerModel, true);
        }
    }
}