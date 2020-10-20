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
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using CNM = Microsoft.Azure.Commands.Network.Models;
using System.Linq;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.Common.Strategies;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualRouterPeer", SupportsShouldProcess = true, DefaultParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterName), OutputType(typeof(PSVirtualRouter))]
    public partial class UpdateAzureRmVirtualRouterPeer : VirtualRouterBaseCmdlet
    {
        [Parameter(
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
            HelpMessage = "Ip of remote VirtualRouter peer.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PeerIp { get; set; }

        [Parameter(
            ParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerName,
            Mandatory = true,
            HelpMessage = "ASN of remote VirtualRouter peer.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public uint PeerAsn { get; set; }

        [Parameter(
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
        [ResourceIdCompleter("Microsoft.Network/virtualRouters/peerings")]
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
                PeerName = InputObject.Name;
                PeerAsn = InputObject.PeerAsn;
                PeerIp = InputObject.PeerIp;
            }
            else if (ParameterSetName.Equals(VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                PeerName = parsedResourceId.ResourceName;
            }

            base.Execute();

            var present = true;
            VirtualRouterPeering existingVirtualRouterPeer = null;

            try
            {
                existingVirtualRouterPeer = this.NetworkClient.NetworkManagementClient.VirtualRouterPeerings.Get(this.ResourceGroupName, this.VirtualRouterName, this.PeerName);
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
                throw new PSArgumentException(string.Format(Properties.Resources.ResourceNotFound, this.PeerName, this.ResourceGroupName, this.VirtualRouterName));
            }

            if (ParameterSetName.Equals(VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                PeerAsn = (uint) existingVirtualRouterPeer.PeerAsn;
                PeerIp = existingVirtualRouterPeer.PeerIp;
            }

            ConfirmAction(
                Properties.Resources.SettingResourceMessage,
                PeerName,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.UpdatingLongRunningOperationMessage, this.ResourceGroupName, this.PeerName));
                    PSVirtualRouterPeer virtualRouterPeer = new PSVirtualRouterPeer
                    {
                        Name = this.PeerName,
                        PeerAsn = this.PeerAsn,
                        PeerIp = this.PeerIp
                    };

                    var vVirtualRouterPeerModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualRouterPeering>(virtualRouterPeer);

                    this.NetworkClient.NetworkManagementClient.VirtualRouterPeerings.CreateOrUpdate(this.ResourceGroupName, this.VirtualRouterName, this.PeerName, vVirtualRouterPeerModel);
                    var getVirtualRouter = this.NetworkClient.NetworkManagementClient.VirtualRouters.Get(this.ResourceGroupName, this.VirtualRouterName);
                    var vVirtualRouterModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSVirtualRouter>(getVirtualRouter);
                    vVirtualRouterModel.ResourceGroupName = this.ResourceGroupName;
                    vVirtualRouterModel.Tag = TagsConversionHelper.CreateTagHashtable(getVirtualRouter.Tags);
                    AddPeeringsToPSVirtualRouter(getVirtualRouter, vVirtualRouterModel, ResourceGroupName, this.VirtualRouterName);

                    WriteObject(vVirtualRouterModel, true);
                });

        }
    }
}
