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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    [CmdletDeprecation(ReplacementCmdletName = "Get-AzRouteServerPeer")]
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualRouterPeer", DefaultParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerName), OutputType(typeof(PSVirtualRouterPeer))]
    public partial class GetAzureRmVirtualRouterPeer : NetworkBaseCmdlet
    {
        [Parameter(
            ParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerName,
            Mandatory = true,
            HelpMessage = "The resource group name of the virtual router.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerName,
            Mandatory = true,
            HelpMessage = "The name of the virtual router peer.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string PeerName { get; set; }

        [Parameter(
            ParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerName,
            Mandatory = true,
            HelpMessage = "The name of the virtual router.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string VirtualRouterName { get; set; }

        [Parameter(
            ParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerResourceId,
            Mandatory = true,
            HelpMessage = "ResourceId of the virtual router peer.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs/bgpConnections")]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (string.Equals(this.ParameterSetName, VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceInfo.ResourceGroupName;
                PeerName = resourceInfo.ResourceName;
                VirtualRouterName = resourceInfo.ParentResource;
            }

            var bgpConnection = this.NetworkClient.NetworkManagementClient.VirtualHubBgpConnection.Get(ResourceGroupName, VirtualRouterName, PeerName);
            var peerModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSVirtualRouterPeer>(bgpConnection);

            WriteObject(peerModel, true);
        }
    }
}