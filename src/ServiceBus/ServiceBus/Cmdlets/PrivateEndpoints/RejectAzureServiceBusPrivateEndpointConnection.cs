﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.PrivateEndpoints
{
    /// <summary>
    /// 'Set-AzEventHubNamespace' Cmdlet updates the specified Eventhub Namespace
    /// </summary>
    [GenericBreakingChange(message: BreakingChangeNotification + "\n- Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.IPrivateEndpointConnection'", deprecateByVersion: DeprecateByVersion, changeInEfectByDate: ChangeInEffectByDate)]
    [Cmdlet("Deny", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusPrivateEndpointConnection", SupportsShouldProcess = true, DefaultParameterSetName = PrivateEndpointPropertiesParameterSet), OutputType(typeof(PSServiceBusPrivateEndpointConnectionAttributes))]
    public class RejectAzureServiceBusPrivateEndpointConnection : AzureServiceBusCmdletBase
    {

        /// <summary>
        /// Name of the resource group.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = PrivateEndpointPropertiesParameterSet, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// ServiceBus Namespace Name.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = PrivateEndpointPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "ServiceBus Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = PrivateEndpointPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Private Endpoint Connection Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [CmdletParameterBreakingChange("ResourceId", ReplaceMentCmdletParameterName = "InputObject")]
        [Parameter(Mandatory = true, ParameterSetName = PrivateEndpointResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Private Endpoint Connection ResourceId.")]
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
                if (getParamPrivateEndpoint.ResourceType.ToLower().Equals(PrivateEndpointURL.ToLower()))
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
                catch (Management.ServiceBus.Models.ErrorResponseException ex)
                {
                    WriteError(ServiceBusClient.WriteErrorforBadrequest(ex));
                }
            }

        }
    }
}
