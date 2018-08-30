namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Network.Models;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get,
        "AzureRmHubVirtualNetworkConnection",
        SupportsShouldProcess = true),
        OutputType(typeof(PSHubVirtualNetworkConnection))]
    public class GetHubVirtualNetworkConnectionCommand : HubVnetConnectionBaseCmdlet
    {
        [Alias("ResourceName", "HubVirtualNetworkConnectionName")]
        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("VirtualHubName", "ParentVirtualHubName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The parent resource name.")]
        [ResourceGroupCompleter]
        public string ParentResourceName { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                WriteObject(this.GetHubVirtualNetworkConnection(this.ResourceGroupName, this.ParentResourceName, this.Name));
            }
            else
            {
                WriteObject(this.ListHubVnetConnections(this.ResourceGroupName, this.ParentResourceName));
            }
        }
    }
}
