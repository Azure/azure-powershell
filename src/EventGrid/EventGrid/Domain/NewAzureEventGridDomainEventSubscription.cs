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
        "New",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridDomainEventSubscription",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DomainNameParameterSet),
    OutputType(typeof(PSEventSubscription))]

    public class NewAzureEventGridDomainEventSubscription : AzureEventGridCmdletBase
    {
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
           ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("EventSubscriptionName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DomainNameHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.EventGrid/domains", nameof(ResourceGroupName))]
        public string DomainName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.AzureActiveDirectoryApplicationIdOrUriHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AzureActiveDirectoryApplicationIdOrUri { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.AzureActiveDirectoryTenantIdHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AzureActiveDirectoryTenantId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DeadletterEndpointHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DeadLetterEndpoint { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DeliveryAttributeMappingHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] DeliveryAttributeMapping { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EndpointHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Endpoint { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EndpointTypeHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string EndpointType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DeliverySchemaHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DeliverySchema { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EventTtlHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public int EventTtl { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ExpirationDateHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public DateTime ExpirationDate { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.LabelsHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] Label { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.MaxDeliveryAttemptHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public int MaxDeliveryAttempt { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.MaxEventsPerBatchHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public int MaxEventsPerBatch { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PreferredBatchSizeInKiloByteHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public int PreferredBatchSizeInKiloByte { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.StorageQueueMessageTtlHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public long StorageQueueMessageTtl { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.AdvancedFilterHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public Hashtable[] AdvancedFilter { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.AdvancedFilteringOnArraysHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AdvancedFilteringOnArray { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IncludedEventTypesHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string[] IncludedEventType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SubjectBeginsWithHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SubjectBeginsWith { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SubjectEndsWithHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SubjectEndsWith { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SubjectCaseSensitiveHelp,
            ParameterSetName = DomainEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter SubjectCaseSensitive { get; set; }


        public override void ExecuteCmdlet()
        {
            PSEventSubscription psEventSubscription = null;
            if (this.ShouldProcess(this.Name, $"Create a new Event Grid subscription {this.Name} under domain {this.DomainName}"))
            {

                bool isSubjectCaseSensitive = this.SubjectCaseSensitive.IsPresent;
                bool enableAdvancedFilteringOnArrays = this.AdvancedFilteringOnArray.IsPresent;
                RetryPolicy retryPolicy = null;


                if (this.IsParameterBound(c => c.MaxDeliveryAttempt) || this.IsParameterBound(c => c.EventTtl))
                {
                    retryPolicy = new RetryPolicy(
                        maxDeliveryAttempts: this.MaxDeliveryAttempt == 0 ? (int?)null : this.MaxDeliveryAttempt,
                        eventTimeToLiveInMinutes: this.EventTtl == 0 ? (int?)null : this.EventTtl);
                }

                if (!string.Equals(this.EndpointType, EventGridConstants.Webhook, StringComparison.OrdinalIgnoreCase))
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

                EventSubscription eventSubscription = this.Client.CreateDomainEventSubscription(
                    this.Name,
                    this.ResourceGroupName,
                    this.DomainName,
                    this.AzureActiveDirectoryApplicationIdOrUri,
                    this.AzureActiveDirectoryTenantId,
                    this.DeadLetterEndpoint,
                    this.DeliveryAttributeMapping,
                    this.Endpoint,
                    this.EndpointType,
                    this.DeliverySchema,
                    retryPolicy,
                    this.ExpirationDate,
                    this.Label,
                    this.MaxEventsPerBatch,
                    this.PreferredBatchSizeInKiloByte,
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
