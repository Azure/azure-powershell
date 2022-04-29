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
using System.Management.Automation;
using Microsoft.Azure.Commands.EventGrid.Models;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Commands.EventGrid.Utilities;

namespace Microsoft.Azure.Commands.EventGrid
{

    [Cmdlet(
        "Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SystemTopicEventGridSubscription",
        SupportsShouldProcess = true,
        DefaultParameterSetName = TopicNameParameterSet),
    OutputType(typeof(PSSystemTopic))]
    class UpdateAzureSystemTopicEventSubscription : AzureEventGridCmdletBase
    {

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           Position = 0,
           HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
           ParameterSetName = SystemTopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string EventSubscriptionName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = SystemTopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.TopicNameHelp,
            ParameterSetName = SystemTopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SystemTopicName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = SystemTopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DeadLetterEndpoint { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.DeliveryAttributeMappingHelp,
            ParameterSetName = SystemTopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] DeliveryAttributeMapping { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = SystemTopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Endpoint { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = SystemTopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string EndpointType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = SystemTopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] Labels { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.StorageQueueMessageTtlHelp,
            ParameterSetName = SystemTopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public long StorageQueueMessageTtl { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.AdvancedFilterHelp,
            ParameterSetName = SystemTopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public Hashtable[] AdvancedFilter { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.AdvancedFilteringOnArraysHelp,
            ParameterSetName = SystemTopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AdvancedFilteringOnArrays { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = SystemTopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] IncludedEventType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = SystemTopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SubjectBeginsWith { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = SystemTopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SubjectEndsWith { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.SubjectCaseSensitiveHelp,
            ParameterSetName = SystemTopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter SubjectCaseSensitive { get; set; }


        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.EventSubscriptionName, $"Create a new Event Grid subscription {this.EventSubscriptionName}"))
            {

                bool isSubjectCaseSensitive = this.SubjectCaseSensitive.IsPresent;
                bool enableAdvancedFilteringOnArrays = this.AdvancedFilteringOnArrays.IsPresent;

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

                EventSubscription eventSubscription = this.Client.UpdateSystemTopicEventSubscriptiion(
                    this.EventSubscriptionName,
                    this.ResourceGroupName,
                    this.SystemTopicName,
                    this.DeadLetterEndpoint,
                    this.DeliveryAttributeMapping,
                    this.Endpoint,
                    this.EndpointType,
                    this.Labels,
                    this.StorageQueueMessageTtl,
                    this.AdvancedFilter,
                    enableAdvancedFilteringOnArrays,
                    this.IncludedEventType,
                    this.SubjectBeginsWith,
                    this.SubjectEndsWith,
                    isSubjectCaseSensitive);

                PSEventSubscription psEventSubscription = new PSEventSubscription(eventSubscription);
                this.WriteObject(psEventSubscription, true);
            }
        }
    }
}
