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
        "Get",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridTopicEventSubscription",
        DefaultParameterSetName = TopicEventSubscriptionParameterSet),
    OutputType(typeof(PSEventSubscription), typeof(PSEventSubscriptionListInstance))]

    public class GetAzureEventGridTopicEventSubscription : AzureEventGridCmdletBase
    {
        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
           ParameterSetName = TopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.EventGrid/topics/eventSubscriptions", nameof(ResourceGroupName), nameof(TopicName))]
        [Alias("EventSubscriptionName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = TopicEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = TopicNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopicNameHelp,
            ParameterSetName = TopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.EventGrid/topics", nameof(ResourceGroupName))]
        public string TopicName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.EventSubscriptionResourceIdHelp,
            ParameterSetName = ResourceIdTopicEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.EventSubscriptionFullUrlInResponseHelp,
            ParameterSetName = TopicEventSubscriptionParameterSet)]
        public SwitchParameter IncludeFullEndpointUrl { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = TopicNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ODataQuery { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopHelp,
            ParameterSetName = TopicNameParameterSet)]
        [ValidateRange(1, 100)]
        public int? Top { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.NextLinkHelp,
            ParameterSetName = TopicNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string NextLink { get; set; }

        public override void ExecuteCmdlet()
        {
            string newNextLink = null;
            int? providedTop = null;
            bool includeFullEndpointUrl = this.IncludeFullEndpointUrl.IsPresent;
            string resourceGroupName = string.Empty;
            string topicName = string.Empty;
            string eventSubscriptionName = string.Empty;

            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                EventGridUtils.GetResourceGroupNameAndTopicNameAndEventSubscriptionName(
                    this.ResourceId,
                    out resourceGroupName,
                    out topicName,
                    out eventSubscriptionName);
            }
            else
            {
                resourceGroupName = this.ResourceGroupName;
                topicName = this.TopicName;
                eventSubscriptionName = this.Name;
            }

            if (string.IsNullOrEmpty(resourceGroupName))
            {
                throw new ArgumentNullException(
                    resourceGroupName,
                    "Resource Group Name should be specified to retrieve event subscriptions for a topic");
            }

            if (string.IsNullOrEmpty(topicName))
            {
                throw new ArgumentNullException(
                    topicName,
                    "Topic Name should be specified to retrieve event subscriptions for a topic");
            }

            if (MyInvocation.BoundParameters.ContainsKey(nameof(this.Top)))
            {
                providedTop = this.Top;
            }

            if (!string.IsNullOrEmpty(eventSubscriptionName))
            {
                EventSubscription eventSubscription = this.Client.GetTopicEventSubscription(resourceGroupName, topicName, eventSubscriptionName);
                PSEventSubscription psEventSubscription;

                if (includeFullEndpointUrl &&
                    eventSubscription.Destination is WebHookEventSubscriptionDestination)
                {
                    EventSubscriptionFullUrl fullUrl = this.Client.GetAzFullUrlForTopicEventSubscription(resourceGroupName, topicName, eventSubscriptionName);
                    psEventSubscription = new PSEventSubscription(eventSubscription, fullUrl.EndpointUrl);
                }
                else
                {
                    psEventSubscription = new PSEventSubscription(eventSubscription);
                }

                this.WriteObject(psEventSubscription);
            }
            else
            {
                // EventSubscription name was not specified, we need to retrieve a list of
                // event subscriptions based on the provided parameters.
                IEnumerable<EventSubscription> eventSubscriptionsList = null;

                // Other parameters should be null or ignored if this.NextLink is specified.
                if (!string.IsNullOrEmpty(this.NextLink))
                {
                    (eventSubscriptionsList, newNextLink) = this.Client.ListTopicEventSubscriptionsNext(this.NextLink);
                }
                else
                {
                    (eventSubscriptionsList, newNextLink) = this.Client.ListTopicEventSubscriptions(resourceGroupName, topicName, this.ODataQuery, providedTop);
                }

                this.WritePSEventSubscriptionsList(eventSubscriptionsList, includeFullEndpointUrl, newNextLink);
            }
        }

        void WritePSEventSubscriptionsList(IEnumerable<EventSubscription> eventSubscriptionsList, bool includeFullEndpointUrl, string nextLink)
        {
            if (eventSubscriptionsList == null)
            {
                return;
            }

            PSEventSubscriptionListPagedInstance pSTopicListPagedInstance = new PSEventSubscriptionListPagedInstance(eventSubscriptionsList, this.Client, includeFullEndpointUrl, nextLink);
            this.WriteObject(pSTopicListPagedInstance, true);
        }
    }
}
