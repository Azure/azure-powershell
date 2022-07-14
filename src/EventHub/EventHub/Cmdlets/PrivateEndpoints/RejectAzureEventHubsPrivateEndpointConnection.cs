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
using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.PrivateEndpoints
{
    /// <summary>
    /// 'Set-AzEventHubNamespace' Cmdlet updates the specified Eventhub Namespace
    /// </summary>
    [Cmdlet("Deny", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubPrivateEndpointConnection", SupportsShouldProcess = true, DefaultParameterSetName = PrivateEndpointPropertiesParameterSet), OutputType(typeof(PSEventHubPrivateEndpointConnectionAttributes))]
    public class RejectAzureEventHubsPrivateEndpointConnection : AzureEventHubsCmdletBase
    {

        /// <summary>
        /// Name of the resource group.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = PrivateEndpointPropertiesParameterSet, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// EventHub Namespace Name.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = PrivateEndpointPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "EventHub Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = PrivateEndpointPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Private Endpoint Connection Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = PrivateEndpointResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Private Endpoint Connection ARM ID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = PrivateEndpointResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Description of the connection state.")]
        [Parameter(Mandatory = false, ParameterSetName = PrivateEndpointPropertiesParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Description of the connection state.")]
        public string Description { get; set; }

        public override void ExecuteCmdlet()
        {

            if (ParameterSetName == PrivateEndpointResourceIdParameterSet)
            {
                ResourceIdentifier getParamPrivateEndpoint = new ResourceIdentifier(ResourceId);
                if (getParamPrivateEndpoint.ResourceType.Equals(PrivateEndpointURL))
                {
                    ResourceGroupName = getParamPrivateEndpoint.ResourceGroupName;
                    string[] resourceNames = getParamPrivateEndpoint.ParentResource.Split(new[] { '/' });
                    NamespaceName = resourceNames[1];
                    Name = getParamPrivateEndpoint.ResourceName;
                }
                else
                    throw new Exception("Invalid Resource Id");
            }

            if (ShouldProcess(target: Name, action: string.Format(Resources.RejectNamespacePrivateEndpoints, Name, NamespaceName, ResourceGroupName)))
            {
                try
                {

                    //We have to set an empty description in the payload,
                    //indicating that the approval or rejection did not come with a message
                    if (Description == null)
                    {
                        Description = String.Empty;
                    }

                    WriteObject(Client.UpdatePrivateEndpointConnection(resourceGroupName: ResourceGroupName,
                                                                       namespaceName: NamespaceName,
                                                                       privateEndpointName: Name,
                                                                       connectionState: "Rejected",
                                                                       description: Description));
                }
                catch (Management.EventHub.Models.ErrorResponseException ex)
                {
                    WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
                }
            }

        }
    }
}
