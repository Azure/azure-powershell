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

    [Cmdlet("Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnGateway",
        DefaultParameterSetName = CortexParameterSetNames.ByVpnGatewayName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnGateway))]
    public class UpdateAzureRmVpnGatewayCommand : VpnGatewayBaseCmdlet
    {

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayName,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "VpnGatewayName", "GatewayName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayName,
            Mandatory = true,
            HelpMessage = "The vpn gateway name.")]
        [ResourceNameCompleter("Microsoft.Network/vpnGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

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
            HelpMessage = "The list of VpnConnections that this VpnGateway needs to have.")]
        public PSVpnConnection[] VpnConnection { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of VpnGatewayNatRules that are associated with this VpnGateway.")]
        public PSVpnGatewayNatRule[] VpnGatewayNatRule { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The scale unit for this VpnGateway.")]
        public uint VpnGatewayScaleUnit { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The BGP peering addresses for this VpnGateway bgpsettings.")]
        public PSIpConfigurationBgpPeeringAddress[] BgpPeeringAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            PSVpnGateway existingVpnGateway = null;
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnGatewayObject))
            {
                existingVpnGateway = this.InputObject;
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }
            else 
            {
                if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnGatewayResourceId))
                {
                    var parsedResourceId = new ResourceIdentifier(ResourceId);
                    Name = parsedResourceId.ResourceName;
                    ResourceGroupName = parsedResourceId.ResourceGroupName;
                }

                existingVpnGateway = this.GetVpnGateway(this.ResourceGroupName, this.Name);
            }

            if (existingVpnGateway == null)
            {
                throw new PSArgumentException(Properties.Resources.VpnGatewayNotFound);
            }

            //// Modify scale unit if specified
            if (this.VpnGatewayScaleUnit > 0)
            {
                existingVpnGateway.VpnGatewayScaleUnit = Convert.ToInt32(this.VpnGatewayScaleUnit);
            }

            //// Modify the connections
            if (this.VpnConnection != null)
            {
                existingVpnGateway.Connections = new List<PSVpnConnection>();
                existingVpnGateway.Connections.AddRange(this.VpnConnection);
            }

            //// Modify the natRules
            existingVpnGateway.NatRules = new List<PSVpnGatewayNatRule>();
            if (this.VpnGatewayNatRule != null && this.VpnGatewayNatRule.Any())
            {
                existingVpnGateway.NatRules.AddRange(this.VpnGatewayNatRule);
            }

            //// Modify BgpPeeringAddress
            if (this.BgpPeeringAddress != null)
            {
                if (existingVpnGateway.BgpSettings == null)
                {
                    existingVpnGateway.BgpSettings = new PSBgpSettings();
                }

                if (existingVpnGateway.BgpSettings.BgpPeeringAddresses == null)
                {
                    existingVpnGateway.BgpSettings.BgpPeeringAddresses = new List<PSIpConfigurationBgpPeeringAddress>();

                    foreach (var address in this.BgpPeeringAddress)
                    {
                        existingVpnGateway.BgpSettings.BgpPeeringAddresses.Add(address);
                    }
                }
                else
                {
                    foreach (var address in this.BgpPeeringAddress)
                    {
                        bool isGatewayIpConfigurationExists = existingVpnGateway.BgpSettings.BgpPeeringAddresses.Any(
                        ipconfaddress => ipconfaddress.IpconfigurationId.Equals(address.IpconfigurationId, StringComparison.OrdinalIgnoreCase));

                        if (isGatewayIpConfigurationExists)
                        {
                            var bgpPeeringPropertiesInRequest = existingVpnGateway.BgpSettings.BgpPeeringAddresses.FirstOrDefault(
                                x => x.IpconfigurationId.Equals(address.IpconfigurationId, StringComparison.OrdinalIgnoreCase));

                            bgpPeeringPropertiesInRequest.CustomBgpIpAddresses = address.CustomBgpIpAddresses;
                        }
                        else
                        {
                            existingVpnGateway.BgpSettings.BgpPeeringAddresses.Add(address);
                        }
                    }
                }
            }

            ConfirmAction(
                    Properties.Resources.SettingResourceMessage,
                    this.Name,
                    () =>
                    {
                        WriteVerbose(String.Format(Properties.Resources.UpdatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                        WriteObject(this.CreateOrUpdateVpnGateway(this.ResourceGroupName, this.Name, existingVpnGateway, this.Tag));
                    });
        }
    }
}
