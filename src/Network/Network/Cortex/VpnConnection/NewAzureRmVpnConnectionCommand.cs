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
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnConnection",
        DefaultParameterSetName = CortexParameterSetNames.ByVpnGatewayName + CortexParameterSetNames.ByVpnSiteObject,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnConnection))]
    public class NewAzureRmVpnConnectionCommand : VpnConnectionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayName + CortexParameterSetNames.ByVpnSiteObject,
            HelpMessage = "The resource group name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayName + CortexParameterSetNames.ByVpnSiteResourceId,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ParentVpnGatewayName", "VpnGatewayName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayName + CortexParameterSetNames.ByVpnSiteObject,
            HelpMessage = "The resource group name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayName + CortexParameterSetNames.ByVpnSiteResourceId,
            HelpMessage = "The resource group name.")]
        [ResourceNameCompleter("Microsoft.Network/vpnGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceName { get; set; }

        [Alias("ParentVpnGateway", "VpnGateway")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayObject + CortexParameterSetNames.ByVpnSiteObject,
            HelpMessage = "The parent VpnGateway for this connection.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayObject + CortexParameterSetNames.ByVpnSiteResourceId,
            HelpMessage = "The parent VpnGateway for this connection.")]
        [ValidateNotNullOrEmpty]
        public PSVpnGateway ParentObject { get; set; }

        [Alias("ParentVpnGatewayId", "VpnGatewayId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayResourceId + CortexParameterSetNames.ByVpnSiteObject,
            HelpMessage = "The resource id of the parent VpnGateway for this connection.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayResourceId + CortexParameterSetNames.ByVpnSiteResourceId,
            HelpMessage = "The resource id of the parent VpnGateway for this connection.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/vpnGateways")]
        public string ParentResourceId { get; set; }

        [Alias("ResourceName", "VpnConnectionName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayResourceId + CortexParameterSetNames.ByVpnSiteObject,
            HelpMessage = "The remote vpn site to which this hub virtual network connection is connected.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayName + CortexParameterSetNames.ByVpnSiteObject,
            HelpMessage = "The remote vpn site to which this hub virtual network connection is connected.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayObject + CortexParameterSetNames.ByVpnSiteObject,
            HelpMessage = "The remote vpn site to which this hub virtual network connection is connected.")]
        [ValidateNotNullOrEmpty]
        public PSVpnSite VpnSite { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayResourceId + CortexParameterSetNames.ByVpnSiteResourceId,
            HelpMessage = "The remote vpn site to which this hub virtual network connection is connected.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayName + CortexParameterSetNames.ByVpnSiteResourceId,
            HelpMessage = "The remote vpn site to which this hub virtual network connection is connected.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayObject + CortexParameterSetNames.ByVpnSiteResourceId,
            HelpMessage = "The remote vpn site to which this hub virtual network connection is connected.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/vpnSites")]
        public string VpnSiteId { get; set; }

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
        HelpMessage = "Gateway connection protocol:IKEv1/IKEv2")]
        [ValidateSet(
            MNM.VirtualNetworkGatewayConnectionProtocol.IKEv1,
            MNM.VirtualNetworkGatewayConnectionProtocol.IKEv2,
            IgnoreCase = true)]
        public string VpnConnectionProtocolType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable BGP for this connection")]
        public SwitchParameter EnableBgp { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Use local azure ip address as source ip for this connection.")]
        public SwitchParameter UseLocalAzureIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            
            WriteObject(this.CreateVpnConnection());
        }

        private PSVpnConnection CreateVpnConnection()
        {
            base.Execute();
            PSVpnGateway parentVpnGateway = null;

            //// Resolve the VpnGateway
            if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnGatewayObject))
            {
                this.ResourceGroupName = this.ParentObject.ResourceGroupName;
                this.ParentResourceName = this.ParentObject.Name;
            }
            else if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnGatewayResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.ParentResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentResourceName = parsedResourceId.ResourceName;
            }

            if (string.IsNullOrWhiteSpace(this.ResourceGroupName) || string.IsNullOrWhiteSpace(this.ParentResourceName))
            {
                throw new PSArgumentException(Properties.Resources.VpnGatewayRequiredToCreateVpnConnection);
            }

            if (this.IsVpnConnectionPresent(this.ResourceGroupName, this.ParentResourceName, this.Name))
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ChildResourceAlreadyPresentInResourceGroup, this.Name, this.ResourceGroupName, this.ParentResourceName));
            }

            //// At this point, we should have the resource name and the resource group for the parent VpnGateway resolved.
            //// This will throw not found exception if the VpnGateway does not exist
            parentVpnGateway = this.GetVpnGateway(this.ResourceGroupName, this.ParentResourceName);
            if (parentVpnGateway == null)
            {
                throw new PSArgumentException(Properties.Resources.ParentVpnGatewayNotFound);
            }

            if (parentVpnGateway.Connections == null)
            {
                parentVpnGateway.Connections = new List<PSVpnConnection>();
            }

            PSVpnConnection vpnConnection = new PSVpnConnection
            {
                Name = this.Name,
                EnableBgp = this.EnableBgp.IsPresent,
                UseLocalAzureIpAddress = this.UseLocalAzureIpAddress.IsPresent
            };

            //// Resolve the VpnSite reference
            //// And set it in the VpnConnection object.
            string vpnSiteResolvedId = null;
            if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnSiteObject))
            {
                vpnSiteResolvedId = this.VpnSite.Id;
            }
            else if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnSiteResourceId))
            {
                vpnSiteResolvedId = this.VpnSiteId;
            }

            if (string.IsNullOrWhiteSpace(vpnSiteResolvedId))
            {
                throw new PSArgumentException(Properties.Resources.VpnSiteRequiredForVpnConnection);
            }

            //// Let's not resolve the vpnSite here. If this does not exist, NRP/GWM will fail the call.
            vpnConnection.RemoteVpnSite = new PSResourceId() { Id = vpnSiteResolvedId };

            //// Set the shared key, if specified
            if (this.SharedKey != null)
            {
                vpnConnection.SharedKey = SecureStringExtensions.ConvertToString(this.SharedKey);
            }

            if (!String.IsNullOrEmpty(this.VpnConnectionProtocolType))
            {
                vpnConnection.VpnConnectionProtocolType = this.VpnConnectionProtocolType;
            }

            //// Connection bandwidth
            vpnConnection.ConnectionBandwidth = this.ConnectionBandwidthInMbps > 0 ?
                Convert.ToInt32(this.ConnectionBandwidthInMbps) :
                20;

            if (this.IpSecPolicy != null)
            {
                vpnConnection.IpsecPolicies = new List<PSIpsecPolicy> { this.IpSecPolicy };
            }

            parentVpnGateway.Connections.Add(vpnConnection);

            WriteVerbose(string.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));

            PSVpnConnection connectionToReturn = null;
            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    this.CreateOrUpdateVpnGateway(this.ResourceGroupName, this.ParentResourceName, parentVpnGateway, parentVpnGateway.Tag);

                    var createdOrUpdatedVpnGateway = this.GetVpnGateway(this.ResourceGroupName, this.ParentResourceName);
                    connectionToReturn = createdOrUpdatedVpnGateway.Connections.Where(connection => connection.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                });

            return connectionToReturn;
        }
    }
}
