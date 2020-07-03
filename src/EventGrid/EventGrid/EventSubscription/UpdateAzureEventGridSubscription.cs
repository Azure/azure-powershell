﻿// ----------------------------------------------------------------------------------
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
        "Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridSubscription",
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

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = EventGridConstants.EventSubscriptionInputObjectHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
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
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
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
            Position = 2,
            HelpMessage = EventGridConstants.TopicNameOfTheEventSubscriptionHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string TopicName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = EventGridConstants.DomainNameOfTheEventSubscriptionHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = EventGridConstants.DomainNameHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DomainName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = EventGridConstants.DomainTopicNameOfTheEventSubscriptionHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DomainTopicName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
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
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [ValidateSet(EventGridConstants.Webhook, EventGridConstants.EventHub, EventGridConstants.StorageQueue, EventGridConstants.HybridConnection, EventGridConstants.ServiceBusQueue, EventGridConstants.ServiceBusTopic, EventGridConstants.AzureFunction, IgnoreCase = true)]
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
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Endpoint { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
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
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        public string SubjectBeginsWith { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
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
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        public string SubjectEndsWith { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
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
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] IncludedEventType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
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
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] Label { get; set; }

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
        [ValidateNotNullOrEmpty]
        public Hashtable[] AdvancedFilter { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [ValidateRange(1, 1440)]
        public int EventTtl { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [ValidateRange(1, 30)]
        public int MaxDeliveryAttempt { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DeadLetterEndpoint { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.MaxEventsPerBatchHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.MaxEventsPerBatchHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.MaxEventsPerBatchHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.MaxEventsPerBatchHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.MaxEventsPerBatchHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.MaxEventsPerBatchHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [ValidateRange(1, 5000)]
        public int MaxEventsPerBatch { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.PreferredBatchSizeInKiloByteHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.PreferredBatchSizeInKiloByteHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.PreferredBatchSizeInKiloByteHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.PreferredBatchSizeInKiloByteHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.PreferredBatchSizeInKiloByteHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.PreferredBatchSizeInKiloByteHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [ValidateRange(1, 1024)]
        public int PreferredBatchSizeInKiloByte { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AzureActiveDirectoryApplicationIdOrUriHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AzureActiveDirectoryApplicationIdOrUriHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AzureActiveDirectoryApplicationIdOrUriHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AzureActiveDirectoryApplicationIdOrUriHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AzureActiveDirectoryApplicationIdOrUriHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AzureActiveDirectoryApplicationIdOrUriHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Alias(AliasAadAppIdUri)]
        public string AzureActiveDirectoryApplicationIdOrUri { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AzureActiveDirectoryTenantIdHelp,
            ParameterSetName = CustomTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AzureActiveDirectoryTenantIdHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AzureActiveDirectoryTenantIdHelp,
            ParameterSetName = DomainTopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AzureActiveDirectoryTenantIdHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AzureActiveDirectoryTenantIdHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = EventGridConstants.AzureActiveDirectoryTenantIdHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Alias(AliasAadTenantId)]
        public string AzureActiveDirectoryTenantId { get; set; }

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
                int? maxEventsPerBatch = null;
                int? preferredBatchSizeInKiloByte = null;
                string aadAppIdOrUri = string.Empty;
                string aadTenantId = string.Empty;

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

                    scope = EventGridUtils.GetScope(
                        this.DefaultContext.Subscription.Id,
                        this.ResourceGroupName,
                        this.TopicName,
                        this.DomainName,
                        this.DomainTopicName);
                }

                EventSubscription existingEventSubscription = this.Client.GetEventSubscription(scope, this.EventSubscriptionName);
                if (existingEventSubscription == null)
                {
                    throw new Exception($"Cannot find an existing event subscription with name {this.EventSubscriptionName}.");
                }

                if (this.IsParameterBound(c => c.MaxDeliveryAttempt) || this.IsParameterBound(c => c.EventTtl))
                {
                    retryPolicy = new RetryPolicy(existingEventSubscription.RetryPolicy?.MaxDeliveryAttempts, existingEventSubscription.RetryPolicy?.EventTimeToLiveInMinutes);

                    // Only override the new values if any.
                    if (this.IsParameterBound(c => c.MaxDeliveryAttempt))
                    {
                        retryPolicy.MaxDeliveryAttempts = this.MaxDeliveryAttempt;
                    }

                    if (this.IsParameterBound(c => c.EventTtl))
                    {
                        retryPolicy.EventTimeToLiveInMinutes = this.EventTtl;
                    }
                }
                else
                {
                    retryPolicy = existingEventSubscription.RetryPolicy;
                }

                if (string.Equals(this.EndpointType, EventGridConstants.Webhook, StringComparison.OrdinalIgnoreCase))
                {
                    WebHookEventSubscriptionDestination dest = existingEventSubscription.Destination as WebHookEventSubscriptionDestination;
                    if (dest != null)
                    {
                        maxEventsPerBatch = this.IsParameterBound(c => c.MaxEventsPerBatch) ? (int?)this.MaxEventsPerBatch : dest.MaxEventsPerBatch.HasValue ? dest.MaxEventsPerBatch : null;
                        preferredBatchSizeInKiloByte = this.IsParameterBound(c => c.PreferredBatchSizeInKiloByte) ? (int?)this.PreferredBatchSizeInKiloByte : dest.PreferredBatchSizeInKilobytes.HasValue ? dest.PreferredBatchSizeInKilobytes : null;
                        aadAppIdOrUri = this.IsParameterBound(c => c.AzureActiveDirectoryApplicationIdOrUri) ? this.AzureActiveDirectoryApplicationIdOrUri : dest.AzureActiveDirectoryApplicationIdOrUri;
                        aadTenantId = this.IsParameterBound(c => c.AzureActiveDirectoryTenantId) ? this.AzureActiveDirectoryTenantId : dest.AzureActiveDirectoryTenantId;
                    }
                    else
                    {
                        maxEventsPerBatch = this.IsParameterBound(c => c.MaxEventsPerBatch) ? (int?)this.MaxEventsPerBatch : null;
                        preferredBatchSizeInKiloByte = this.IsParameterBound(c => c.PreferredBatchSizeInKiloByte) ? (int?)this.PreferredBatchSizeInKiloByte : null;
                        aadAppIdOrUri = this.IsParameterBound(c => c.AzureActiveDirectoryApplicationIdOrUri) ? this.AzureActiveDirectoryApplicationIdOrUri : string.Empty;
                        aadTenantId = this.IsParameterBound(c => c.AzureActiveDirectoryTenantId) ? this.AzureActiveDirectoryTenantId : string.Empty;
                    }
                }
                else
                {
                    if (this.IsParameterBound(c => c.MaxEventsPerBatch) || this.IsParameterBound(c => c.PreferredBatchSizeInKiloByte))
                    {
                        throw new ArgumentException("MaxEventsPerBatch and PreferredBatchSizeInKiloByte are supported when EndpointType is webhook only.");
                    }

                    if (this.IsParameterBound(c => c.AzureActiveDirectoryApplicationIdOrUri) || this.IsParameterBound(c => c.AzureActiveDirectoryTenantId))
                    {
                        throw new ArgumentException("AzureActiveDirectoryApplicationIdOrUri and AzureActiveDirectoryTenantId are supported when EndpointType is webhook only.");
                    }
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
                    deadLetterEndpoint: this.DeadLetterEndpoint,
                    expirationDate: this.ExpirationDate,
                    advancedFilter: this.AdvancedFilter,
                    maxEventsPerBatch: maxEventsPerBatch,
                    preferredBatchSizeInKiloByte: preferredBatchSizeInKiloByte,
                    aadAppIdOrUri: aadAppIdOrUri,
                    aadTenantId: aadTenantId);

                PSEventSubscription psEventSubscription = new PSEventSubscription(eventSubscription);
                this.WriteObject(psEventSubscription);
            }
        }
    }
}
