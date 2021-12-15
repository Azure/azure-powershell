using System;
using System.Collections.Generic;
using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;
using System.Collections;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;

namespace Microsoft.Azure.Commands.EventHub.Commands.SchemaRegistry
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubSchemaGroup", SupportsShouldProcess = true), OutputType(typeof(PSEventHubsSchemaRegistryAttributes))]
    public class SetAzureEventHubSchemaGroup: AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName;

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Name of Schema Group")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasSchemaGroupName)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Compatibility of Schema. Forward, Backward")]
        [ValidateSet("None", "Forward", "Backward", IgnoreCase = true)]
        public string SchemaCompatibility { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Type of Schema")]
        [ValidateSet("Avro", IgnoreCase = true)]
        public string SchemaType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Compatibility of Schema. Forward, Backward")]
        public Hashtable GroupProperties { get; set; }

        public override void ExecuteCmdlet()
        {
            Dictionary<string, string> groupPropertiesDictionary = TagsConversionHelper.CreateTagDictionary(GroupProperties, validate: true);

            if (ShouldProcess(target: Name, action: string.Format(Resources.UpdateNamespaceSchemaGroup, Name, Namespace)))
            {
                try
                {
                    WriteObject(Client.BeginUpdateNamespaceSchemaGroup(ResourceGroupName,
                        Namespace,
                        Name,
                        SchemaCompatibility,
                        SchemaType,
                        groupPropertiesDictionary));
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
