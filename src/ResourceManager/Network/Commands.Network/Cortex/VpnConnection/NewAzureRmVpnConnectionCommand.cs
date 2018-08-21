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
        "AzureRmVpnConnection",
        DefaultParameterSetName = CortexParameterSetNames.ByVpnGatewayName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnConnection))]
    public class NewAzureRmVpnConnectionCommand : VpnConnectionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("ParentVpnGatewayName", "VpnGatewayName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name of the parent VpnGateway for this connection.")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceName { get; set; }

        [Alias("ParentVpnGateway", "VpnGateway")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayObject,
            HelpMessage = "The parent VpnGateway for this connection.")]
        [ValidateNotNullOrEmpty]
        public PSVpnGateway ParentObject { get; set; }

        [Alias("ParentVpnGatewayId", "VpnGatewayId")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayResourceId,
            HelpMessage = "The resource id of the parent VpnGateway for this connection.")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceId { get; set; }

        [Alias("ResourceName", "VpnConnectionName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The vpn site this connection is connected to.")]
        [ValidateNotNullOrEmpty]
        public PSVpnSite VpnSite { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The vpn site id for the VpnSite this connection is connected to.")]
        [ValidateNotNullOrEmpty]
        public string VpnSiteId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The shared key required to set this connection up.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public SecureString SharedKey { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The bandwith that needs to be handled by this connection in mbps.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public uint ConnectionBandwidthInMbps { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The bandwith that needs to be handled by this connection in mbps.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public PSIpsecPolicy IpSecPolicy { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable BGP for this connection")]
        public bool EnableBgp { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable rate limiting for this connection")]
        public bool EnableRateLimiting { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable internet security for this connection")]
        public bool EnableInternetSecurity { get; set; }

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

            bool shouldProcess = this.Force.IsPresent;

            if (!shouldProcess)
            {
                shouldProcess = ShouldProcess(this.Name, Properties.Resources.CreatingResourceMessage);
            }

            if (shouldProcess)
            {
                WriteObject(this.CreateVpnConnection());
            }
        }

        private PSVpnConnection CreateVpnConnection()
        {
            PSVpnGateway parentVpnGateway = null;

            //// Resolve the VpnGateway
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnGatewayObject, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceGroupName = this.ParentObject.ResourceGroupName;
                this.ParentResourceName = this.ParentObject.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnGatewayResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ParentResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentResourceName = parsedResourceId.ResourceName;
            }

            //// At this point, we should have the resource name and the resource group for the parent VpnGateway resolved.
            //// This will throw not found exception if the VpnGateway does not exist
            parentVpnGateway = this.GetVpnGateway(this.ResourceGroupName, this.ParentResourceName);
            if (parentVpnGateway == null)
            {
                throw new PSArgumentException("The parent VpnGateway for this connection cannot be found.");
            }

            //// Validate if there is a conenction with this name on this vpn connection
            //// Fail the new connection operation if there is
            if (parentVpnGateway.VpnConnections != null)
            {
                if (parentVpnGateway.VpnConnections.Any(connection => connection.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new PSArgumentException("The parent VpnGateway already contains a connection with this name. If you wish to change the properties of the connection, please use the SET operation instead.");
                }
            }
            else
            {
                parentVpnGateway.VpnConnections = new List<PSVpnConnection>();
            }

            PSVpnConnection vpnConnection = new PSVpnConnection
            {
                Name = this.Name,
                ConnectionBandwidhtInMbps = Convert.ToInt32(this.ConnectionBandwidthInMbps),
                EnableBgp = this.EnableBgp,
                EnableRateLimiting = this.EnableRateLimiting,
                EnableInternetSecurity = this.EnableInternetSecurity
            };

            //// Resolve the VpnSite
            string vpnSiteRGName = null;
            string vpnSiteName = null;

            if (this.VpnSite != null)
            {
                vpnSiteRGName = this.VpnSite.ResourceGroupName;
                vpnSiteName = this.VpnSite.Name;
            }
            else if (!string.IsNullOrWhiteSpace(this.VpnSiteId))
            {
                var parsedVpnSiteResourceId = new ResourceIdentifier(this.VpnSiteId);
                vpnSiteRGName = parsedVpnSiteResourceId.ResourceGroupName;
                vpnSiteName = parsedVpnSiteResourceId.ResourceName;
            }

            //// Get the VpnSite - this will throw not found if the VpnSite does not exist
            vpnConnection.VpnSite = new VpnSiteBaseCmdlet().GetVpnSite(vpnSiteRGName, vpnSiteName);

            //// Set the shared key, if specified
            if (this.SharedKey != null)
            {
                vpnConnection.SharedKey = SecureStringExtensions.ConvertToString(this.SharedKey);
            }

            //// Connection bandwidth
            vpnConnection.ConnectionBandwidhtInMbps = this.ConnectionBandwidthInMbps > 0 ?
                Convert.ToInt32(this.ConnectionBandwidthInMbps) :
                20;

            if (this.IpSecPolicy != null)
            {
                vpnConnection.IpsecPolicies = new List<PSIpsecPolicy> { this.IpSecPolicy };
            }

            parentVpnGateway.VpnConnections.Add(vpnConnection);

            // Map to the sdk object
            var vpnGatewayModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VpnGateway>(parentVpnGateway);
            this.VpnGatewayClient.CreateOrUpdate(this.ResourceGroupName, this.Name, vpnGatewayModel);

            var createdOrUpdatedVpnGateway = this.GetVpnGateway(this.ResourceGroupName, this.Name);
            return createdOrUpdatedVpnGateway.VpnConnections.Where(connection => connection.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }
    }
}
