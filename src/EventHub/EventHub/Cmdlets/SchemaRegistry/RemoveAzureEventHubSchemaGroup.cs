using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.SchemaRegistry
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubSchemaGroup", SupportsShouldProcess = true), OutputType(typeof(PSEventHubsSchemaRegistryAttributes))]
    public class RemoveAzureEventHubSchemaGroup: AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Name of Schema Group")]
        [Alias(AliasSchemaGroupName)]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if(ShouldProcess(target: Name, action: string.Format(Resources.RemoveNamespacesSchemaGroup, Name, ResourceGroupName)))
            {
                try
                {
                    Client.DeleteNamespaceSchemaGroup(ResourceGroupName, Namespace, Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                }
                catch (Management.EventHub.Models.ErrorResponseException ex)
                {
                    WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
                }
            }
        }
    }
}
