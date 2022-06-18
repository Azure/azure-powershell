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
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubApplicationGroup", DefaultParameterSetName = ApplicationGroupPropertiesParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSEventHubApplicationGroupAttributes))]
    public class GetEventHubsApplicationGroups : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ApplicationGroupPropertiesParameterSet, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ApplicationGroupPropertiesParameterSet, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ApplicationGroupPropertiesParameterSet, Position = 2, HelpMessage = "Application Group Name")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ApplicationGroupResourceIdParameterSet, Position = 0, HelpMessage = "Resource Id of application group or namespace")]
        public string ResourceId { get; set; }



        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ApplicationGroupResourceIdParameterSet)
            {
                ResourceIdentifier getParamAppGroup = new ResourceIdentifier(ResourceId);

                ResourceGroupName = getParamAppGroup.ResourceGroupName;

                if (getParamAppGroup.ResourceType.ToLower() == NamespaceURL.ToLower())
                {
                    NamespaceName = getParamAppGroup.ResourceName;
                }

                else if (getParamAppGroup.ResourceType.ToLower() == ApplicationGroupURL.ToLower())
                {
                    string[] resourceNames = getParamAppGroup.ParentResource.Split(new[] { '/' });
                    NamespaceName = resourceNames[1];
                    Name = getParamAppGroup.ResourceName;
                }
                else
                {
                    throw new Exception("Invalid Resource Id");
                }
            }

            try
            {
                if (Name == null)
                {
                    if (ShouldProcess(target: NamespaceName, action: string.Format(Resources.ListApplicationGroup, NamespaceName, ResourceGroupName)))
                    {
                        WriteObject(Client.ListApplicationGroup(ResourceGroupName, NamespaceName));
                    }
                }
                else
                {
                    if (ShouldProcess(target: Name, action: string.Format(Resources.GetApplicationGroup, Name, NamespaceName, ResourceGroupName)))
                    {
                        WriteObject(Client.GetApplicationGroup(ResourceGroupName, NamespaceName, Name));
                    }
                }
            }
            catch (Management.EventHub.Models.ErrorResponseException ex)
            {
                WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
            }

        }


    }
}
