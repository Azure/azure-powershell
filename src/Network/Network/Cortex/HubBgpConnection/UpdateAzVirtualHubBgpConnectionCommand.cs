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
    using System;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using MNM = Microsoft.Azure.Management.Network.Models;

    [Cmdlet("Update",
        ResourceManager.Common.AzureRMConstants.AzurePrefix + "VirtualHubBgpConnection",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject,
        SupportsShouldProcess = true),
        OutputType(typeof(PSBgpConnection))]
    public class UpdateAzVirtualHubBgpConnectionCommand : HubBgpConnectionBaseCmdlet
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

        [Alias("ParentResourceName", "ParentVirtualHubName")]
        [Parameter(Mandatory = true,
            HelpMessage = "The virtual hub name.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            HelpMessage = "The virtual hub name.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [ResourceNameCompleter("Microsoft.Network/virtualHubs", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VirtualHubName { get; set; }

        [Alias("ResourceName", "BgpConnectionName")]
        [Parameter(Mandatory = true,
            HelpMessage = "The resource name.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            HelpMessage = "The resource name.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [Parameter(Mandatory = true,
            HelpMessage = "The resource name.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            HelpMessage = "The resource name.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [ResourceNameCompleter("Microsoft.Network/virtualHubs/bgpConnections", "ResourceGroupName", "VirtualHubName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The peer IP.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            HelpMessage = "The peer IP.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [Parameter(Mandatory = true,
            HelpMessage = "The peer IP.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            HelpMessage = "The peer IP.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [Parameter(Mandatory = true,
            HelpMessage = "The peer IP.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionResourceId + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            HelpMessage = "The peer IP.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionResourceId + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [Parameter(Mandatory = false,
            HelpMessage = "The peer IP.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = false,
            HelpMessage = "The peer IP.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [Parameter(Mandatory = false,
            HelpMessage = "The peer IP.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionObject)]
        [ValidateNotNullOrEmpty]
        public string PeerIp { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The peer ASN.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            HelpMessage = "The peer ASN.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [Parameter(Mandatory = true,
            HelpMessage = "The peer ASN.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            HelpMessage = "The peer ASN.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [Parameter(Mandatory = true,
            HelpMessage = "The peer ASN.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionResourceId + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            HelpMessage = "The peer ASN.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionResourceId + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [Parameter(Mandatory = false,
            HelpMessage = "The peer ASN.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = false,
            HelpMessage = "The peer ASN.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [Parameter(Mandatory = false,
            HelpMessage = "The peer ASN.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionObject)]
        public uint PeerAsn { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The VirtualHubVnetConnection resource.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            HelpMessage = "The VirtualHubVnetConnection resource.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            HelpMessage = "The VirtualHubVnetConnection resource.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionResourceId + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            HelpMessage = "The VirtualHubVnetConnection resource.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = false,
            HelpMessage = "The VirtualHubVnetConnection resource.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionObject)]
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
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionResourceId + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [Parameter(Mandatory = true,
            HelpMessage = "The VirtualHubVnetConnection resource id.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [Parameter(Mandatory = false,
            HelpMessage = "The VirtualHubVnetConnection resource id.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionObject)]
        [ValidateNotNullOrEmpty]
        public string VirtualHubVnetConnectionId { get; set; }

        [Alias("ParentObject", "ParentVirtualHub")]
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual hub resource.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual hub resource.",
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [ValidateNotNull]
        public PSVirtualHub VirtualHub { get; set; }

        [Alias("VirtualHubBgpConnection")]
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual hub bgp connection resource.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual hub bgp connection resource.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionObject + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual hub bgp connection resource.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionObject)]
        [ValidateNotNull]
        public PSBgpConnection InputObject { get; set; }

        [Alias("BgpConnectionId")]
        [Parameter(Mandatory = true,
            HelpMessage = "The resource id.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionResourceId + CortexParameterSetNames.ByHubVirtualNetworkConnectionObject)]
        [Parameter(Mandatory = true,
            HelpMessage = "The resource id.",
            ParameterSetName = CortexParameterSetNames.ByHubBgpConnectionResourceId + CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId)]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs/bgpConnections")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

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
            if (ParameterSetName.Contains(CortexParameterSetNames.ByHubBgpConnectionObject))
            {
                this.PopulateResourceInfoFromInputObject();
            }
            if (ParameterSetName.Contains(CortexParameterSetNames.ByHubBgpConnectionResourceId))
            {
                this.PopulateResourceInfoFromId(this.ResourceId);
            }

            var hubVnetConnection = GetHubVnetConnection();
            var bgpConnectionToUpdate = new MNM.BgpConnection
            {
                Name = this.Name,
                PeerAsn = this.PeerAsn,
                PeerIp = this.PeerIp,
                HubVirtualNetworkConnection = hubVnetConnection
            };

            this.ConfirmAction(
                Properties.Resources.SettingResourceMessage,
                this.Name,
                () =>
                {
                    this.WriteObject(this.CreateOrUpdateVirtualHubBgpConnection(this.ResourceGroupName, this.VirtualHubName, this.Name, bgpConnectionToUpdate));
                });
        }

        private void PopulateResourceInfoFromId(string id)
        {
            var parsedResourceId = new ResourceIdentifier(id);
            this.ResourceGroupName = parsedResourceId.ResourceGroupName;
            this.VirtualHubName = parsedResourceId.ParentResource.Split('/').Last();
            this.Name = parsedResourceId.ResourceName;
        }

        private void PopulateResourceInfoFromInputObject()
        {
            this.PopulateResourceInfoFromId(this.InputObject.Id);
            if (string.IsNullOrWhiteSpace(this.PeerIp))
            {
                this.PeerIp = this.InputObject.PeerIp;
            }

            if (this.PeerAsn == default)
            {
                this.PeerAsn = this.InputObject.PeerAsn;
            }
        }

        private MNM.SubResource GetHubVnetConnection()
        {
            MNM.SubResource hubVnetConnection = null;

            if (ParameterSetName.Contains(CortexParameterSetNames.ByHubVirtualNetworkConnectionObject))
            {
                hubVnetConnection = new MNM.SubResource(this.VirtualHubVnetConnection.Id);
            }
            else if (ParameterSetName.Contains(CortexParameterSetNames.ByHubVirtualNetworkConnectionResourceId))
            {
                hubVnetConnection = new MNM.SubResource(this.VirtualHubVnetConnectionId);
            }
            else if (ParameterSetName.Contains(CortexParameterSetNames.ByHubBgpConnectionObject))
            {
                hubVnetConnection = new MNM.SubResource(this.InputObject.HubVirtualNetworkConnection.Id);
            }

            return hubVnetConnection;
        }
    }
}
