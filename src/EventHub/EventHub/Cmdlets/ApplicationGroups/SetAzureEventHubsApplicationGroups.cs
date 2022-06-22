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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.AppicationGroups
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubApplicationGroup", DefaultParameterSetName = ApplicationGroupPropertiesParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSEventHubApplicationGroupAttributes))]
    public class SetAzureEventHubsApplicationGroups: AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ApplicationGroupPropertiesParameterSet, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ApplicationGroupPropertiesParameterSet, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ApplicationGroupPropertiesParameterSet, Position = 2, HelpMessage = "Application Group Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ApplicationGroupPropertiesParameterSet, Position = 3, HelpMessage = "Determines if Application Group is allowed to create connection with namespace or not. Once the isEnabled is set to false, all the existing connections of application group gets dropped and no new connections will be allowed")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ApplicationGroupResourceIdParameterSet, HelpMessage = "Determines if Application Group is allowed to create connection with namespace or not. Once the isEnabled is set to false, all the existing connections of application group gets dropped and no new connections will be allowed")]
        public SwitchParameter IsEnabled { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ApplicationGroupPropertiesParameterSet, HelpMessage = "List of Throttling Policy Objects. Please use New-AzEventHubThrottlingPolicyConfig to create in memory object which can be one item in this list.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ApplicationGroupResourceIdParameterSet, HelpMessage = "List of Throttling Policy Objects. Please use New-AzEventHubThrottlingPolicyConfig to create in memory object which can be one item in this list.")]
        public PSEventHubThrottlingPolicyConfigAttributes[] ThrottlingPolicyConfig { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ApplicationGroupResourceIdParameterSet, HelpMessage = "ResourceId of application group")]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ApplicationGroupInputObjectParameterSet, Position = 0, HelpMessage = "Input Object of type PSEventHubApplicationGroupAttributes")]
        public PSEventHubApplicationGroupAttributes InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ApplicationGroupResourceIdParameterSet || ParameterSetName == ApplicationGroupInputObjectParameterSet)
            {
                if(InputObject != null)
                {
                    ResourceId = InputObject.Id;
                }

                ResourceIdentifier getParamApplicationGroup = new ResourceIdentifier(ResourceId);
                
                if (getParamApplicationGroup.ResourceType.ToLower().Equals(ApplicationGroupURL.ToLower()))
                {
                    ResourceGroupName = getParamApplicationGroup.ResourceGroupName;
                    string[] resourceNames = getParamApplicationGroup.ParentResource.Split(new[] { '/' });
                    NamespaceName = resourceNames[1];
                    Name = getParamApplicationGroup.ResourceName;
                }
                
                else
                    throw new Exception("Invalid Resource Id");
            }


            if (ShouldProcess(target: Name, action: string.Format(Resources.UpdateApplicationGroup, Name, NamespaceName, ResourceGroupName)))
            {
                try
                {
                    if (ParameterSetName == ApplicationGroupPropertiesParameterSet || ParameterSetName == ApplicationGroupResourceIdParameterSet)
                    {
                        bool? isEnabled = null;

                        //This is done because isPresent does not really indicate if SwitchParameter
                        //is explicitly set to false or not present at all
                        if (this.IsParameterBound(c => c.IsEnabled) == true)
                        {
                            isEnabled = IsEnabled.IsPresent;
                        }

                        WriteObject(Client.UpdateApplicationGroup(resourceGroupName: ResourceGroupName,
                                                                  namespaceName: NamespaceName,
                                                                  appGroupName: Name,
                                                                  isEnabled: isEnabled,
                                                                  throttlingPolicy: ThrottlingPolicyConfig));
                    }
                    else if(ParameterSetName == ApplicationGroupInputObjectParameterSet)
                    {
                        //When InputObject is given as a parameter, the assumption is that the consumer has given the entire desired state
                        //Hence we reconstruct a new app group object
                        //That is why a create call and not update call.
                        WriteObject(Client.CreateApplicationGroup(resourceGroupName: ResourceGroupName,
                                                                  namespaceName: NamespaceName,
                                                                  appGroupName: Name,
                                                                  clientAppGroupIdentifier: InputObject.ClientAppGroupIdentifier,
                                                                  isEnabled: InputObject.IsEnabled,
                                                                  throttlingPolicy: InputObject.ThrottlingPolicyConfig));
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
