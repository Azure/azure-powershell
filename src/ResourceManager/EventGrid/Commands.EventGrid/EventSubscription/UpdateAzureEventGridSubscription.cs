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
using System.Management.Automation;
using Microsoft.Azure.Commands.EventGrid.Models;
using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(
        VerbsData.Update,
        EventGridEventSubscriptionVerb,
        SupportsShouldProcess = true,
        DefaultParameterSetName = ResourceGroupNameParameterSet),
     OutputType(typeof(PSEventSubscription))]
    public class UpdateAzureEventGridSubscription : AzureEventGridCmdletBase
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
            HelpMessage = EventGridConstants.EventSubscriptionInputObject,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSEventSubscription InputObject { get; set; }

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
        public string EventSubscriptionName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
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
            Position = 2,
            HelpMessage = EventGridConstants.TopicNameOfTheEventSubscriptionHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string TopicName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateSet(EventGridConstants.Webhook, EventGridConstants.EventHub, EventGridConstants.StorageQueue, EventGridConstants.HybridConnection, IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string EndpointType { get; set; } = EventGridConstants.Webhook;

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Endpoint { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SubjectBeginsWith { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SubjectEndsWith { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] IncludedEventType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] Label { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            Position = 1,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateRange(1, 1440)]
        public int? EventTtl { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 4,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptsHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptsHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptsHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            Position = 2,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptsHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateRange(1, 30)]
        public int? MaxDeliveryAttempts { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 5,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 4,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            Position = 3,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DeadLetterEndpoint { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(this.EventSubscriptionName))
            {
                // This can happen with the InputObject parameter set where the
                // event subscription name needs to be determined based on the piped in
                // EventSubscriptionObject
                if (this.InputObject == null)
                {
                    throw new Exception("Unexpected condition: Event Subscription name cannot be determined.");
                }

                this.EventSubscriptionName = this.InputObject.EventSubscriptionName;
            }

            if (this.ShouldProcess(this.EventSubscriptionName, $"Update existing Event Grid subscription {this.EventSubscriptionName}"))
            {
                string scope;
                RetryPolicy retryPolicy = null;

                if (!string.IsNullOrEmpty(this.ResourceId))
                {
                    scope = this.ResourceId;
                }
                else if (this.InputObject != null)
                {
                    scope = this.InputObject.Topic;
                }
                else
                {
                    // ResourceID not specified, build the scope for the event subscription for either the
                    // subscription, or resource group, or custom topic depending on which of the parameters are provided.
                    scope = EventGridUtils.GetScope(this.DefaultContext.Subscription.Id, this.ResourceGroupName, this.TopicName);
                }

                EventSubscription existingEventSubscription = this.Client.GetEventSubscription(scope, this.EventSubscriptionName);
                if (existingEventSubscription == null)
                {
                    throw new Exception($"Cannot find an existing event subscription with name {this.EventSubscriptionName}.");
                }

                if (this.MaxDeliveryAttempts.HasValue || this.EventTtl.HasValue)
                {
                    retryPolicy = new RetryPolicy(existingEventSubscription.RetryPolicy?.MaxDeliveryAttempts, existingEventSubscription.RetryPolicy?.EventTimeToLiveInMinutes);

                    // Only override the new values if any.
                    if (this.MaxDeliveryAttempts.HasValue)
                    {
                        retryPolicy.MaxDeliveryAttempts = this.MaxDeliveryAttempts;
                    }

                    if (this.EventTtl.HasValue)
                    {
                        retryPolicy.EventTimeToLiveInMinutes = this.EventTtl;
                    }
                }
                else
                {
                    retryPolicy = existingEventSubscription.RetryPolicy;
                }

                if (EventGridUtils.ShouldShowEventSubscriptionWarningMessage(this.Endpoint, this.EndpointType))
                {
                    WriteWarning(EventGridConstants.EventSubscriptionHandshakeValidationMessage);
                }

                EventSubscription eventSubscription = this.Client.UpdateEventSubscription(
                    scope: scope,
                    eventSubscriptionName: this.EventSubscriptionName,
                    endpoint: this.Endpoint,
                    endpointType: this.EndpointType,
                    subjectBeginsWith: this.SubjectBeginsWith ?? existingEventSubscription.Filter.SubjectBeginsWith,
                    subjectEndsWith: this.SubjectEndsWith ?? existingEventSubscription.Filter.SubjectEndsWith,
                    isSubjectCaseSensitive: existingEventSubscription.Filter.IsSubjectCaseSensitive,
                    includedEventTypes: this.IncludedEventType,
                    labels: this.Label,
                    retryPolicy: retryPolicy,
                    deadLetterEndpoint: this.DeadLetterEndpoint);

                PSEventSubscription psEventSubscription = new PSEventSubscription(eventSubscription);
                this.WriteObject(psEventSubscription);
            }
        }
    }
}
