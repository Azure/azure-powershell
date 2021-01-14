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
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnGateway",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualHubName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnGateway))]
    public class NewAzureRmVpnGatewayCommand : VpnGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "VpnGatewayName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The scale unit for this VpnGateway.")]
        public uint VpnGatewayScaleUnit { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
            HelpMessage = "The VirtualHub this VpnGateway needs to be associated with.")]
        public PSVirtualHub VirtualHub { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId,
            HelpMessage = "The Id of the VirtualHub this VpnGateway needs to be associated with.")]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs")]
        public string VirtualHubId { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName,
            HelpMessage = "The Id of the VirtualHub this VpnGateway needs to be associated with.")]
        public string VirtualHubName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of VpnConnections that this VpnGateway needs to have.")]
        public PSVpnConnection[] VpnConnection { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Flag to enable Routing Preference Internet on this VpnGateway.")]
        public SwitchParameter EnableRoutingPreferenceInternetFlag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of VpnGatewayNatRules that are associated with this VpnGateway.")]
        public PSVpnGatewayNatRule[] VpnGatewayNatRule { get; set; }

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
            base.Execute();

            if (this.IsVpnGatewayPresent(this.ResourceGroupName, this.Name))
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ResourceAlreadyPresentInResourceGroup, this.Name, this.ResourceGroupName));
            }

            var vpnGateway = new PSVpnGateway();
            vpnGateway.Name = this.Name;
            vpnGateway.ResourceGroupName = this.ResourceGroupName;
            vpnGateway.VirtualHub = null;
            string virtualHubResourceGroupName = this.ResourceGroupName; // default to common RG for ByVirtualHubName parameter set

            //// Resolve and Set the virtual hub
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubObject, StringComparison.OrdinalIgnoreCase))
            {
                this.VirtualHubName = this.VirtualHub.Name;
                virtualHubResourceGroupName = this.VirtualHub.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.VirtualHubId);
                this.VirtualHubName = parsedResourceId.ResourceName;
                virtualHubResourceGroupName = parsedResourceId.ResourceGroupName;
            }
            
            //// At this point, we should have the virtual hub name resolved. Fail this operation if it is not.
            if (string.IsNullOrWhiteSpace(this.VirtualHubName))
            {
                throw new PSArgumentException(Properties.Resources.VirtualHubRequiredForVpnGateway);
            }

            var resolvedVirtualHub = new VirtualHubBaseCmdlet().GetVirtualHub(virtualHubResourceGroupName, this.VirtualHubName);
            if (resolvedVirtualHub == null)
            {
                throw new PSArgumentException(Properties.Resources.VirtualHubRequiredForExpressRouteGateway);
            }

            vpnGateway.Location = resolvedVirtualHub.Location;
            vpnGateway.VirtualHub = new PSResourceId() { Id = resolvedVirtualHub.Id };

            //// VpnConnections, if specified
            vpnGateway.Connections = new List<PSVpnConnection>();
            if (this.VpnConnection != null && this.VpnConnection.Any())
            {
                vpnGateway.Connections.AddRange(this.VpnConnection);
            }

            //// VpnGatewayNatRules, if specified
            vpnGateway.NatRules = new List<PSVpnGatewayNatRule>();
            if (this.VpnGatewayNatRule != null && this.VpnGatewayNatRule.Any())
            {
                vpnGateway.NatRules.AddRange(this.VpnGatewayNatRule);
            }

            //// Scale unit, if specified
            vpnGateway.VpnGatewayScaleUnit = 0;
            if (this.VpnGatewayScaleUnit > 0)
            {
                vpnGateway.VpnGatewayScaleUnit = Convert.ToInt32(this.VpnGatewayScaleUnit);
            }

            // Set the Routing Preference Internet, if it is specified by customer.
            vpnGateway.IsRoutingPreferenceInternet = EnableRoutingPreferenceInternetFlag.IsPresent;

            vpnGateway.BgpSettings = null;

            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    WriteObject(this.CreateOrUpdateVpnGateway(this.ResourceGroupName, this.Name, vpnGateway, this.Tag));
                });
        }
    }
}
