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
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using System.Linq;

    [Cmdlet(VerbsCommon.Set,
        "AzureRmVpnGateway",
        DefaultParameterSetName = CortexParameterSetNames.ByVpnGatewayName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnGateway))]
    public class SetAzureRmVpnGatewayCommand : VpnGatewayBaseCmdlet
    {
        [Alias("ResourceName", "VpnGatewayName", "GatewayName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual wan name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("VpnGateway")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The vpn gateway object to be modified")]
        [ValidateNotNullOrEmpty]
        public PSVpnGateway InputObject { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID of the VpnGateway to be modified.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of VpnConnections that this VpnGateway needs to have.")]
        public List<PSVpnConnection> VpnConnection { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The scale unit for this VpnGateway.")]
        public uint VpnGatewayScaleUnit { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The BgpPeering weight for this VpnGateway.")]
        public uint BgpPeerWeight { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
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
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnGatewayObject))
            {
                Name = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnGatewayResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                Name = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
            }

            //// Let's get the existing VpnGateway - this will throw not found if the VpnGateway does not exist
            var existingVpnGateway = this.GetVpnGateway(this.ResourceGroupName, this.Name);

            if (existingVpnGateway == null)
            {
                throw new PSArgumentException("The VpnGateway to modify could not be found");
            }

            //// Modify scale unit if specified
            if (this.VpnGatewayScaleUnit > 0)
            {
                existingVpnGateway.VpnGatewayScaleUnit = Convert.ToInt32(this.VpnGatewayScaleUnit);
            }

            //// Modify the connections
            existingVpnGateway.Connections = this.VpnConnection;

            //// Modify the peering weight if specified
            if (this.BgpPeerWeight > 0)
            {
                if (existingVpnGateway.BgpSettings == null)
                {
                    existingVpnGateway.BgpSettings = new PSBgpSettings()
                    {
                        Asn = 65515,
                        BgpPeeringAddress = null
                    };
                }

                existingVpnGateway.BgpSettings.PeerWeight = Convert.ToInt32(this.BgpPeerWeight);
            }

            ConfirmAction(
                    this.Force.IsPresent,
                    string.Format(Properties.Resources.SettingResourceMessage, this.Name),
                    Properties.Resources.SettingResourceMessage,
                    this.Name,
                    () =>
                    {
                        WriteObject(this.CreateOrUpdateVpnGateway(this.ResourceGroupName, this.Name, existingVpnGateway, this.Tag));
                    });
        }
    }
}
