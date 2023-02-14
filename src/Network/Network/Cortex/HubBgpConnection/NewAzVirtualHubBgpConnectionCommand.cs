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
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using MNM = Microsoft.Azure.Management.Network.Models;

    using System.Management.Automation;

    [Cmdlet(VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzurePrefix + "VirtualHubBgpConnection",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject,
        SupportsShouldProcess = true),
        OutputType(typeof(PSBgpConnection))]
    public class NewAzVirtualHubBgpConnectionCommand : HubBgpConnectionBaseCmdlet
    {
        [Parameter(Mandatory = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The virtual hub name.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            HelpMessage = "The virtual hub name.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [ResourceNameCompleter("Microsoft.Network/virtualHubs", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VirtualHubName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The peer IP.")]
        [ValidateNotNullOrEmpty]
        public string PeerIp { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The peer ASN.")]
        public uint PeerAsn { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource name.")]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The VirtualHubVnetConnection resource.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            HelpMessage = "The VirtualHubVnetConnection resource.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            HelpMessage = "The VirtualHubVnetConnection resource.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [ValidateNotNull]
        public PSHubVirtualNetworkConnection VirtualHubVnetConnection { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The VirtualHubVnetConnection resource id.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [Parameter(Mandatory = true,
            HelpMessage = "The VirtualHubVnetConnection resource id.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [Parameter(Mandatory = true,
            HelpMessage = "The VirtualHubVnetConnection resource id.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [ValidateNotNullOrEmpty]
        public string VirtualHubVnetConnectionId { get; set; }

        [Alias("ParentObject", "ParentVirtualHub")]
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual hub resource.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual hub resource.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        public PSVirtualHub VirtualHub { get; set; }

        [Alias("ParentResourceId", "ParentVirtualHubId")]
        [Parameter(Mandatory = true,
            HelpMessage = "The virtual hub resource id.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            HelpMessage = "The virtual hub resource id.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [ValidateNotNullOrEmpty]
        public string VirtualHubId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ParameterSetName.Contains(CortexParameterSetNames.ByVirtualHubObject))
            {
                this.ResourceGroupName = this.VirtualHub.ResourceGroupName;
                this.VirtualHubName = this.VirtualHub.Name;
            }
            else if (ParameterSetName.Contains(CortexParameterSetNames.ByVirtualHubResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.VirtualHubId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.VirtualHubName = parsedResourceId.ResourceName;
            }

            if (this.IsVirtualHubBgpConnectionPresent(this.ResourceGroupName, this.VirtualHubName, this.Name))
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ChildResourceAlreadyPresentInResourceGroup, this.Name, this.ResourceGroupName, this.VirtualHubName));
            }

            MNM.SubResource hubVnetConnection = null;
            if (ParameterSetName.Contains(CortexParameterSetNames.ByHubVirtualNetworkConnectionObject))
            {
                hubVnetConnection = new MNM.SubResource(this.VirtualHubVnetConnection.Id);
            }
            else if (ParameterSetName.Contains(CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId))
            {
                hubVnetConnection = new MNM.SubResource(this.VirtualHubVnetConnectionId);
            }

            var bgpConnectionToCreate = new MNM.BgpConnection
            {
                Name = this.Name,
                PeerAsn = this.PeerAsn,
                PeerIp = this.PeerIp,
                HubVirtualNetworkConnection = hubVnetConnection
            };

            this.ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(string.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    WriteObject(this.CreateOrUpdateVirtualHubBgpConnection(this.ResourceGroupName, this.VirtualHubName, this.Name, bgpConnectionToCreate));
                });
        }
    }
}
