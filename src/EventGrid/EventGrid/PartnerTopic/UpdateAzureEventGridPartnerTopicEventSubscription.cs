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
        "Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridPartnerTopicEventSubscription",
        SupportsShouldProcess = true,
        DefaultParameterSetName = PartnerTopicNameParameterSet),
    OutputType(typeof(PSEventSubscription))]

    public class UpdateAzureEventGridPartnerTopicEventSubscription : AzureEventGridCmdletBase
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

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = PartnerTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = ResourceIdPartnerTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DeadLetterEndpoint { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DeliveryAttributeMappingHelp,
            ParameterSetName = PartnerTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.DeliveryAttributeMappingHelp,
            ParameterSetName = ResourceIdPartnerTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] DeliveryAttributeMapping { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = PartnerTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = ResourceIdPartnerTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Endpoint { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = PartnerTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = ResourceIdPartnerTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string EndpointType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = PartnerTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = ResourceIdPartnerTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] Label { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.StorageQueueMessageTtlHelp,
            ParameterSetName = PartnerTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.StorageQueueMessageTtlHelp,
            ParameterSetName = ResourceIdPartnerTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public long StorageQueueMessageTtl { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.AdvancedFilterHelp,
            ParameterSetName = PartnerTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.AdvancedFilterHelp,
            ParameterSetName = ResourceIdPartnerTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public Hashtable[] AdvancedFilter { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.AdvancedFilteringOnArraysHelp,
            ParameterSetName = PartnerTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.AdvancedFilteringOnArraysHelp,
            ParameterSetName = ResourceIdPartnerTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AdvancedFilteringOnArray { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = PartnerTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = ResourceIdPartnerTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] IncludedEventType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = PartnerTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = ResourceIdPartnerTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SubjectBeginsWith { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = PartnerTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = ResourceIdPartnerTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SubjectEndsWith { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SubjectCaseSensitiveHelp,
            ParameterSetName = PartnerTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.SubjectCaseSensitiveHelp,
            ParameterSetName = ResourceIdPartnerTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter SubjectCaseSensitive { get; set; }


        public override void ExecuteCmdlet()
        {
            PSEventSubscription psEventSubscription = null;
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

            if (this.ShouldProcess(eventSubscriptionName, $"Update Event Grid subscription {eventSubscriptionName} under partnerTopic {partnerTopicName}"))
            {

                bool isSubjectCaseSensitive = this.SubjectCaseSensitive.IsPresent;
                bool enableAdvancedFilteringOnArrays = this.AdvancedFilteringOnArray.IsPresent;

                if (EventGridUtils.ShouldShowEventSubscriptionWarningMessage(this.Endpoint, this.EndpointType))
                {
                    WriteWarning(EventGridConstants.EventSubscriptionHandshakeValidationMessage);
                }

                if (this.IncludedEventType != null && this.IncludedEventType.Length == 1 && string.Equals(this.IncludedEventType[0], "All", StringComparison.OrdinalIgnoreCase))
                {
                    // Show Warning message for user
                    this.IncludedEventType = null;
                    WriteWarning(EventGridConstants.IncludedEventTypeDeprecationMessage);
                }

                EventSubscription eventSubscription = this.Client.UpdatePartnerTopicEventSubscription(
                    eventSubscriptionName,
                    resourceGroupName,
                    partnerTopicName,
                    this.DeadLetterEndpoint,
                    this.DeliveryAttributeMapping,
                    this.Endpoint,
                    this.EndpointType,
                    this.Label,
                    this.StorageQueueMessageTtl,
                    this.AdvancedFilter,
                    enableAdvancedFilteringOnArrays,
                    this.IncludedEventType,
                    this.SubjectBeginsWith,
                    this.SubjectEndsWith,
                    isSubjectCaseSensitive);

                psEventSubscription = new PSEventSubscription(eventSubscription);
                
            }
            this.WriteObject(psEventSubscription, true);
        }
    }
}
