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
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridTopicEventSubscription",
        SupportsShouldProcess = true,
        DefaultParameterSetName = TopicNameParameterSet),
    OutputType(typeof(PSEventSubscription))]

    public class UpdateAzureEventGridTopicEventSubscription : AzureEventGridCmdletBase
    {
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
           ParameterSetName = TopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("EventSubscriptionName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = TopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopicNameHelp,
            ParameterSetName = TopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.EventGrid/topics", nameof(ResourceGroupName))]
        public string TopicName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = TopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DeadLetterEndpoint { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DeliveryAttributeMappingHelp,
            ParameterSetName = TopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] DeliveryAttributeMapping { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = TopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Endpoint { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = TopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string EndpointType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = TopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] Label { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.StorageQueueMessageTtlHelp,
            ParameterSetName = TopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public long StorageQueueMessageTtl { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.AdvancedFilterHelp,
            ParameterSetName = TopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public Hashtable[] AdvancedFilter { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.AdvancedFilteringOnArraysHelp,
            ParameterSetName = TopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AdvancedFilteringOnArray { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = TopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] IncludedEventType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = TopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SubjectBeginsWith { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = TopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SubjectEndsWith { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SubjectCaseSensitiveHelp,
            ParameterSetName = TopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter SubjectCaseSensitive { get; set; }


        public override void ExecuteCmdlet()
        {
            PSEventSubscription psEventSubscription = null;
            if (this.ShouldProcess(this.Name, $"Update Event Grid subscription {this.Name} under topic {this.TopicName}"))
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

                EventSubscription eventSubscription = this.Client.UpdateTopicEventSubscriptiion(
                    this.Name,
                    this.ResourceGroupName,
                    this.TopicName,
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
