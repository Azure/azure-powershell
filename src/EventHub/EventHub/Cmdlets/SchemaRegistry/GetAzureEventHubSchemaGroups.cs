// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Linq;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;

namespace Microsoft.Azure.Commands.EventHub.Commands.SchemaRegistry
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubSchemaGroup", DefaultParameterSetName = NamespaceSchemaGroupParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSEventHubsSchemaRegistryAttributes))]
    public class GetAzureEventHubSchemaGroups : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NamespaceSchemaGroupParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceSchemaGroupParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SchemaGroupResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Namespace Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NamespaceSchemaGroupParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Name of Schema Group")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasSchemaGroupName)]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (ParameterSetName.Equals(SchemaGroupResourceIdParameterSet))
                {
                    ResourceIdentifier getParamSchemaGroup = new ResourceIdentifier(ResourceId);
                    ResourceGroupName = getParamSchemaGroup.ResourceGroupName;
                    if(getParamSchemaGroup.ResourceType == NamespaceURL)
                    {
                        Namespace = getParamSchemaGroup.ResourceName;
                    }
                    else if(getParamSchemaGroup.ResourceType == SchemaGroupURL)
                    {
                        string[] resourceNames = getParamSchemaGroup.ParentResource.Split(new[] { '/' });
                        Namespace = resourceNames[1];
                        Name = getParamSchemaGroup.ResourceName;
                    }
                    else
                    {
                        throw new Exception("Invalid Resource Id");
                    }
                }


                if (string.IsNullOrEmpty(Name))
                {
                    IEnumerable<PSEventHubsSchemaRegistryAttributes> schemaGroups = Client.ListSchemaGroupByNamespace(ResourceGroupName, Namespace);
                    WriteObject(schemaGroups.ToList(), true);
                }
                else if (!string.IsNullOrEmpty(Name))
                {
                    PSEventHubsSchemaRegistryAttributes schemaGroup = Client.GetSchemaGroup(ResourceGroupName, Namespace, Name);
                    WriteObject(schemaGroup);
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
