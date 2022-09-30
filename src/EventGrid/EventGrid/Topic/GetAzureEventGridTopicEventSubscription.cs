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
        DefaultParameterSetName = TopicNameParameterSet),
    OutputType(typeof(PSEventSubscription), typeof(PSEventSubscriptionListInstance))]

    public class GetAzureEventGridTopicEventSubscription : AzureEventGridCmdletBase
    {
        [Parameter(
           Mandatory = false,
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
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
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
            HelpMessage = EventGridConstants.EventSubscriptionFullUrlInResponseHelp,
            ParameterSetName = TopicEventSuscriptionParameterSet)]
        public SwitchParameter IncludeFullEndpointUrl { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = TopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ODataQuery { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopHelp,
            ParameterSetName = TopicEventSuscriptionParameterSet)]
        [ValidateRange(1, 100)]
        public int? Top { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.NextLinkHelp,
            ParameterSetName = TopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string NextLink { get; set; }

        public override void ExecuteCmdlet()
        {
            string newNextLink = null;
            int? providedTop = null;
            bool includeFullEndpointUrl = this.IncludeFullEndpointUrl.IsPresent;

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                throw new ArgumentNullException(
                    this.ResourceGroupName,
                    "Resource Group Name should be specified to retrieve event subscriptions for a topic");
            }

            if (string.IsNullOrEmpty(this.TopicName))
            {
                throw new ArgumentNullException(
                    this.TopicName,
                    "Topic Name should be specified to retrieve event subscriptions for a topic");
            }

            if (MyInvocation.BoundParameters.ContainsKey(nameof(this.Top)))
            {
                providedTop = this.Top;
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                EventSubscription eventSubscription = this.Client.GetTopicEventSubscriptiion(this.ResourceGroupName, this.TopicName, this.Name);
                PSEventSubscription psEventSubscription;

                if (includeFullEndpointUrl &&
                    eventSubscription.Destination is WebHookEventSubscriptionDestination)
                {
                    EventSubscriptionFullUrl fullUrl = this.Client.GetAzFullUrlForTopicEventSubscription(this.ResourceGroupName, this.TopicName, this.Name);
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
                    (eventSubscriptionsList, newNextLink) = this.Client.ListTopicEventSubscriptions(this.ResourceGroupName, this.TopicName, this.ODataQuery, providedTop);
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
