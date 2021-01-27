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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using System;
using CNM = Microsoft.Azure.Commands.Network.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RouteServerPeer", SupportsShouldProcess = true, DefaultParameterSetName = RouteServerPeerParameterSetNames.ByRouteServerPeerName), OutputType(typeof(PSRouteServer))]
    public partial class RemoveAzureRmRouteServerPeer : RouteServerBaseCmdlet
    {
        [Parameter(
            ParameterSetName = RouteServerPeerParameterSetNames.ByRouteServerPeerName,
            Mandatory = true,
            HelpMessage = "The resource group name of the route server/peer.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = RouteServerPeerParameterSetNames.ByRouteServerPeerName,
            Mandatory = true,
            HelpMessage = "The name of the route server Peer.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PeerName { get; set; }

        [Parameter(
            ParameterSetName = RouteServerPeerParameterSetNames.ByRouteServerPeerName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The route server where peer exists.")]
        public string RouteServerName { get; set; }

        [Parameter(
            ParameterSetName = RouteServerPeerParameterSetNames.ByRouteServerPeerInputObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The route server peer input object.")]
        [ValidateNotNullOrEmpty]
        public PSRouteServerPeer InputObject { get; set; }

        [Parameter(
            ParameterSetName = RouteServerPeerParameterSetNames.ByRouteServerPeerResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The route server peer resource Id.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs/bgpConnections")]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (ParameterSetName.Equals(RouteServerPeerParameterSetNames.ByRouteServerPeerInputObject, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(InputObject.Id);
                PeerName = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
                RouteServerName = parsedResourceId.ParentResource;
            }
            else if (ParameterSetName.Equals(RouteServerPeerParameterSetNames.ByRouteServerPeerResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                PeerName = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
                RouteServerName = parsedResourceId.ParentResource;
            }

            base.Execute();

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, PeerName),
                Properties.Resources.RemoveResourceMessage,
                PeerName,
                () =>
                {
                    string ipConfigName = "ipconfig1";

                    this.NetworkClient.NetworkManagementClient.VirtualHubBgpConnection.Delete(ResourceGroupName, RouteServerName, PeerName);
                    var virtualHub = this.NetworkClient.NetworkManagementClient.VirtualHubs.Get(ResourceGroupName, RouteServerName);
                    var virtualHubModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSVirtualHub>(virtualHub);
                    virtualHubModel.ResourceGroupName = this.ResourceGroupName;
                    virtualHubModel.Tag = TagsConversionHelper.CreateTagHashtable(virtualHub.Tags);
                    AddBgpConnectionsToPSVirtualHub(virtualHubModel, ResourceGroupName, this.RouteServerName);
                    AddIpConfigurtaionToPSVirtualHub(virtualHubModel, this.ResourceGroupName, this.RouteServerName, ipConfigName);

                    var routeServerModel = new PSRouteServer(virtualHubModel);
                    routeServerModel.Tag = TagsConversionHelper.CreateTagHashtable(virtualHub.Tags);

                    WriteObject(routeServerModel, true);
                });
        }
    }
}