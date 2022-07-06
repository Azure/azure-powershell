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
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubApplicationGroup", DefaultParameterSetName = ApplicationGroupPropertiesParameterSet, SupportsShouldProcess = true), OutputType(typeof(void))]
    public class RemoveEventHubsApplicationGroups : AzureEventHubsCmdletBase
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

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ApplicationGroupResourceIdParameterSet, Position = 0, HelpMessage = "ResourceId of application group")]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ApplicationGroupInputObjectParameterSet, Position = 0, HelpMessage = "Input Object of type PSEventHubApplicationGroupAttributes")]
        public PSEventHubApplicationGroupAttributes InputObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }


        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ApplicationGroupResourceIdParameterSet || ParameterSetName == ApplicationGroupInputObjectParameterSet)
            {
                if (InputObject != null)
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

            if (ShouldProcess(target: Name, action: string.Format(Resources.RemoveApplicationGroup, Name, NamespaceName, ResourceGroupName)))
            {
                try
                {
                    Client.DeleteApplicationGroup(resourceGroupName: ResourceGroupName,
                                                  namespaceName: NamespaceName,
                                                  appGroupName: Name);

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


    }
}
