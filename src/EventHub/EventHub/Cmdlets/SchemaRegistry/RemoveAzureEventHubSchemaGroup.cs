using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.EventHub.Commands.SchemaRegistry
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubSchemaGroup", DefaultParameterSetName = NamespaceSchemaGroupParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSEventHubsSchemaRegistryAttributes))]
    public class RemoveAzureEventHubSchemaGroup : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NamespaceSchemaGroupParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceSchemaGroupParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceSchemaGroupParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Name of Schema Group")]
        [Alias(AliasSchemaGroupName)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SchemaGroupInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Namespace Object")]
        [ValidateNotNullOrEmpty]
        public PSEventHubsSchemaRegistryAttributes InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SchemaGroupResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Namespace Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {

                if (ParameterSetName == SchemaGroupInputObjectParameterSet)
                {
                    ResourceIdentifier getParamSchemaGroup = new ResourceIdentifier(InputObject.Id);
                    if (getParamSchemaGroup.ResourceType.Equals(SchemaGroupURL))
                    {
                        ResourceGroupName = getParamSchemaGroup.ResourceGroupName;
                        string[] resourceNames = getParamSchemaGroup.ParentResource.Split(new[] { '/' });
                        Namespace = resourceNames[1];
                        Name = getParamSchemaGroup.ResourceName;
                    }
                    else
                        throw new Exception("Invalid Resource Id");
                }

                if (ParameterSetName == SchemaGroupResourceIdParameterSet)
                {
                    ResourceIdentifier getParamSchemaGroup = new ResourceIdentifier(ResourceId);
                    if (getParamSchemaGroup.ResourceType.Equals(SchemaGroupURL))
                    {
                        ResourceGroupName = getParamSchemaGroup.ResourceGroupName;
                        string[] resourceNames = getParamSchemaGroup.ParentResource.Split(new[] { '/' });
                        Namespace = resourceNames[1];
                        Name = getParamSchemaGroup.ResourceName;
                    }
                    else
                        throw new Exception("Invalid Resource Id");
                }

                if (ShouldProcess(target: Name, action: string.Format(Resources.RemoveNamespacesSchemaGroup, Name, Namespace)))
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
