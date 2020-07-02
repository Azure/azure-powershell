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
using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(
        "New",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridSubscription",
        SupportsShouldProcess = true,
        DefaultParameterSetName = ResourceGroupNameParameterSet),
    OutputType(typeof(PSEventSubscription))]

    public class NewAzureEventGridSubscription : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.ResourceIdNameHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = EventGridConstants.TopicInputObjectHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSTopic InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = EventGridConstants.DomainInputObjectHelp,
            ParameterSetName = EventSubscriptionDomainInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSDomain DomainInputObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = EventGridConstants.DomainTopicInputObjectHelp,
            ParameterSetName = EventSubscriptionDomainTopicInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSDomainTopic DomainTopicInputObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            Position = 1,
            HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            Position = 1,
            HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
            ParameterSetName = EventSubscriptionDomainInputObjectParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            Position = 1,
            HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
            ParameterSetName = EventSubscriptionDomainTopicInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string EventSubscriptionName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            Position = 2,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            Position = 2,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            Position = 2,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = EventSubscriptionDomainInputObjectParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            Position = 2,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = EventSubscriptionDomainTopicInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Endpoint { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = EventGridConstants.TopicNameOfTheEventSubscriptionHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string TopicName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = EventGridConstants.DomainNameForEventSubscriptionHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = EventGridConstants.DomainNameHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DomainName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DomainTopicNameForEventSubscriptionHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DomainTopicName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = EventSubscriptionDomainInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = EventSubscriptionDomainTopicInputObjectParameterSet)]
        [ValidateSet(EventGridConstants.Webhook, EventGridConstants.EventHub, EventGridConstants.StorageQueue, EventGridConstants.HybridConnection, EventGridConstants.ServiceBusQueue, EventGridConstants.ServiceBusTopic, EventGridConstants.AzureFunction, IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string EndpointType { get; set; } = EventGridConstants.Webhook;

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = EventSubscriptionDomainInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = EventSubscriptionDomainTopicInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SubjectBeginsWith { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = EventSubscriptionDomainInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = EventSubscriptionDomainTopicInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SubjectEndsWith { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectCaseSensitiveHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectCaseSensitiveHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectCaseSensitiveHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectCaseSensitiveHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectCaseSensitiveHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectCaseSensitiveHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectCaseSensitiveHelp,
            ParameterSetName = EventSubscriptionDomainInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectCaseSensitiveHelp,
            ParameterSetName = EventSubscriptionDomainTopicInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter SubjectCaseSensitive { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = EventSubscriptionDomainInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = EventSubscriptionDomainTopicInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] IncludedEventType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = EventSubscriptionDomainInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = EventSubscriptionDomainTopicInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] Label { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = EventSubscriptionDomainInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = EventSubscriptionDomainTopicInputObjectParameterSet)]
        [ValidateRange(1, 1440)]
        public int EventTtl { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptHelp,
            ParameterSetName = EventSubscriptionDomainInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptHelp,
            ParameterSetName = EventSubscriptionDomainTopicInputObjectParameterSet)]
        [ValidateRange(1, 30)]
        public int MaxDeliveryAttempt { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DeliverySchemaHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DeliverySchemaHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DeliverySchemaHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DeliverySchemaHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DeliverySchemaHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.DeliverySchemaHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.DeliverySchemaHelp,
            ParameterSetName = EventSubscriptionDomainInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.DeliverySchemaHelp,
            ParameterSetName = EventSubscriptionDomainTopicInputObjectParameterSet)]
        [ValidateSet(EventDeliverySchema.EventGridSchema, EventDeliverySchema.CustomInputSchema, EventDeliverySchema.CloudEventSchemaV10, IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string DeliverySchema { get; set; } = EventDeliverySchema.EventGridSchema;

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = EventSubscriptionDomainInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = EventSubscriptionDomainTopicInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DeadLetterEndpoint { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.ExpirationDateHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.ExpirationDateHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.ExpirationDateHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.ExpirationDateHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.ExpirationDateHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.ExpirationDateHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.ExpirationDateHelp,
            ParameterSetName = EventSubscriptionDomainInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.ExpirationDateHelp,
            ParameterSetName = EventSubscriptionDomainTopicInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public DateTime ExpirationDate { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AdvancedFilterHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AdvancedFilterHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AdvancedFilterHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AdvancedFilterHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AdvancedFilterHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AdvancedFilterHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AdvancedFilterHelp,
            ParameterSetName = EventSubscriptionDomainInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AdvancedFilterHelp,
            ParameterSetName = EventSubscriptionDomainTopicInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public Hashtable[] AdvancedFilter { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.MaxEventsPerBatchHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.MaxEventsPerBatchHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.MaxEventsPerBatchHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.MaxEventsPerBatchHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.MaxEventsPerBatchHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.MaxEventsPerBatchHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.MaxEventsPerBatchHelp,
            ParameterSetName = EventSubscriptionDomainInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.MaxEventsPerBatchHelp,
            ParameterSetName = EventSubscriptionDomainTopicInputObjectParameterSet)]
        [ValidateRange(1, 5000)]
        public int MaxEventsPerBatch { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PreferredBatchSizeInKiloBytesHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PreferredBatchSizeInKiloBytesHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PreferredBatchSizeInKiloBytesHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PreferredBatchSizeInKiloBytesHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PreferredBatchSizeInKiloBytesHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.PreferredBatchSizeInKiloBytesHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.PreferredBatchSizeInKiloBytesHelp,
            ParameterSetName = EventSubscriptionDomainInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.PreferredBatchSizeInKiloBytesHelp,
            ParameterSetName = EventSubscriptionDomainTopicInputObjectParameterSet)]
        [ValidateRange(1, 1024)]
        public int PreferredBatchSizeInKiloBytes { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.EventSubscriptionName, $"Create a new Event Grid subscription {this.EventSubscriptionName}"))
            {
                string scope;
                bool isSubjectCaseSensitive = this.SubjectCaseSensitive.IsPresent;
                RetryPolicy retryPolicy = null;

                if (!string.IsNullOrEmpty(this.ResourceId))
                {
                    scope = this.ResourceId;
                }
                else if (this.InputObject != null)
                {
                    scope = this.InputObject.Id;
                }
                else if (this.DomainInputObject != null)
                {
                    scope = this.DomainInputObject.Id;
                }
                else if (this.DomainTopicInputObject != null)
                {
                    scope = this.DomainTopicInputObject.Id;
                }
                else
                {
                    // ResourceID not specified, build the scope for the event subscription for either the 
                    // subscription, or resource group, or custom topic depending on which of the parameters are provided.

                    scope = EventGridUtils.GetScope(
                        this.DefaultContext.Subscription.Id,
                        this.ResourceGroupName,
                        this.TopicName,
                        this.DomainName,
                        this.DomainTopicName);
                }

                if (this.IsParameterBound(c => c.MaxDeliveryAttempt) || this.IsParameterBound(c => c.EventTtl))
                {
                    retryPolicy = new RetryPolicy(
                        maxDeliveryAttempts: this.MaxDeliveryAttempt == 0 ? (int?) null : this.MaxDeliveryAttempt,
                        eventTimeToLiveInMinutes: this.EventTtl == 0 ? (int?) null : this.EventTtl);
                }

                if (!string.Equals(this.EndpointType, EventGridConstants.Webhook, StringComparison.OrdinalIgnoreCase) && 
                    (this.IsParameterBound(c => c.MaxEventsPerBatch) || this.IsParameterBound(c => c.PreferredBatchSizeInKiloBytes)))
                {
                    throw new ArgumentException("MaxEventsPerBatch and PreferredBatchSizeInKiloBytes are supported when EndpointType is webhook only.");
                }

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

                EventSubscription eventSubscription = this.Client.CreateEventSubscription(
                    scope,
                    this.EventSubscriptionName,
                    this.Endpoint,
                    this.EndpointType,
                    this.SubjectBeginsWith,
                    this.SubjectEndsWith,
                    isSubjectCaseSensitive,
                    this.IncludedEventType,
                    this.Label,
                    retryPolicy,
                    this.DeliverySchema,
                    this.DeadLetterEndpoint,
                    this.ExpirationDate,
                    this.AdvancedFilter,
                    this.MaxEventsPerBatch,
                    this.PreferredBatchSizeInKiloBytes);

                PSEventSubscription psEventSubscription = new PSEventSubscription(eventSubscription);
                this.WriteObject(psEventSubscription, true);
            }
        }
    }
}
