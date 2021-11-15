namespace Microsoft.Azure.Commands.Network.Cortex.VpnConnection
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    
    [Cmdlet(
        VerbsCommon.Reset,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnSiteLinkConnection",
        DefaultParameterSetName = "ByName",
        SupportsShouldProcess = true),
        OutputType(typeof(void))]

    public class ResetAzVpnSiteLinkConnectionCommand : VpnLinkConnectionBaseCmdlet
    {
        [Parameter(
            ParameterSetName = "ByName",
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("GrandParentName")]
        [Parameter(
            ParameterSetName = "ByName",
            Mandatory = true,
            HelpMessage = "The Vpn gateway name.")]
        [ResourceNameCompleter("Microsoft.Network/vpnGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VpnGatewayName { get; set; }

        [Alias("ParentName")]
        [Parameter(
            ParameterSetName = "ByName",
            Mandatory = true,
            HelpMessage = "The Vpn connection name.")]
        [ResourceNameCompleter("Microsoft.Network/connections", "GrandParentResourceName")]
        [ValidateNotNullOrEmpty]
        public string VpnConnectionName { get; set; }

        [Alias("ResourceName", "VpnSiteLinkConnectionName")]
        [Parameter(
            ParameterSetName = "ByName",
            Mandatory = true,
            HelpMessage = "The Vpn site link connection name.")]
        [ResourceNameCompleter("Microsoft.Network/connections", "ParentResourceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("VpnSiteLinkConnection")]
        [Parameter(
            ParameterSetName = "ByInputObject",
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Vpn site link connection object.")]
        [ValidateNotNullOrEmpty]
        public PSVpnSiteLinkConnection InputObject { get; set; }

        [Parameter(
            ParameterSetName = "ByResourceId",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID of the Vpn site link connection for which IKE SAs needs to be fetched.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            var parsedResourceId = new ResourceIdentifier();

            if (!ParameterSetName.Equals("ByName"))
            {
                if (ParameterSetName.Equals("ByResourceId"))
                {
                    parsedResourceId = new ResourceIdentifier(this.ResourceId);
                }
                else if (ParameterSetName.Equals("ByInputObject"))
                {
                    parsedResourceId = new ResourceIdentifier(this.InputObject.Id);
                }

                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                var resources = parsedResourceId.ParentResource.Split(new[] { '/' }, 4, StringSplitOptions.RemoveEmptyEntries);
                this.VpnGatewayName = resources[1];
                this.VpnConnectionName = resources[3];
                this.Name = parsedResourceId.ResourceName;
            }

            base.Execute();

            if (this.IsVpnConnectionPresent(this.ResourceGroupName, this.VpnGatewayName, this.VpnConnectionName))
            {
                this.VpnLinkConnectionClient.ResetConnection(this.ResourceGroupName, this.VpnGatewayName, this.VpnConnectionName, this.Name);
            }
            else
            {
                throw new PSArgumentException(Properties.Resources.ResourceNotFound, this.Name);
            }
        }
    }
}
