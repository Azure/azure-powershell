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
using System.Net;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.Common.Strategies;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RouteServerPeer", SupportsShouldProcess = true, DefaultParameterSetName = RouteServerPeerParameterSetNames.ByRouteServerName), OutputType(typeof(PSRouteServer))]
    public partial class UpdateAzureRmRouteServerPeer : RouteServerBaseCmdlet
    {
        [Parameter(
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
            HelpMessage = "Ip of remote route server peer.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PeerIp { get; set; }

        [Parameter(
            ParameterSetName = RouteServerPeerParameterSetNames.ByRouteServerPeerName,
            Mandatory = true,
            HelpMessage = "ASN of remote route server peer.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public uint PeerAsn { get; set; }

        [Parameter(
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
                PeerName = InputObject.Name;
                PeerAsn = InputObject.PeerAsn;
                PeerIp = InputObject.PeerIp;
            }
            else if (ParameterSetName.Equals(RouteServerPeerParameterSetNames.ByRouteServerPeerResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                PeerName = parsedResourceId.ResourceName;
            }

            base.Execute();

            var present = true;
            BgpConnection existingBgpConnection = null;

            try
            {
                existingBgpConnection = this.NetworkClient.NetworkManagementClient.VirtualHubBgpConnection.Get(this.ResourceGroupName, this.RouteServerName, this.PeerName);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    present = false;
                }
                else
                {
                    throw;
                }
            }

            if (!present)
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ResourceNotFound, this.PeerName, this.ResourceGroupName, this.RouteServerName));
            }

            if (ParameterSetName.Equals(RouteServerPeerParameterSetNames.ByRouteServerPeerResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                PeerAsn = (uint)existingBgpConnection.PeerAsn;
                PeerIp = existingBgpConnection.PeerIp;
            }

            ConfirmAction(
                Properties.Resources.SettingResourceMessage,
                PeerName,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.UpdatingLongRunningOperationMessage, this.ResourceGroupName, this.PeerName));
                    PSRouteServerPeer peer = new PSRouteServerPeer
                    {
                        Name = this.PeerName,
                        PeerAsn = this.PeerAsn,
                        PeerIp = this.PeerIp
                    };
                    string ipConfigName = "ipconfig1";


                    var bgpConnectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.BgpConnection>(peer);

                    this.NetworkClient.NetworkManagementClient.VirtualHubBgpConnection.CreateOrUpdate(this.ResourceGroupName, this.RouteServerName, this.PeerName, bgpConnectionModel);
                    var virtualHub = this.NetworkClient.NetworkManagementClient.VirtualHubs.Get(this.ResourceGroupName, this.RouteServerName);
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
