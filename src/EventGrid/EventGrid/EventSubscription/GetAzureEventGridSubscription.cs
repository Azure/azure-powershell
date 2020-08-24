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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.EventGrid.Models;
using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(
        "Get",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridSubscription",
        DefaultParameterSetName = EventSubscriptionTopicNameParameterSet),
    OutputType(typeof(PSEventSubscription))]

    public class GetAzureRmEventGridSubscription : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
            ParameterSetName = EventSubscriptionTopicNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
            ParameterSetName = EventSubscriptionDomainNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string EventSubscriptionName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = EventSubscriptionTopicTypeNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = EventSubscriptionTopicNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = EventSubscriptionDomainNameParameterSet)]
        [ResourceGroupCompleter]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.ResourceIdNameHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopicNameHelp,
            ParameterSetName = EventSubscriptionTopicNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/topics", nameof(ResourceGroupName))]
        public string TopicName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DomainNameHelp,
            ParameterSetName = EventSubscriptionDomainNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/domains", nameof(ResourceGroupName))]
        public string DomainName { get; set; }

        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = EventGridConstants.DomainTopicNameHelp,
          ParameterSetName = EventSubscriptionDomainNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/domains/topics", nameof(ResourceGroupName), nameof(DomainName))]
        public string DomainTopicName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopicTypeNameHelp,
            ParameterSetName = EventSubscriptionTopicTypeNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string TopicTypeName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Location",
            ParameterSetName = EventSubscriptionTopicTypeNameParameterSet)]
        [LocationCompleter("Microsoft.EventGrid/eventSubscriptions")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

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
            Mandatory = false,
            HelpMessage = EventGridConstants.EventSubscriptionFullUrlHelp,
            ParameterSetName = EventSubscriptionTopicNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.EventSubscriptionFullUrlHelp,
            ParameterSetName = EventSubscriptionDomainNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.EventSubscriptionFullUrlHelp,
            ParameterSetName = EventSubscriptionTopicTypeNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.EventSubscriptionFullUrlInResponseHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        public SwitchParameter IncludeFullEndpointUrl { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = EventSubscriptionTopicNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = EventSubscriptionDomainNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = EventSubscriptionTopicTypeNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = EventSubscriptionDomainInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = EventSubscriptionDomainTopicInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ODataQuery { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = EventSubscriptionTopicNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = EventSubscriptionDomainNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = EventSubscriptionTopicTypeNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = EventSubscriptionCustomTopicInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = EventSubscriptionDomainInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = EventSubscriptionDomainTopicInputObjectParameterSet)]
        [ValidateRange(1, 100)]
        public int? Top { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.NextLinkHelp,
            ParameterSetName = NextLinkParameterSet)]
        [ValidateNotNullOrEmpty]
        public string NextLink { get; set; }

        public override void ExecuteCmdlet()
        {
            string scope;
            bool includeFullEndpointUrl = this.IncludeFullEndpointUrl.IsPresent;
            string newNextLink = null;
            int? providedTop = null;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(this.Top)))
            {
                providedTop = this.Top;
            }

            if (!string.IsNullOrEmpty(this.EventSubscriptionName))
            {
                // Since an EventSubscription name is specified, we need to retrieve
                // only the particular event subscription corresponding to this name.
                if (this.InputObject != null)
                {
                    // Retrieve the event subscription for the specified topic
                    scope = this.InputObject.Id;
                }
                else if (this.DomainInputObject != null)
                {
                    // Retrieve the event subscription for the specified domain
                    scope = this.DomainInputObject.Id;
                }
                else if (this.DomainTopicInputObject != null)
                {
                    // Retrieve the event subscription for the specified domain topic
                    scope = this.DomainTopicInputObject.Id;
                }
                else if (string.IsNullOrEmpty(this.ResourceId))
                {
                    // ResourceID not specified, retrieve the event subscription for either the
                    // subscription, or resource group, or custom topic depending on which of the parameters are provided.

                    scope = EventGridUtils.GetScope(
                        this.DefaultContext.Subscription.Id,
                        this.ResourceGroupName,
                        this.TopicName,
                        this.DomainName,
                        this.DomainTopicName);
                }
                else
                {
                    // Since both a ResourceId and EventSubscriptionName are specified, we need to retrieve
                    // only this particular event subscription corresponding to this resource ID.
                    scope = this.ResourceId;
                }

                this.RetrieveAndWriteEventSubscription(scope, this.EventSubscriptionName, includeFullEndpointUrl);
            }
            else
            {
                // EventSubscription name was not specified, we need to retrieve a list of
                // event subscriptions based on the provided parameters.
                IEnumerable<EventSubscription> eventSubscriptionsList = null;

                // Other parameters should be null or ignored if this.NextLink is specified.
                if (!string.IsNullOrEmpty(this.NextLink))
                {
                    (eventSubscriptionsList, newNextLink) = this.Client.ListEventSubscriptionsNext(this.NextLink);
                }
                else if (this.InputObject != null)
                {
                    // Retrieve all the event subscriptions based on the ID of the specified topic object
                    (eventSubscriptionsList, newNextLink) = this.Client.ListByResourceId(this.DefaultContext.Subscription.Id, this.InputObject.Id, this.ODataQuery, providedTop);
                }
                else if (this.DomainInputObject != null)
                {
                    // Retrieve all the event subscriptions based on the ID of the specified domain object
                    (eventSubscriptionsList, newNextLink) = this.Client.ListByResourceId(this.DefaultContext.Subscription.Id, this.DomainInputObject.Id, this.ODataQuery, providedTop);
                }
                else if (this.DomainTopicInputObject != null)
                {
                    // Retrieve all the event subscriptions based on the ID of the specified domain topic object
                    (eventSubscriptionsList, newNextLink) = this.Client.ListByResourceId(this.DefaultContext.Subscription.Id, this.DomainTopicInputObject.Id, this.ODataQuery, providedTop);
                }
                else if (!string.IsNullOrEmpty(this.ResourceId))
                {
                    (eventSubscriptionsList, newNextLink) = this.Client.ListByResourceId(this.DefaultContext.Subscription.Id, this.ResourceId, this.ODataQuery, providedTop);
                }
                else if (!string.IsNullOrEmpty(this.TopicName))
                {
                    if (string.IsNullOrEmpty(this.ResourceGroupName))
                    {
                        throw new ArgumentNullException(
                            this.ResourceGroupName,
                            "Resource Group Name should be specified to retrieve event subscriptions for a topic");
                    }

                    // Get all event subscriptions for this topic
                    (eventSubscriptionsList, newNextLink) = this.Client.ListByResource(this.ResourceGroupName, "Microsoft.EventGrid", "topics", this.TopicName, this.ODataQuery, providedTop);
                }
                else if (!string.IsNullOrEmpty(this.DomainName))
                {
                    if (string.IsNullOrEmpty(this.ResourceGroupName))
                    {
                        throw new ArgumentNullException(
                            this.ResourceGroupName,
                            "Resource Group Name should be specified to retrieve event subscriptions for a domain or domain topic");
                    }

                    // Get all event subscriptions for this domain if no domain topic name is specified.
                    if (string.IsNullOrEmpty(this.DomainTopicName))
                    {
                        (eventSubscriptionsList, newNextLink) = this.Client.ListByResource(this.ResourceGroupName, "Microsoft.EventGrid", "domains", this.DomainName, this.ODataQuery, providedTop);
                    }
                    else
                    {
                        // Get all event subscriptions for this domain topic under the domain.
                        (eventSubscriptionsList, newNextLink) = this.Client.ListByDomainTopic(this.ResourceGroupName, this.DomainName, this.DomainTopicName, this.ODataQuery, providedTop);
                    }
                }
                else if (!string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    if (string.IsNullOrEmpty(this.Location) && string.IsNullOrEmpty(this.TopicTypeName))
                    {
                        // List all global Event Grid subscriptions in the given resource group
                        (eventSubscriptionsList, newNextLink) = this.Client.ListGlobalEventSubscriptionsByResourceGroup(this.ResourceGroupName, this.ODataQuery, providedTop);
                    }
                    else if (string.IsNullOrEmpty(this.Location) && !string.IsNullOrEmpty(this.TopicTypeName))
                    {
                        (eventSubscriptionsList, newNextLink) = this.Client.ListGlobalEventSubscriptionsByResourceGroupForTopicType(this.ResourceGroupName, this.TopicTypeName, this.ODataQuery, providedTop);
                    }
                    else if (!string.IsNullOrEmpty(this.Location) && string.IsNullOrEmpty(this.TopicTypeName))
                    {
                        // List all regional Event Grid subscriptions in the given resource group
                        (eventSubscriptionsList, newNextLink) = this.Client.ListRegionalEventSubscriptionsByResourceGroup(this.ResourceGroupName, this.Location, this.ODataQuery, providedTop);
                    }
                    else if (!string.IsNullOrEmpty(this.Location) && !string.IsNullOrEmpty(this.TopicTypeName))
                    {
                        (eventSubscriptionsList, newNextLink) = this.Client.ListRegionalEventSubscriptionsByResourceGroupForTopicType(this.ResourceGroupName, this.Location, this.TopicTypeName, this.ODataQuery, providedTop);
                    }
                }
                else
                {
                    // List all Event Grid event subscriptions in the given subscription
                    if (string.IsNullOrEmpty(this.Location) && string.IsNullOrEmpty(this.TopicTypeName))
                    {
                        // List all global Event Grid subscriptions in the given resource group
                        (eventSubscriptionsList, newNextLink) = this.Client.ListGlobalEventSubscriptionsBySubscription(this.ODataQuery, providedTop);
                    }
                    else if (string.IsNullOrEmpty(this.Location) && !string.IsNullOrEmpty(this.TopicTypeName))
                    {
                        (eventSubscriptionsList, newNextLink) = this.Client.ListGlobalEventSubscriptionsBySubscriptionForTopicType(this.TopicTypeName, this.ODataQuery, providedTop);
                    }
                    else if (!string.IsNullOrEmpty(this.Location) && string.IsNullOrEmpty(this.TopicTypeName))
                    {
                        // List all regional Event Grid subscriptions in the given resource group
                        (eventSubscriptionsList, newNextLink) = this.Client.ListRegionalEventSubscriptionsBySubscription(this.Location, this.ODataQuery, providedTop);
                    }
                    else if (!string.IsNullOrEmpty(this.Location) && !string.IsNullOrEmpty(this.TopicTypeName))
                    {
                        (eventSubscriptionsList, newNextLink) = this.Client.ListRegionalEventSubscriptionsBySubscriptionForTopicType(this.Location, this.TopicTypeName, this.ODataQuery, providedTop);
                    }
                }

                this.WritePSEventSubscriptionsList(eventSubscriptionsList, includeFullEndpointUrl, newNextLink);
            }
        }

        void RetrieveAndWriteEventSubscription(string scope, string eventSubscriptionName, bool includeFullEndpointUrl)
        {
            EventSubscription eventSubscription = this.Client.GetEventSubscription(scope, eventSubscriptionName);
            PSEventSubscription psEventSubscription;

            if (includeFullEndpointUrl &&
                eventSubscription.Destination is WebHookEventSubscriptionDestination)
            {
                EventSubscriptionFullUrl fullUrl = this.Client.GetEventSubscriptionFullUrl(scope, eventSubscriptionName);
                psEventSubscription = new PSEventSubscription(eventSubscription, fullUrl.EndpointUrl);
            }
            else
            {
                psEventSubscription = new PSEventSubscription(eventSubscription);
            }

            this.WriteObject(psEventSubscription);
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
