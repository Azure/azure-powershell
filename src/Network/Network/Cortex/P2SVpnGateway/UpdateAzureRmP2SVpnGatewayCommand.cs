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
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "P2sVpnGateway",
        DefaultParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName + CortexParameterSetNames.NoVpnServerConfigurationUpdate,
        SupportsShouldProcess = true),
        OutputType(typeof(PSP2SVpnGateway))]
    public class UpdateAzureRmP2SVpnGatewayCommand : P2SVpnGatewayBaseCmdlet
    {
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName + CortexParameterSetNames.NoVpnServerConfigurationUpdate,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName + CortexParameterSetNames.ByVpnServerConfigurationObject,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "P2SVpnGatewayName", "GatewayName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName + CortexParameterSetNames.NoVpnServerConfigurationUpdate,
            Mandatory = true,
            HelpMessage = "The P2S vpn gateway name.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName + CortexParameterSetNames.ByVpnServerConfigurationObject,
            Mandatory = true,
            HelpMessage = "The P2S vpn gateway name.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            Mandatory = true,
            HelpMessage = "The P2S vpn gateway name.")]
        [ResourceNameCompleter("Microsoft.Network/p2sVpnGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("P2SVpnGateway")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayObject + CortexParameterSetNames.NoVpnServerConfigurationUpdate,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The p2s vpn gateway object to be modified")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayObject + CortexParameterSetNames.ByVpnServerConfigurationObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The p2s vpn gateway object to be modified")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayObject + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The p2s vpn gateway object to be modified")]
        [ValidateNotNullOrEmpty]
        public PSP2SVpnGateway InputObject { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayResourceId + CortexParameterSetNames.NoVpnServerConfigurationUpdate,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID of the P2SVpnGateway to be modified.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayResourceId + CortexParameterSetNames.ByVpnServerConfigurationObject,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID of the P2SVpnGateway to be modified.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayResourceId + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID of the P2SVpnGateway to be modified.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "P2S VpnClient AddressPool for this P2SVpnGateway P2SConnectionConfiguration.")]
        [ValidateNotNullOrEmpty]
        public string[] VpnClientAddressPool { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of P2SConnectionConfigurations that this P2SVpnGateway needs to have.")]
        public PSP2SConnectionConfiguration[] P2SConnectionConfiguration { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName + CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "The VpnServerConfiguration to be attached to this P2SVpnGateway.")]
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayObject + CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "The VpnServerConfiguration to be attached to this P2SVpnGateway.")]
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayResourceId + CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "The VpnServerConfiguration to be attached to this P2SVpnGateway.")]
        public PSVpnServerConfiguration VpnServerConfiguration { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "The id of Vpn server configuration object this P2SVpnGateway will be attached to.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayObject + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "The id of Vpn server configuration object this P2SVpnGateway will be attached to.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayResourceId + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "The id of Vpn server configuration object this P2SVpnGateway will be attached to.")]
        [ResourceIdCompleter("Microsoft.Network/vpnServerConfigurations")]
        public string VpnServerConfigurationId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The scale unit for this P2SVpnGateway.")]
        public uint VpnGatewayScaleUnit { get; set; }

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
            HelpMessage = "Flag to disable internet security feature on this P2SVpnGateway P2SConnectionConfiguration.")]
        public SwitchParameter DisableInternetSecurityFlag { get; set; }

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
            PSP2SVpnGateway existingP2SVpnGateway = null;
            if (ParameterSetName.Contains(CortexParameterSetNames.ByP2SVpnGatewayObject))
            {
                existingP2SVpnGateway = this.InputObject;
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }
            else
            {
                if (ParameterSetName.Contains(CortexParameterSetNames.ByP2SVpnGatewayResourceId))
                {
                    var parsedResourceId = new ResourceIdentifier(ResourceId);
                    Name = parsedResourceId.ResourceName;
                    ResourceGroupName = parsedResourceId.ResourceGroupName;
                }

                existingP2SVpnGateway = this.GetP2SVpnGateway(this.ResourceGroupName, this.Name);
            }

            if (existingP2SVpnGateway == null)
            {
                throw new PSArgumentException(Properties.Resources.P2SVpnGatewayNotFound);
            }

            //// Modify scale unit if specified
            if (this.VpnGatewayScaleUnit > 0)
            {
                existingP2SVpnGateway.VpnGatewayScaleUnit = Convert.ToInt32(this.VpnGatewayScaleUnit);
            }

            // Modify the P2SConnectionConfigurations
            if (this.P2SConnectionConfiguration != null)
            {
                existingP2SVpnGateway.P2SConnectionConfigurations = new List<PSP2SConnectionConfiguration>();
                existingP2SVpnGateway.P2SConnectionConfigurations.AddRange(this.P2SConnectionConfiguration);
            }
            else
            {
                if (existingP2SVpnGateway.P2SConnectionConfigurations == null || !existingP2SVpnGateway.P2SConnectionConfigurations.Any())
                {
                    PSP2SConnectionConfiguration p2sConnectionConfig = new PSP2SConnectionConfiguration()
                    {
                        Name = P2SConnectionConfigurationName,
                        VpnClientAddressPool = new PSAddressSpace()
                        {
                            AddressPrefixes = new List<string>()
                        }
                    };

                    existingP2SVpnGateway.P2SConnectionConfigurations = new List<PSP2SConnectionConfiguration>()
                    {
                        p2sConnectionConfig
                    };
                }

                if (this.VpnClientAddressPool != null)
                {
                    existingP2SVpnGateway.P2SConnectionConfigurations[0].VpnClientAddressPool.AddressPrefixes.Clear();
                    existingP2SVpnGateway.P2SConnectionConfigurations[0].VpnClientAddressPool.AddressPrefixes = new List<string>(this.VpnClientAddressPool);
                }
            }

            if (this.EnableInternetSecurityFlag.IsPresent && this.DisableInternetSecurityFlag.IsPresent)
            {
                throw new ArgumentException("Both EnableInternetSecurityFlag and DisableInternetSecurityFlag Parameters can not be passed.");
            }

            if (this.EnableInternetSecurityFlag.IsPresent)
            {
                existingP2SVpnGateway.P2SConnectionConfigurations.ForEach(config => config.EnableInternetSecurity = true);
            }

            if (this.DisableInternetSecurityFlag.IsPresent)
            {
                existingP2SVpnGateway.P2SConnectionConfigurations.ForEach(config => config.EnableInternetSecurity = false);
            }

            if (this.RoutingConfiguration != null)
            {
                if (this.RoutingConfiguration.VnetRoutes != null && this.RoutingConfiguration.VnetRoutes.StaticRoutes!= null && this.RoutingConfiguration.VnetRoutes.StaticRoutes.Any())
                {
                    throw new PSArgumentException(Properties.Resources.StaticRoutesNotSupportedForThisRoutingConfiguration);
                }

                existingP2SVpnGateway.P2SConnectionConfigurations.ForEach(config => config.RoutingConfiguration = RoutingConfiguration);
            }

            // Set the custom dns servers, if it is specified by customer.
            if (CustomDnsServer != null && this.CustomDnsServer.Any())
            {
                existingP2SVpnGateway.CustomDnsServers = CustomDnsServer?.ToList();
            }
            else
            {
                existingP2SVpnGateway.CustomDnsServers = null;
            }

            //// Resolve the VpnServerConfiguration, if specified
            string vpnServerConfigurationResourceGroupName = string.Empty;
            string vpnServerConfigurationName = string.Empty;
            if (!ParameterSetName.Contains(CortexParameterSetNames.NoVpnServerConfigurationUpdate))
            {
                if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnServerConfigurationObject))
                {
                    vpnServerConfigurationResourceGroupName = this.VpnServerConfiguration.ResourceGroupName;
                    vpnServerConfigurationName = this.VpnServerConfiguration.Name;
                }
                else if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnServerConfigurationResourceId))
                {
                    var parsedVpnServerConfigurationResourceId = new ResourceIdentifier(this.VpnServerConfigurationId);
                    vpnServerConfigurationResourceGroupName = parsedVpnServerConfigurationResourceId.ResourceGroupName;
                    vpnServerConfigurationName = parsedVpnServerConfigurationResourceId.ResourceName;
                }

                if (!string.IsNullOrWhiteSpace(vpnServerConfigurationResourceGroupName) && !string.IsNullOrWhiteSpace(vpnServerConfigurationName))
                {
                    PSVpnServerConfiguration resolvedVpnServerConfiguration = new VpnServerConfigurationBaseCmdlet().GetVpnServerConfiguration(vpnServerConfigurationResourceGroupName, vpnServerConfigurationName);

                    if (resolvedVpnServerConfiguration == null)
                    {
                        throw new PSArgumentException(Properties.Resources.VpnServerConfigurationNotFound);
                    }

                    existingP2SVpnGateway.VpnServerConfiguration = new PSResourceId() { Id = resolvedVpnServerConfiguration.Id };
                }
            }

            ConfirmAction(
                Properties.Resources.SettingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.UpdatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    WriteObject(this.CreateOrUpdateP2SVpnGateway(this.ResourceGroupName, this.Name, existingP2SVpnGateway, this.Tag));
                });
        }
    }
}
