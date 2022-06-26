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
using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.PrivateEndpoints
{
    /// <summary>
    /// 'Set-AzEventHubNamespace' Cmdlet updates the specified Eventhub Namespace
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusPrivateEndpointConnection", SupportsShouldProcess = true, DefaultParameterSetName = PrivateEndpointPropertiesParameterSet), OutputType(typeof(PSServiceBusPrivateEndpointConnectionAttributes))]
    public class GetAzureServiceBusPrivateEndpointConnection : AzureServiceBusCmdletBase
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
        [Parameter(Mandatory = true, ParameterSetName = PrivateEndpointPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "ServiceBus Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = PrivateEndpointPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Private Endpoint Connection Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = PrivateEndpointResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Private Endpoint Connection ResourceId.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {

            if (ParameterSetName == PrivateEndpointResourceIdParameterSet)
            {
                ResourceIdentifier getParamPrivateEndpoint = new ResourceIdentifier(ResourceId);

                ResourceGroupName = getParamPrivateEndpoint.ResourceGroupName;

                if (getParamPrivateEndpoint.ResourceType.ToLower() == NamespaceURL.ToLower())
                {
                    NamespaceName = getParamPrivateEndpoint.ResourceName;
                }

                else if (getParamPrivateEndpoint.ResourceType.ToLower() == PrivateEndpointURL.ToLower())
                {
                    string[] resourceNames = getParamPrivateEndpoint.ParentResource.Split(new[] { '/' });
                    NamespaceName = resourceNames[1];
                    Name = getParamPrivateEndpoint.ResourceName;
                }
                else
                {
                    throw new Exception("Invalid Resource Id");
                }
            }

            try
            {
                if(Name == null)
                {
                    if(ShouldProcess(target: NamespaceName, action: string.Format(Resources.ListNamespacePrivateEndpoints, NamespaceName, ResourceGroupName))){
                        WriteObject(Client.ListPrivateEndpointConnection(ResourceGroupName, NamespaceName));
                    }
                }
                else
                {
                    if (ShouldProcess(target: Name, action: string.Format(Resources.GetNamespacePrivateEndpoints, Name, NamespaceName, ResourceGroupName))){
                        WriteObject(Client.GetPrivateEndpointConnection(ResourceGroupName, NamespaceName, Name));
                    }
                }
            }

            catch (Management.ServiceBus.Models.ErrorResponseException ex)
            {
                WriteError(ServiceBusClient.WriteErrorforBadrequest(ex));
            }
        }



    }
}
