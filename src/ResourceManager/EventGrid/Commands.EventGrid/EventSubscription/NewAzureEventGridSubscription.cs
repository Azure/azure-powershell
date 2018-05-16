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
using Microsoft.Azure.Commands.EventGrid.Models;
using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(
        VerbsCommon.New,
        EventGridEventSubscriptionVerb,
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

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = EventGridConstants.TopicInputObject,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSTopic InputObject { get; set; }

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
            Position = 1,
            HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            Position = 1,
            HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
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
            Position = 2,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            Position = 2,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Endpoint { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
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
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 4,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            Position = 3,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateSet(EventGridConstants.Webhook, EventGridConstants.EventHub, EventGridConstants.StorageQueue, EventGridConstants.HybridConnection, IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string EndpointType { get; set; } = EventGridConstants.Webhook;

    [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 5,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 4,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 4,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            Position = 4,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SubjectBeginsWith { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 6,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 5,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 5,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            Position = 5,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SubjectEndsWith { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectCaseSensitiveHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
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
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter SubjectCaseSensitive { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 7,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 6,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 6,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            Position = 6,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] IncludedEventType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 8,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 7,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 7,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            Position = 7,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] Label { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 9,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 8,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 8,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            Position = 8,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateRange(1, 1440)]
        public int? EventTtl { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 10,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptsHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 9,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptsHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 9,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptsHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            Position = 9,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptsHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateRange(1, 30)]
        public int? MaxDeliveryAttempts { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 11,
            HelpMessage = EventGridConstants.DeliverySchemaHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 10,
            HelpMessage = EventGridConstants.DeliverySchemaHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 10,
            HelpMessage = EventGridConstants.DeliverySchemaHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            Position = 10,
            HelpMessage = EventGridConstants.DeliverySchemaHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateSet(EventDeliverySchema.EventGridSchema, EventDeliverySchema.InputEventSchema, EventDeliverySchema.CloudEventV01Schema, IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string DeliverySchema { get; set; } = EventDeliverySchema.EventGridSchema;

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 12,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 11,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 11,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            Position = 11,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DeadLetterEndpoint { get; set; }

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
                else
                {
                    // ResourceID not specified, build the scope for the event subscription for either the 
                    // subscription, or resource group, or custom topic depending on which of the parameters are provided.
                    scope = EventGridUtils.GetScope(this.DefaultContext.Subscription.Id, this.ResourceGroupName, this.TopicName);
                }

                if (this.MaxDeliveryAttempts.HasValue || this.EventTtl.HasValue)
                {
                    retryPolicy = new RetryPolicy(this.MaxDeliveryAttempts, this.EventTtl);
                }

                if (EventGridUtils.ShouldShowEventSubscriptionWarningMessage(this.Endpoint, this.EndpointType))
                {
                    WriteWarning(EventGridConstants.EventSubscriptionHandshakeValidationMessage);
                }

                EventSubscription eventSubscription = this.Client.CreateEventSubscription(scope,
                    this.EventSubscriptionName, this.Endpoint, this.EndpointType, this.SubjectBeginsWith,
                    this.SubjectEndsWith, isSubjectCaseSensitive, this.IncludedEventType, this.Label, retryPolicy, this.DeliverySchema,
                    this.DeadLetterEndpoint);

                PSEventSubscription psEventSubscription = new PSEventSubscription(eventSubscription);
                this.WriteObject(psEventSubscription, true);
            }
        }
    }
}
