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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.EventGrid.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Commands.EventGrid.Utilities;
using EventGridModels = Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(
        "Remove",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridPartnerTopicEventSubscription",
        SupportsShouldProcess = true,
        DefaultParameterSetName = PartnerTopicNameParameterSet),
    OutputType(typeof(bool))]

    public class RemoveAzureEventGridPartnerTopicEventSubscription : AzureEventGridCmdletBase
    {
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
           ParameterSetName = PartnerTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.EventGrid/partnerTopics/eventSubscriptions", nameof(ResourceGroupName), nameof(PartnerTopicName))]
        [Alias("EventSubscriptionName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = PartnerTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PartnerTopicNameHelp,
            ParameterSetName = PartnerTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.EventGrid/partnerTopics", nameof(ResourceGroupName))]
        public string PartnerTopicName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.EventSubscriptionResourceIdHelp,
            ParameterSetName = ResourceIdPartnerTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// If present, do not ask for confirmation
        /// </summary>
        [Parameter(Mandatory = false,
           HelpMessage = EventGridConstants.ForceHelp)]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            string resourceGroupName = string.Empty;
            string partnerTopicName = string.Empty;
            string eventSubscriptionName = string.Empty;

            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                EventGridUtils.GetResourceGroupNameAndTopicNameAndEventSubscriptionName(
                    this.ResourceId,
                    out resourceGroupName,
                    out partnerTopicName,
                    out eventSubscriptionName);
            }
            else
            {
                resourceGroupName = this.ResourceGroupName;
                partnerTopicName = this.PartnerTopicName;
                eventSubscriptionName = this.Name;
            }

            ConfirmAction(Force.IsPresent,
                $"Remove event subscription {eventSubscriptionName}",
                $"Removing event subscription {eventSubscriptionName}",
                eventSubscriptionName,
                () =>
                {
                    this.Client.DeletePartnerTopicEventSubscription(resourceGroupName, partnerTopicName, eventSubscriptionName);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
