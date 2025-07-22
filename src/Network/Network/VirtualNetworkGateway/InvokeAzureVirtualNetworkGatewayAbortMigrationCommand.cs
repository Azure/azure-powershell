using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayAbortMigration",
        DefaultParameterSetName = ParameterSetNames.ByName, SupportsShouldProcess = true), OutputType(typeof(PSVirtualNetworkGateway))]
    public class InvokeAzureVirtualNetworkGatewayAbortMigrationCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParameterSetNames.ByName,
            HelpMessage = "The virtual network gateway name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualNetworkGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ParameterSetNames.ByName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("VirtualNetworkGateway")]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtualNetworkGateway")]
        [ValidateNotNullOrEmpty]
        public PSVirtualNetworkGateway InputObject { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (ParameterSetName.Equals(ParameterSetNames.ByInputObject, StringComparison.OrdinalIgnoreCase))
            {
                Name = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(ParameterSetNames.ByResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                Name = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
            }

            base.Execute();

            if (!this.IsVirtualNetworkGatewayPresent(this.ResourceGroupName, this.Name))
            {
                throw new PSArgumentException(Properties.Resources.ResourceNotFound, "Virtual Network Gateway");
            }

            string shouldProcessMessage = string.Format($"Execute Invoke-AzVirtualNetworkGatewayAbortMigration for ResourceGroupName {0} VirtualNetworkGateway {1}", this.ResourceGroupName, this.Name);
            if (ShouldProcess(shouldProcessMessage))
            {
                this.VirtualNetworkGatewayClient.InvokeAbortMigration(this.ResourceGroupName, this.Name);

                var getVirtualNetworkGateway = this.GetVirtualNetworkGateway(this.ResourceGroupName, this.Name);
                WriteObject(getVirtualNetworkGateway);
            }
        }
    }
}
