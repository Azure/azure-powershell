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
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "P2sVpnGateway",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByVpnServerConfigurationObject,
        SupportsShouldProcess = true),
        OutputType(typeof(PSP2SVpnGateway))]
    public class NewAzureRmP2SVpnGatewayCommand : P2SVpnGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "P2SVpnGatewayName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The scale unit for this P2SVpnGateway.")]
        public uint VpnGatewayScaleUnit { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "The name of the VirtualHub this P2SVpnGateway needs to be associated with.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "The name of the VirtualHub this P2SVpnGateway needs to be associated with.")]
        public string VirtualHubName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "The VirtualHub this P2SVpnGateway needs to be associated with.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "The VirtualHub this P2SVpnGateway needs to be associated with.")]
        public PSVirtualHub VirtualHub { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId + CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "The Id of the VirtualHub this P2SVpnGateway needs to be associated with.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "The Id of the VirtualHub this P2SVpnGateway needs to be associated with.")]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs")]
        public string VirtualHubId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "The VpnServerConfiguration to be attached to this P2SVpnGateway.")]
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "The VpnServerConfiguration to be attached to this P2SVpnGateway.")]
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId + CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "The VpnServerConfiguration to be attached to this P2SVpnGateway.")]
        public PSVpnServerConfiguration VpnServerConfiguration { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "The id of Vpn server configuration object this P2SVpnGateway will be attached to.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "The id of Vpn server configuration object this P2SVpnGateway will be attached to.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "The id of Vpn server configuration object this P2SVpnGateway will be attached to.")]
        [ResourceIdCompleter("Microsoft.Network/vpnServerConfigurations")]
        public string VpnServerConfigurationId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "P2S VpnClient AddressPool for this P2SVpnGateway P2SConnectionConfiguration.")]
        [ValidateNotNullOrEmpty]
        public string[] VpnClientAddressPool { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of Custom Dns Servers.")]
        public string[] CustomDnsServer { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "The routing configuration for this P2SVpnGateway P2SConnectionConfiguration")]
        public PSRoutingConfiguration RoutingConfiguration { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to enable internet security feature on this P2SVpnGateway P2SConnectionConfiguration.")]
        public SwitchParameter EnableInternetSecurityFlag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to enable Routing Preference Internet on this P2SVpnGateway.")]
        public SwitchParameter EnableRoutingPreferenceInternetFlag { get; set; }

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

            if (this.IsP2SVpnGatewayPresent(this.ResourceGroupName, this.Name))
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ResourceAlreadyPresentInResourceGroup, this.Name, this.ResourceGroupName));
            }

            var p2sVpnGateway = new PSP2SVpnGateway();
            p2sVpnGateway.Name = this.Name;
            p2sVpnGateway.ResourceGroupName = this.ResourceGroupName;
            p2sVpnGateway.VirtualHub = null;
            p2sVpnGateway.VpnServerConfiguration = null;
            string virtualHubResourceGroupName = this.ResourceGroupName; // default to common RG for ByVirtualHubName parameter set

            //// Resolve and Set the virtual hub
            if (ParameterSetName.Contains(CortexParameterSetNames.ByVirtualHubObject))
            {
                this.VirtualHubName = this.VirtualHub.Name;
                virtualHubResourceGroupName = this.VirtualHub.ResourceGroupName;
            }
            else if (ParameterSetName.Contains(CortexParameterSetNames.ByVirtualHubResourceId))
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

            p2sVpnGateway.Location = resolvedVirtualHub.Location;
            p2sVpnGateway.VirtualHub = new PSResourceId() { Id = resolvedVirtualHub.Id };

            //// Set P2SConnectionConfigurations. Currently, only one P2SConnectionConfiguration is allowed.
            PSP2SConnectionConfiguration p2sConnectionConfig = new PSP2SConnectionConfiguration()
            {
                Name = P2SConnectionConfigurationName,
                VpnClientAddressPool = new PSAddressSpace()
                {
                    AddressPrefixes = new List<string>(this.VpnClientAddressPool)
                },
                EnableInternetSecurity = this.EnableInternetSecurityFlag.IsPresent
            };

            if (this.RoutingConfiguration != null)
            {
                if (this.RoutingConfiguration.VnetRoutes != null && this.RoutingConfiguration.VnetRoutes.StaticRoutes != null && this.RoutingConfiguration.VnetRoutes.StaticRoutes.Any())
                {
                    throw new PSArgumentException(Properties.Resources.StaticRoutesNotSupportedForThisRoutingConfiguration);
                }

                p2sConnectionConfig.RoutingConfiguration = RoutingConfiguration;
            }

            p2sVpnGateway.P2SConnectionConfigurations = new List<PSP2SConnectionConfiguration>()
            {
                p2sConnectionConfig
            };

            //// Scale unit, if specified
            p2sVpnGateway.VpnGatewayScaleUnit = 0;
            if (this.VpnGatewayScaleUnit > 0)
            {
                p2sVpnGateway.VpnGatewayScaleUnit = Convert.ToInt32(this.VpnGatewayScaleUnit);
            }

            //// Resolve the VpnServerConfiguration reference
            //// And set it in the P2SVpnGateway object.
            string vpnServerConfigurationResolvedId = null;
            if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnServerConfigurationObject))
            {
                vpnServerConfigurationResolvedId = this.VpnServerConfiguration.Id;
            }
            else if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnServerConfigurationResourceId))
            {
                vpnServerConfigurationResolvedId = this.VpnServerConfigurationId;
            }

            if (string.IsNullOrWhiteSpace(vpnServerConfigurationResolvedId))
            {
                throw new PSArgumentException(Properties.Resources.VpnServerConfigurationRequiredForP2SVpnGateway);
            }

            //// Let's not resolve the vpnServerConfiguration here. If this does not exist, NRP/GWM will fail the call.
            p2sVpnGateway.VpnServerConfiguration = new PSResourceId() { Id = vpnServerConfigurationResolvedId };
            p2sVpnGateway.VpnServerConfigurationLocation = string.IsNullOrWhiteSpace(this.VpnServerConfiguration.Location) ? string.Empty : this.VpnServerConfiguration.Location;

            // Set the custom dns servers, if it is specified by customer.
            if (CustomDnsServer != null && this.CustomDnsServer.Any())
            {
                p2sVpnGateway.CustomDnsServers = CustomDnsServer?.ToList();
            }

            // Set the Routing Preference Internet, if it is specified by customer.
            p2sVpnGateway.IsRoutingPreferenceInternet = EnableRoutingPreferenceInternetFlag.IsPresent;

            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    WriteObject(this.CreateOrUpdateP2SVpnGateway(this.ResourceGroupName, this.Name, p2sVpnGateway, this.Tag));
                });
        }
    }
}
