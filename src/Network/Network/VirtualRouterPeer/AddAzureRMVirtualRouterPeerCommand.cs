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
using System.Linq;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    [CmdletDeprecation(ReplacementCmdletName = "Add-AzRouteServerPeer")]
    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualRouterPeer", SupportsShouldProcess = true, DefaultParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterName), OutputType(typeof(PSVirtualRouter))]
    public partial class AddAzureRmVirtualRouterPeer : VirtualRouterBaseCmdlet
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
            Mandatory = true,
            HelpMessage = "The name of the virtual router Peer.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PeerName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Ip of remote VirtualRouter peer.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PeerIp { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "ASN of remote VirtualRouter peer.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public uint PeerAsn { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterName,
            HelpMessage = "The virtual router where peer exists.")]
        public string VirtualRouterName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var present = true;
            try
            {
                this.NetworkClient.NetworkManagementClient.VirtualHubBgpConnection.Get(this.ResourceGroupName, this.VirtualRouterName, this.PeerName);
            }
            catch (Exception ex)
            {
                if (ex is Microsoft.Azure.Management.Network.Models.ErrorException || ex is Rest.Azure.CloudException)
                {
                    // Resource is not present
                    present = false;
                }
                else
                {
                    throw;
                }
            }

            if (present)
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ResourceAlreadyPresentInResourceGroup, this.PeerName, this.ResourceGroupName, this.VirtualRouterName));
            }

            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                PeerName,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.PeerName));
                    PSVirtualRouterPeer peer = new PSVirtualRouterPeer
                    {
                        PeerAsn = this.PeerAsn,
                        PeerIp = this.PeerIp,
                        Name = this.PeerName
                    };
                    string ipConfigName = "ipconfig1";

                    var bgpConnectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.BgpConnection>(peer);
                    
                    this.NetworkClient.NetworkManagementClient.VirtualHubBgpConnection.CreateOrUpdate(this.ResourceGroupName, this.VirtualRouterName, this.PeerName, bgpConnectionModel);
                    var virtualHub = this.NetworkClient.NetworkManagementClient.VirtualHubs.Get(this.ResourceGroupName, this.VirtualRouterName);
                    var virtualHubModel = NetworkResourceManagerProfile.Mapper.Map<PSVirtualHub>(virtualHub);
                    virtualHubModel.ResourceGroupName = this.ResourceGroupName;
                    virtualHubModel.Tag = TagsConversionHelper.CreateTagHashtable(virtualHub.Tags);
                    AddBgpConnectionsToPSVirtualHub(virtualHub, virtualHubModel, ResourceGroupName, this.VirtualRouterName);
                    AddIpConfigurtaionToPSVirtualHub(virtualHubModel, this.ResourceGroupName, this.VirtualRouterName, ipConfigName);

                    var VirtualRouterModel = new PSVirtualRouter(virtualHubModel);
                    VirtualRouterModel.Tag = TagsConversionHelper.CreateTagHashtable(virtualHub.Tags);

                    WriteObject(VirtualRouterModel, true);
                });

        }
    }
}