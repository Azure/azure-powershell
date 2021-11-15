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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    [CmdletDeprecation(ReplacementCmdletName = "Remove-AzRouteServerPeer")]
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualRouterPeer", SupportsShouldProcess = true, DefaultParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerName), OutputType(typeof(PSVirtualRouter))]
    public partial class RemoveAzureRmVirtualRouterPeer : VirtualRouterBaseCmdlet
    {
        [Parameter(
            ParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerName,
            Mandatory = true,
            HelpMessage = "The resource group name of the virtual router/peer.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerName,
            Mandatory = true,
            HelpMessage = "The name of the virtual router Peer.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PeerName { get; set; }

        [Parameter(
            ParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual router where peer exists.")]
        public string VirtualRouterName { get; set; }

        [Parameter(
            ParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerInputObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual router peer input object.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualRouterPeer InputObject { get; set; }

        [Parameter(
            ParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual router peer resource Id.")]
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
            if (ParameterSetName.Equals(VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerInputObject, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(InputObject.Id);
                PeerName = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
                VirtualRouterName = parsedResourceId.ParentResource;
            }
            else if (ParameterSetName.Equals(VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                PeerName = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
                VirtualRouterName = parsedResourceId.ParentResource;
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

                    this.NetworkClient.NetworkManagementClient.VirtualHubBgpConnection.Delete(ResourceGroupName, VirtualRouterName, PeerName);
                    var virtualHub = this.NetworkClient.NetworkManagementClient.VirtualHubs.Get(ResourceGroupName, VirtualRouterName);
                    var virtualHubModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSVirtualHub>(virtualHub);
                    virtualHubModel.ResourceGroupName = this.ResourceGroupName;
                    virtualHubModel.Tag = TagsConversionHelper.CreateTagHashtable(virtualHub.Tags);
                    AddBgpConnectionsToPSVirtualHub(virtualHub, virtualHubModel, ResourceGroupName, this.VirtualRouterName);
                    AddIpConfigurtaionToPSVirtualHub(virtualHubModel, this.ResourceGroupName, this.VirtualRouterName, ipConfigName);

                    var vVirtualRouterModel = new PSVirtualRouter(virtualHubModel);
                    vVirtualRouterModel.Tag = TagsConversionHelper.CreateTagHashtable(virtualHub.Tags);

                    WriteObject(vVirtualRouterModel, true);
                });
        }
    }
}