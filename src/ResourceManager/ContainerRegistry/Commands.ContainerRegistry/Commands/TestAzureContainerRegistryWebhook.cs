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

using System.Management.Automation;
using Microsoft.Azure.Management.ContainerRegistry.Models;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    [Cmdlet(VerbsDiagnostic.Test, ContainerRegistryWebhookNoun, DefaultParameterSetName = ResourceIdParameterSet)]
    [OutputType(typeof(PSContainerRegistryEventInfo))]
    public class TestAzureContainerRegistryWebhook : ContainerRegistryCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = NameResourceGroupParameterSet, HelpMessage = "Webhook Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(WebhookNameAlias, ResourceNameAlias)]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = NameResourceGroupParameterSet, HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 2, Mandatory = true, ParameterSetName = NameResourceGroupParameterSet, HelpMessage = "Container Registry Name.")]
        [Alias(ContainerRegistryNameAlias)]
        [ValidateNotNullOrEmpty]
        public string RegistryName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = WebhookObjectParameterSet, ValueFromPipeline = true, HelpMessage = "Container Registry Object.")]
        [ValidateNotNull]
        public PSContainerRegistryWebhook Webhook { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The container registry Webhook resource id")]
        [ValidateNotNullOrEmpty]
        [Alias(ResourceIdAlias)]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.Equals(ParameterSetName, WebhookObjectParameterSet))
            {
                ResourceId = Webhook.Id;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ResourceId") || !string.IsNullOrWhiteSpace(ResourceId))
            {
                string resourceGroup, registryName, childResourceName;
                if(!ConversionUtilities.TryParseRegistryRelatedResourceId(ResourceId, out resourceGroup, out registryName, out childResourceName)
                    || string.IsNullOrEmpty(childResourceName))
                {
                    WriteInvalidResourceIdError(InvalidWebhookResourceIdErrorMessage);
                    return;
                }

                ResourceGroupName = resourceGroup;
                Name = childResourceName;
                RegistryName = registryName;
            }

            var eventInfo = RegistryClient.PingWebhook(ResourceGroupName, RegistryName, Name);
            WriteObject(new PSContainerRegistryEventInfo(eventInfo));
        }
    }
}
