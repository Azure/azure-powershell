using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.EventHub.Commands.SchemaRegistry
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubSchemaGroup", SupportsShouldProcess = true), OutputType(typeof(PSEventHubsSchemaRegistryAttributes))]
    public class AddAzureEventHubSchemaGroup: AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Name of Schema Group")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasSchemaGroupName)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Compatibility of Schema. Forward, Backward")]
        [ValidateSet("None", "Forward", "Backward", IgnoreCase = true)]
        public string SchemaCompatibility { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Type of Schema")]
        [ValidateSet("Avro", IgnoreCase = true)]
        public string SchemaType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Group property of eventhub")]
        public Hashtable GroupProperty { get; set; }

        public override void ExecuteCmdlet()
        {
            

            if (ShouldProcess(target: Name, action: string.Format(Resources.CreateNamespaceSchemaGroup, Name, Namespace)))
            {
                try
                {
                    WriteObject(Client.BeginCreateNamespaceSchemaGroup(resourceGroupName: ResourceGroupName,
                            namespaceName: Namespace, 
                            schemaGroupName: Name, 
                            schemaCompatibility: SchemaCompatibility, 
                            schemaType: SchemaType, 
                            groupProperties: GroupProperty));
                }
                   
                catch (Management.EventHub.Models.ErrorResponseException ex)
                {
                    WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
                }
                catch (Exception ex)
                {
                    WriteError(new ErrorRecord(ex, ex.Message, ErrorCategory.OpenError, ex));
                }
            }
            
            
        }
    }
}
