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

namespace Microsoft.Azure.Commands.Network
{
    using AutoMapper;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using Microsoft.WindowsAzure.Commands.Common;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using System.Linq;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.New,
        "AzureRmVpnGateway",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualHubName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnGateway))]
    public class NewAzureRmVpnGatewayCommand : VpnGatewayBaseCmdlet
    {
        [Alias("ResourceName", "VpnGatewayName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The scale unit for this VpnGateway.")]
        public uint VpnGatewayScaleUnit { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
            HelpMessage = "The VirtualHub this VpnGateway needs to be associated with.")]
        public PSVirtualHub VirtualHub { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId,
            HelpMessage = "The Id of the VirtualHub this VpnGateway needs to be associated with.")]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs")]
        public string VirtualHubId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName,
            HelpMessage = "The Id of the VirtualHub this VpnGateway needs to be associated with.")]
        public string VirtualHubName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The BgpPeering weight for this VpnGateway.")]
        public uint BgpPeerWeight { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of VpnConnections that this VpnGateway needs to have.")]
        public List<PSVpnConnection> VpnConnection { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");

            var vpnGateway = new PSVpnGateway();
            vpnGateway.Name = this.Name;
            vpnGateway.ResourceGroupName = this.ResourceGroupName;
            vpnGateway.VirtualHub = null;

            //// Resolve and Set the virtual hub
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubObject, StringComparison.OrdinalIgnoreCase))
            {
                this.VirtualHubName = this.VirtualHub.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.VirtualHubId);
                this.VirtualHubName = parsedResourceId.ResourceName;
            }
            
            //// At this point, we should have the virtual hub name resolved. Fail this operation if it is not.
            if (string.IsNullOrWhiteSpace(this.VirtualHubName))
            {
                throw new PSArgumentException("A valid VirtualHub reference is required to create a VpnGateway");
            }

            var resolvedVirtualHub = new VirtualHubBaseCmdlet().GetVirtualHub(this.ResourceGroupName, this.VirtualHubName);
            vpnGateway.Location = resolvedVirtualHub.Location;
            vpnGateway.VirtualHub = new PSResourceId() { Id = resolvedVirtualHub.Id };

            //// VpnConnections, if specified
            vpnGateway.Connections = new List<PSVpnConnection>();
            if (this.VpnConnection != null && this.VpnConnection.Any())
            {
                vpnGateway.Connections.AddRange(this.VpnConnection);
            }

            //// Scale unit, if specified
            vpnGateway.VpnGatewayScaleUnit = 0;
            if (this.VpnGatewayScaleUnit > 0)
            {
                vpnGateway.VpnGatewayScaleUnit = Convert.ToInt32(this.VpnGatewayScaleUnit);
            }

            //// BgpSettings, if specified
            vpnGateway.BgpSettings = null;
            if (this.BgpPeerWeight > 0)
            {
                vpnGateway.BgpSettings = new PSBgpSettings()
                {
                    BgpPeeringAddress = null,
                    Asn = 65515,
                    PeerWeight = Convert.ToInt32(this.BgpPeerWeight)
                };
            }

            bool shouldProcess = this.Force.IsPresent;

            if (!shouldProcess)
            {
                shouldProcess = ShouldProcess(this.Name, Properties.Resources.CreatingResourceMessage);
            }

            if (shouldProcess)
            {
                WriteObject(this.CreateOrUpdateVpnGateway(this.ResourceGroupName, this.Name, vpnGateway, this.Tag));
            }
        }
    }
}
