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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    [Cmdlet(VerbsCommon.Get, ContainerRegistryWebhookNoun, DefaultParameterSetName = ListWebhookByNameResourceGroupParameterSet)]
    [OutputType(typeof(PSContainerRegistryWebhook), typeof(IList<PSContainerRegistryWebhook>))]
    public class GetAzureContainerRegistryWebhook : ContainerRegistryCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ShowWebhookByNameResourceGroupParameterSet, HelpMessage = "Webhook Name.")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ShowWebhookByRegistryObjectParameterSet, HelpMessage = "Webhook Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(WebhookNameAlias, ResourceNameAlias)]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ListWebhookByNameResourceGroupParameterSet, HelpMessage = "Resource Group Name.")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ShowWebhookByNameResourceGroupParameterSet, HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 2, Mandatory = true, ParameterSetName = ListWebhookByNameResourceGroupParameterSet, HelpMessage = "Container Registry Name.")]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = ShowWebhookByNameResourceGroupParameterSet, HelpMessage = "Container Registry Name.")]
        [Alias(ContainerRegistryNameAlias)]
        [ValidateNotNullOrEmpty]
        public string RegistryName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ListWebhookByRegistryObjectParameterSet, ValueFromPipeline = true, HelpMessage = "Container Registry Object.")]
        [Parameter(Mandatory = true, ParameterSetName = ShowWebhookByRegistryObjectParameterSet, ValueFromPipeline = true, HelpMessage = "Container Registry Object.")]
        [ValidateNotNull]
        public PSContainerRegistry Registry { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Get the configuration information for a webhook.")]
        public SwitchParameter IncludeConfiguration { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The container registry Webhook resource id")]
        [ValidateNotNullOrEmpty]
        [Alias(ResourceIdAlias)]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.Equals(ParameterSetName, ListWebhookByRegistryObjectParameterSet) ||
                string.Equals(ParameterSetName, ShowWebhookByRegistryObjectParameterSet))
            {
                ResourceGroupName = Registry.ResourceGroupName;
                RegistryName = Registry.Name;
            }

            switch (ParameterSetName)
            {
                case ShowWebhookByNameResourceGroupParameterSet:
                case ShowWebhookByRegistryObjectParameterSet:
                    ShowWebhook();
                    break;
                case ListWebhookByRegistryObjectParameterSet:
                case ListWebhookByNameResourceGroupParameterSet:
                    ListWebhook();
                    break;
                case ResourceIdParameterSet:
                    ShowWebhookByResourceId();
                    break;
            }
        }

        private void ShowWebhookByResourceId()
        {
            string resourceGroup, registryName, childResourceName;
            if (!ConversionUtilities.TryParseRegistryRelatedResourceId(ResourceId, out resourceGroup, out registryName, out childResourceName))
            {
                WriteInvalidResourceIdError(InvalidRegistryOrWebhookResourceIdErrorMessage);
                return;
            }

            ResourceGroupName = resourceGroup;
            Name = childResourceName;
            RegistryName = registryName;

            // If the resourceid is a registry id, then list all the webhooks under that registry
            if (string.IsNullOrEmpty(Name))
            {
                ListWebhook();
            }
            else
            {
                ShowWebhook();
            }
        }

        private void ShowWebhook()
        {
            var webhook = RegistryClient.GetWebhook(ResourceGroupName, RegistryName, Name);
            var psWebhook = new PSContainerRegistryWebhook(webhook);
            if (IncludeConfiguration)
            {
                SetWebhookConfig(psWebhook);
            }
            WriteObject(psWebhook);
        }

        private void ListWebhook()
        {
            var webhooks = RegistryClient.ListAllWebhook(ResourceGroupName, RegistryName);
            if (IncludeConfiguration)
            {
                foreach (var wk in webhooks)
                {
                    SetWebhookConfig(wk);
                }
            }
            WriteObject(webhooks, true);
        }

        private void SetWebhookConfig(PSContainerRegistryWebhook webhook)
        {
            var config = RegistryClient.GetWebhookGetCallbackConfig(ResourceGroupName, RegistryName, webhook.Name);
            webhook.Config = config;
        }
    }
}
