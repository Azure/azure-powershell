namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Network.Models;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "P2SVpnGateway",
        DefaultParameterSetName = "ListByResourceGroupName"),
        OutputType(typeof(PSP2SVpnGateway))]
    public class GetAzureRmP2SVpnGatewayCommand : P2SVpnGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ListByResourceGroupName",
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("ResourceName", "P2SVpnGatewayName")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = "ListByResourceGroupName",
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ParameterSetName.Equals("ListByResourceGroupName") && !string.IsNullOrEmpty(this.Name))
            {
                var p2sVpnGateway = this.GetP2SVpnGateway(this.ResourceGroupName, this.Name);

                WriteObject(p2sVpnGateway);
            }
            else
            {
                //// ResourceName has not been specified - List all gateways
                WriteObject(this.ListP2SVpnGateways(this.ResourceGroupName), true);
            }
        }
    }
}
