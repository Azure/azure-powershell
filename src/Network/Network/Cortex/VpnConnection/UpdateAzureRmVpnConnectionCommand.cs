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

namespace Microsoft.Azure.Commands.Network.Cortex.VpnGateway
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

    [Cmdlet("Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnConnection",
        DefaultParameterSetName = CortexParameterSetNames.ByVpnConnectionName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnConnection))]
    public class UpdateAzureRmVpnConnectionCommand : VpnConnectionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnConnectionName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ParentVpnGatewayName", "VpnGatewayName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnConnectionName,
            HelpMessage = "The parent resource name.")]
        [ResourceNameCompleter("Microsoft.Network/vpnGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceName { get; set; }

        [Alias("ResourceName", "VpnConnectionName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnConnectionName,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/vpnGateways/vpnConnections", "ResourceGroupName", "ParentResourceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("VpnConnectionId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVpnConnectionResourceId,
            HelpMessage = "The resource id of the VpnConnection object to delete.")]
        public string ResourceId { get; set; }

        [Alias("VpnConnection")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVpnConnectionObject,
            HelpMessage = "The VpnConnection object to update.")]
        public PSVpnConnection InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The shared key required to set this connection up.")]
        [ValidateNotNullOrEmpty]
        public SecureString SharedKey { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The bandwidth that needs to be handled by this connection in mbps.")]
        public uint ConnectionBandwidthInMbps { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The bandwidth that needs to be handled by this connection in mbps.")]
        public PSIpsecPolicy IpSecPolicy { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable BGP for this connection")]
        public bool? EnableBgp { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Use local azure ip address as source ip for this connection.")]
        public bool? UseLocalAzureIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Use policy based traffic selectors for this connection.")]
        public bool? UsePolicyBasedTrafficSelectors { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of VpnSiteLinkConnections that this VpnConnection needs to have.")]
        public PSVpnSiteLinkConnection[] VpnSiteLinkConnection { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable internet security for this connection")]
        public bool? EnableInternetSecurity { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "The routing configuration for this vpn connection")]
        public PSRoutingConfiguration RoutingConfiguration { get; set; }

        [Parameter(
        Mandatory = false,
        HelpMessage = "The connection mode for the link connections.")]
        [PSArgumentCompleter("Default", "ResponderOnly", "InitiatorOnly")]
        public string VpnLinkConnectionMode { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "A list of traffic selector policies.")]
        public PSTrafficSelectorPolicy[] TrafficSelectorPolicy { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnConnectionName, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceGroupName = this.ResourceGroupName;
                this.ParentResourceName = this.ParentResourceName;
                this.Name = this.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnConnectionObject, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceId = this.InputObject.Id;

                if (string.IsNullOrWhiteSpace(this.ResourceId))
                {
                    throw new PSArgumentException(Properties.Resources.VpnConnectionNotFound);
                }

                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentResourceName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                this.Name = parsedResourceId.ResourceName;
            }

            //// Get the vpngateway object - this will throw not found if the object is not found
            PSVpnGateway parentGateway = this.GetVpnGateway(this.ResourceGroupName, this.ParentResourceName);

            if (parentGateway == null || 
                parentGateway.Connections == null ||
                !parentGateway.Connections.Any(connection => connection.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new PSArgumentException(Properties.Resources.VpnConnectionNotFound);
            }

            var vpnConnectionToModify = parentGateway.Connections.FirstOrDefault(connection => connection.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase));
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnConnectionObject, StringComparison.OrdinalIgnoreCase))
            {
                vpnConnectionToModify = this.InputObject;
            }

            if (vpnConnectionToModify.VpnLinkConnections != null && vpnConnectionToModify.VpnLinkConnections.Any())
            {
                //// Use only link connection properties instead of vpn connection properties.
                if (this.SharedKey != null || this.ConnectionBandwidthInMbps > 0 || this.EnableBgp.HasValue || this.UseLocalAzureIpAddress.HasValue || this.UsePolicyBasedTrafficSelectors.HasValue || this.IpSecPolicy != null)
                {
                    throw new PSArgumentException(Properties.Resources.VpnConnectionPropertyIsDeprecated);
                }
            }

            if (this.SharedKey != null)
            {
                vpnConnectionToModify.SharedKey = SecureStringExtensions.ConvertToString(this.SharedKey);
            }

            if (this.ConnectionBandwidthInMbps > 0)
            {
                vpnConnectionToModify.ConnectionBandwidth = Convert.ToInt32(this.ConnectionBandwidthInMbps);
            }

            if (this.EnableBgp.HasValue)
            {
                vpnConnectionToModify.EnableBgp = this.EnableBgp.Value;
            }

            if (this.UseLocalAzureIpAddress.HasValue)
            {
                vpnConnectionToModify.UseLocalAzureIpAddress = this.UseLocalAzureIpAddress.Value;
            }

            if (this.UsePolicyBasedTrafficSelectors.HasValue)
            {
                vpnConnectionToModify.UsePolicyBasedTrafficSelectors = this.UsePolicyBasedTrafficSelectors.Value;
            }

            if (this.IpSecPolicy != null)
            {
                vpnConnectionToModify.IpsecPolicies = new List<PSIpsecPolicy> { this.IpSecPolicy };
            }

            //// Modify the linkconnections
            if (this.VpnSiteLinkConnection != null)
            {
                vpnConnectionToModify.VpnLinkConnections = new List<PSVpnSiteLinkConnection>();
                vpnConnectionToModify.VpnLinkConnections.AddRange(this.VpnSiteLinkConnection);
            }

            if (this.EnableInternetSecurity.HasValue)
            {
                vpnConnectionToModify.EnableInternetSecurity = this.EnableInternetSecurity.Value;
            }

            if (this.RoutingConfiguration != null)
            {
                if (this.RoutingConfiguration.VnetRoutes != null && this.RoutingConfiguration.VnetRoutes.StaticRoutes != null && this.RoutingConfiguration.VnetRoutes.StaticRoutes.Any())
                {
                    throw new PSArgumentException(Properties.Resources.StaticRoutesNotSupportedForThisRoutingConfiguration);
                }

                vpnConnectionToModify.RoutingConfiguration = this.RoutingConfiguration;
            }

            if(!String.IsNullOrEmpty(this.VpnLinkConnectionMode))
            {
                foreach(var vpnSiteLinkConnection in vpnConnectionToModify.VpnLinkConnections)
                {
                    vpnSiteLinkConnection.VpnLinkConnectionMode = this.VpnLinkConnectionMode;
                }
            }

            if (this.TrafficSelectorPolicy != null)
            {
                vpnConnectionToModify.TrafficSelectorPolicies = this.TrafficSelectorPolicy?.ToList();
            }

            ConfirmAction(
                    Properties.Resources.SettingResourceMessage,
                    this.Name,
                    () =>
                    {
                        WriteVerbose(String.Format(Properties.Resources.UpdatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                        this.CreateOrUpdateVpnGateway(this.ResourceGroupName, this.ParentResourceName, parentGateway, parentGateway.Tag);

                        var createdOrUpdatedVpnGateway = this.GetVpnGateway(this.ResourceGroupName, this.ParentResourceName);
                        WriteObject(createdOrUpdatedVpnGateway.Connections.Where(connection => connection.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault());
                    });
        }
    }
}
