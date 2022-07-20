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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.AppicationGroups
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubApplicationGroup", DefaultParameterSetName = ApplicationGroupPropertiesParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSEventHubApplicationGroupAttributes))]
    public class NewAzureEventHubsApplicationGroups : AzureEventHubsCmdletBase
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

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ApplicationGroupPropertiesParameterSet, Position = 3, HelpMessage = "The Unique identifier for application group.Supports SAS(SASKeyName=KeyName) or AAD(AADAppID=Guid)")]
        [ValidateNotNullOrEmpty]
        public string ClientAppGroupIdentifier { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ApplicationGroupPropertiesParameterSet, HelpMessage = "Determines if Application Group is allowed to create connection with namespace or not. Once the isEnabled is set to false, all the existing connections of application group gets dropped and no new connections will be allowed")]
        public SwitchParameter IsEnabled { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ApplicationGroupPropertiesParameterSet, HelpMessage = "List of Throttling Policy Objects")]
        public PSEventHubThrottlingPolicyConfigAttributes[] ThrottlingPolicyConfig { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: Name, action: string.Format(Resources.CreateApplicationGroup, Name, NamespaceName, ResourceGroupName)))
            {
                try
                {
                    bool? isEnabled = null;

                    if (this.IsParameterBound(c => c.IsEnabled) == true)
                    {
                        isEnabled = IsEnabled.IsPresent;
                    }

                    WriteObject(Client.CreateApplicationGroup(resourceGroupName: ResourceGroupName,
                                                              namespaceName: NamespaceName,
                                                              appGroupName: Name,
                                                              clientAppGroupIdentifier: ClientAppGroupIdentifier,
                                                              isEnabled: isEnabled,
                                                              throttlingPolicy: ThrottlingPolicyConfig));
                }

                catch (Management.EventHub.Models.ErrorResponseException ex)
                {
                    WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
                }
            }
        }


    }
}
