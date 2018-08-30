namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Network.Models;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get,
        "AzureRmVirtualHub",
        SupportsShouldProcess = true),
        OutputType(typeof(PSVirtualHub))]
    public class GetAzureRmVirtualHubCommand : VirtualHubBaseCmdlet
    {
        [Alias("ResourceName", "VirtualHubName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                if (string.IsNullOrWhiteSpace(this.ResourceGroupName))
                {
                    throw new PSArgumentException("ResourceGroupName must be specified if ResourceName is specified.");
                }

                WriteObject(this.GetVirtualHub(this.ResourceGroupName, this.Name));
            }
            else
            {
                //// Resource name has not been specified - list all hubs
                WriteObject(this.ListVirtualHubs(this.ResourceGroupName));
            }
        }
    }
}
