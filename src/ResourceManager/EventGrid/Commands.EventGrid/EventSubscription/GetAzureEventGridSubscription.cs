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
        VerbsCommon.Get,
        EventGridEventSubscriptionVerb,
        DefaultParameterSetName = EventSubscriptionTopicNameParameterSet),
     OutputType(typeof(PSEventSubscription), typeof(List<PSEventSubscriptionListInstance>))]
    public class GetAzureRmEventGridSubscription : AzureEventGridCmdletBase
    {
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
            ParameterSetName = EventSubscriptionTopicNameParameterSet)]
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string EventSubscriptionName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = EventSubscriptionTopicTypeNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = EventSubscriptionTopicNameParameterSet)]
        [ResourceGroupCompleter]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.ResourceIdNameHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = EventGridConstants.TopicTypeNameHelp,
            ParameterSetName = EventSubscriptionTopicNameParameterSet)]
        public string TopicName { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.TopicTypeNameHelp,
            ParameterSetName = EventSubscriptionTopicTypeNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string TopicTypeName { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Location",
            ParameterSetName = EventSubscriptionTopicTypeNameParameterSet)]
        [LocationCompleter("Microsoft.EventGrid/eventSubscriptions")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "EventGrid Topic object.",
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSTopic InputObject { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Include the full endpoint URL of the event subscription destination.",
            ParameterSetName = EventSubscriptionTopicNameParameterSet)]
        [Parameter(Mandatory = false,
            HelpMessage = "Include the full endpoint URL of the event subscription destination.",
            ParameterSetName = EventSubscriptionTopicTypeNameParameterSet)]
        [Parameter(Mandatory = false,
            HelpMessage = "If specified, include the full endpoint URL of the event subscription destination in the response.",
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        public SwitchParameter IncludeFullEndpointUrl { get; set; }

        public override void ExecuteCmdlet()
        {
            string scope;
            bool includeFullEndpointUrl = this.IncludeFullEndpointUrl.IsPresent;

            if (!string.IsNullOrEmpty(this.EventSubscriptionName))
            {
                // Since an EventSubscription name is specified, we need to retrieve 
                // only the particular event subscription corresponding to this name.
                if (this.InputObject != null)
                {
                    // Retrieve the event subscription for the specified topic
                    scope = this.InputObject.Id;
                }
                else if (string.IsNullOrEmpty(this.ResourceId))
                {
                    // ResourceID not specified, retrieve the event subscription for either the 
                    // subscription, or resource group, or custom topic depending on which of the parameters are provided.
                    scope = EventGridUtils.GetScope(this.DefaultContext.Subscription.Id, this.ResourceGroupName, this.TopicName);
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

                if (this.InputObject != null)
                {
                    // Retrieve all the event subscriptions based on the ID of the specified topic object
                    eventSubscriptionsList = this.Client.ListByResourceId(this.DefaultContext.Subscription.Id, this.InputObject.Id);
                }
                else if (!string.IsNullOrEmpty(this.ResourceId))
                {
                    eventSubscriptionsList = this.Client.ListByResourceId(this.DefaultContext.Subscription.Id, this.ResourceId);
                }
                else if (!string.IsNullOrEmpty(this.TopicName))
                {
                    // Get all event subscriptions for this topic
                    if (string.IsNullOrEmpty(this.ResourceGroupName))
                    {
                        throw new ArgumentNullException(this.ResourceGroupName,
                            "Resource Group Name should be specified to retrieve event subscriptions for a topic");
                    }

                    eventSubscriptionsList = this.Client.ListByResource(this.ResourceGroupName, "Microsoft.EventGrid", "topics", this.TopicName);
                }
                else if (!string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    if (string.IsNullOrEmpty(this.Location) && string.IsNullOrEmpty(this.TopicTypeName))
                    {
                        // List all global Event Grid subscriptions in the given resource group
                        eventSubscriptionsList = this.Client.ListGlobalEventSubscriptionsByResourceGroup(this.ResourceGroupName);
                    }
                    else if (string.IsNullOrEmpty(this.Location) && !string.IsNullOrEmpty(this.TopicTypeName))
                    {
                        eventSubscriptionsList = this.Client.ListGlobalEventSubscriptionsByResourceGroupForTopicType(this.ResourceGroupName, this.TopicTypeName);
                    }
                    else if (!string.IsNullOrEmpty(this.Location) && string.IsNullOrEmpty(this.TopicTypeName))
                    {
                        // List all regional Event Grid subscriptions in the given resource group
                        eventSubscriptionsList = this.Client.ListRegionalEventSubscriptionsByResourceGroup(this.ResourceGroupName, this.Location);
                    }
                    else if (!string.IsNullOrEmpty(this.Location) && !string.IsNullOrEmpty(this.TopicTypeName))
                    {
                        eventSubscriptionsList = this.Client.ListRegionalEventSubscriptionsByResourceGroupForTopicType(this.ResourceGroupName, this.Location, this.TopicTypeName);
                    }
                }
                else
                {
                    // List all Event Grid event subscriptions in the given subscription
                    if (string.IsNullOrEmpty(this.Location) && string.IsNullOrEmpty(this.TopicTypeName))
                    {
                        // List all global Event Grid subscriptions in the given resource group
                        eventSubscriptionsList = this.Client.ListGlobalEventSubscriptionsBySubscription();
                    }
                    else if (string.IsNullOrEmpty(this.Location) && !string.IsNullOrEmpty(this.TopicTypeName))
                    {
                        eventSubscriptionsList = this.Client.ListGlobalEventSubscriptionsBySubscriptionForTopicType(this.TopicTypeName);
                    }
                    else if (!string.IsNullOrEmpty(this.Location) && string.IsNullOrEmpty(this.TopicTypeName))
                    {
                        // List all regional Event Grid subscriptions in the given resource group
                        eventSubscriptionsList = this.Client.ListRegionalEventSubscriptionsBySubscription(this.Location);
                    }
                    else if (!string.IsNullOrEmpty(this.Location) && !string.IsNullOrEmpty(this.TopicTypeName))
                    {
                        eventSubscriptionsList = this.Client.ListRegionalEventSubscriptionsBySubscriptionForTopicType(this.Location, this.TopicTypeName);
                    }
                }

                this.WritePSEventSubscriptionsList(eventSubscriptionsList, includeFullEndpointUrl);
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

        void WritePSEventSubscriptionsList(IEnumerable<EventSubscription> eventSubscriptionsList, bool includeFullEndpointUrl)
        {
            var psEventSubscriptionsList = new List<PSEventSubscription>();

            if (eventSubscriptionsList == null)
            {
                return;
            }

            foreach (EventSubscription eventSubscription in eventSubscriptionsList)
            {
                PSEventSubscriptionListInstance psEventSubscription;

                if (includeFullEndpointUrl &&
                    eventSubscription.Destination is WebHookEventSubscriptionDestination)
                {
                    EventSubscriptionFullUrl fullUrl = this.Client.GetEventSubscriptionFullUrl(eventSubscription.Topic, eventSubscription.Name);
                    psEventSubscription = new PSEventSubscriptionListInstance(eventSubscription, fullUrl.EndpointUrl);
                }
                else
                {
                    psEventSubscription = new PSEventSubscriptionListInstance(eventSubscription);
                }

                psEventSubscriptionsList.Add(psEventSubscription);
            }

            this.WriteObject(psEventSubscriptionsList, true);
        }
    }
}