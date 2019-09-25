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
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.EventGrid;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.EventGrid
{
    public class EventGridClient
    {
        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        public EventGridClient(IAzureContext context)
        {
            this.Client = AzureSession.Instance.ClientFactory.CreateArmClient<EventGridManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);

        }
        public EventGridManagementClient Client { get; }

        public IEnumerable<TopicTypeInfo> ListTopicTypes()
        {
            IEnumerable<TopicTypeInfo> topicTypesList = this.Client.TopicTypes.List();
            return topicTypesList;
        }

        public TopicTypeInfo GetTopicType(string topicTypeName)
        {
            TopicTypeInfo topicTypeInfo = this.Client.TopicTypes.Get(topicTypeName);
            return topicTypeInfo;
        }

        public IEnumerable<EventType> ListEventTypes(string topicTypeName)
        {
            IEnumerable<EventType> eventTypesList = this.Client.TopicTypes.ListEventTypes(topicTypeName);
            return eventTypesList;
        }

        #region Topics
        public Topic GetTopic(string resourceGroupName, string topicName)
        {
            var topic = this.Client.Topics.Get(resourceGroupName, topicName);
            return topic;
        }

        public (IEnumerable<Topic>, string) ListTopicsByResourceGroup(string resourceGroupName, string oDataQuery, int? top)
        {
            List<Topic> topicsList = new List<Topic>();
            IPage<Topic> topicsPage = this.Client.Topics.ListByResourceGroup(resourceGroupName, oDataQuery, top);
            bool isAllResultsNeeded = top == null;
            string nextLink = null;
            if (topicsPage != null)
            {
                topicsList.AddRange(topicsPage);
                nextLink = topicsPage.NextPageLink;
                while (nextLink != null && isAllResultsNeeded)
                {
                    IEnumerable<Topic> newTopicsList;
                    (newTopicsList, nextLink) = this.ListTopicsByResourceGroupNext(nextLink);
                    topicsList.AddRange(newTopicsList);
                }
            }

            return (topicsList, nextLink);
        }

        public (IEnumerable<Topic>, string) ListTopicsByResourceGroupNext(string nextLink)
        {
            List<Topic> topicsList = new List<Topic>();
            string newNextLink = null;
            IPage<Topic> topicsPage = this.Client.Topics.ListByResourceGroupNext(nextLink);
            if (topicsPage != null)
            {
                topicsList.AddRange(topicsPage);
                newNextLink = topicsPage.NextPageLink;
            }

            return (topicsList, newNextLink);
        }

        public (IEnumerable<Topic>, string) ListTopicsBySubscription(string oDataQuery, int? top)
        {
            List<Topic> topicsList = new List<Topic>();
            IPage<Topic> topicsPage = this.Client.Topics.ListBySubscription(oDataQuery, top);
            bool isAllResultsNeeded = top == null;
            string nextLink = null;

            if (topicsPage != null)
            {
                topicsList.AddRange(topicsPage);
                nextLink = topicsPage.NextPageLink;
                while (nextLink != null && isAllResultsNeeded)
                {
                    IEnumerable<Topic> newTopicsList;
                    (newTopicsList, nextLink) = this.ListTopicBySubscriptionNext(nextLink);
                    topicsList.AddRange(newTopicsList);
                }
            }

            return (topicsList, nextLink);
        }

        public (IEnumerable<Topic>, string) ListTopicBySubscriptionNext(string nextLink)
        {
            List<Topic> topicsList = new List<Topic>();
            string newNextLink = null;
            IPage<Topic> topicsPage = this.Client.Topics.ListBySubscriptionNext(nextLink);
            if (topicsPage != null)
            {
                topicsList.AddRange(topicsPage);
                newNextLink = topicsPage.NextPageLink;
            }

            return (topicsList, newNextLink);
        }

        public Topic CreateTopic(
            string resourceGroupName,
            string topicName,
            string location,
            Dictionary<string, string> tags)
        {
            Topic topic = new Topic();
            topic.Location = location;

            if (tags != null)
            {
                topic.Tags = new Dictionary<string, string>(tags);
            }

            return this.Client.Topics.CreateOrUpdate(resourceGroupName, topicName, topic);
        }

        public Topic ReplaceTopic(string resourceGroupName, string topicName, string location, Dictionary<string, string> tags)
        {
            var topic = new Topic();
            topic.Location = location;

            if (tags != null && tags.Any())
            {
                topic.Tags = new Dictionary<string, string>(tags);
            }

            return this.Client.Topics.CreateOrUpdate(resourceGroupName, topicName, topic);
        }

        public Topic UpdateTopic(string resourceGroupName, string topicName, Dictionary<string, string> tags)
        {
            return this.Client.Topics.Update(resourceGroupName, topicName, tags);
        }

        public void DeleteTopic(string resourceGroupName, string topicName)
        {
            this.Client.Topics.Delete(resourceGroupName, topicName);
        }

        public TopicSharedAccessKeys GetTopicSharedAccessKeys(string resourceGroupName, string topicName)
        {
            return this.Client.Topics.ListSharedAccessKeys(resourceGroupName, topicName);
        }

        public TopicSharedAccessKeys RegenerateTopicKey(string resourceGroupName, string topicName, string keyName)
        {
            return this.Client.Topics.RegenerateKey(resourceGroupName, topicName, keyName);
        }

        #endregion

        #region Domain
        public Domain GetDomain(string resourceGroupName, string domainName)
        {
            var domain = this.Client.Domains.Get(resourceGroupName, domainName);
            return domain;
        }

        public (IEnumerable<Domain>, string) ListDomainsByResourceGroup(string resourceGroupName, string oDataQuery, int? top)
        {
            List<Domain> domainsList = new List<Domain>();
            IPage<Domain> domainsPage = this.Client.Domains.ListByResourceGroup(resourceGroupName, oDataQuery, top);
            bool isAllResultsNeeded = top == null;
            string nextLink = null;

            if (domainsPage != null)
            {
                domainsList.AddRange(domainsPage);
                nextLink = domainsPage.NextPageLink;
                while (nextLink != null && isAllResultsNeeded)
                {
                    IEnumerable<Domain> newDomainsList;
                    (newDomainsList, nextLink) = this.ListDomainsByResourceGroupNext(nextLink);
                    domainsList.AddRange(newDomainsList);
                }
            }

            return (domainsList, nextLink);
        }

        public (IEnumerable<Domain>, string) ListDomainsByResourceGroupNext(string nextLink)
        {
            List<Domain> domainsList = new List<Domain>();
            string newNextLink = null;
            IPage<Domain> domainsPage = this.Client.Domains.ListByResourceGroupNext(nextLink);
            if (domainsPage != null)
            {
                domainsList.AddRange(domainsPage);
                newNextLink = domainsPage.NextPageLink;
            }

            return (domainsList, newNextLink);
        }

        public (IEnumerable<Domain>, string) ListDomainsBySubscription(string oDataQuery, int? top)
        {
            List<Domain> domainsList = new List<Domain>();
            IPage<Domain> domainsPage = this.Client.Domains.ListBySubscription(oDataQuery, top);
            bool isAllResultsNeeded = top == null;
            string nextLink = null;

            if (domainsPage != null)
            {
                domainsList.AddRange(domainsPage);
                nextLink = domainsPage.NextPageLink;
                while (nextLink != null && isAllResultsNeeded)
                {
                    IEnumerable<Domain> newDomainsList;
                    (newDomainsList, nextLink) = this.ListDomainBySubscriptionNext(nextLink);
                    domainsList.AddRange(newDomainsList);
                }
            }

            return (domainsList, nextLink);
        }

        public (IEnumerable<Domain>, string) ListDomainBySubscriptionNext(string nextLink)
        {
            List<Domain> domainsList = new List<Domain>();
            string newNextLink = null;
            IPage<Domain> domainsPage = this.Client.Domains.ListBySubscriptionNext(nextLink);
            if (domainsPage != null)
            {
                domainsList.AddRange(domainsPage);
                newNextLink = domainsPage.NextPageLink;
            }

            return (domainsList, newNextLink);
        }

        public Domain CreateDomain(
            string resourceGroupName,
            string domainName,
            string location,
            Dictionary<string, string> tags)
        {
            Domain domain = new Domain();
            domain.Location = location;

            if (tags != null)
            {
                domain.Tags = new Dictionary<string, string>(tags);
            }

            return this.Client.Domains.CreateOrUpdate(resourceGroupName, domainName, domain);
        }

        public Domain ReplaceDomain(string resourceGroupName, string domainName, string location, Dictionary<string, string> tags)
        {
            var domain = new Domain();
            domain.Location = location;

            if (tags != null && tags.Any())
            {
                domain.Tags = new Dictionary<string, string>(tags);
            }

            return this.Client.Domains.CreateOrUpdate(resourceGroupName, domainName, domain);
        }

        public Domain UpdateDomain(string resourceGroupName, string domainName, Dictionary<string, string> tags)
        {
            return this.Client.Domains.Update(resourceGroupName, domainName, tags);
        }

        public void DeleteDomain(string resourceGroupName, string domainName)
        {
            this.Client.Domains.Delete(resourceGroupName, domainName);
        }

        public DomainSharedAccessKeys GetDomainSharedAccessKeys(string resourceGroupName, string domainName)
        {
            return this.Client.Domains.ListSharedAccessKeys(resourceGroupName, domainName);
        }

        public DomainSharedAccessKeys RegenerateDomainKey(string resourceGroupName, string domainName, string keyName)
        {
            return this.Client.Domains.RegenerateKey(resourceGroupName, domainName, keyName);
        }

        #endregion

        #region domainTopic

        public DomainTopic CreateDomainTopic(string resourceGroupName, string domainName, string domainTopicName)
        {
            return this.Client.DomainTopics.CreateOrUpdate(resourceGroupName, domainName, domainTopicName);
        }

        public DomainTopic ReplaceDomainTopic(string resourceGroupName, string domainName, string domainTopicName)
        {
            return this.Client.DomainTopics.CreateOrUpdate(resourceGroupName, domainName, domainTopicName);
        }

        public void DeleteDomainTopic(string resourceGroupName, string domainName, string domainTopicName)
        {
            this.Client.DomainTopics.Delete(resourceGroupName, domainName, domainTopicName);
        }

        public DomainTopic GetDomainTopic(string resourceGroupName, string domainName, string domainTopicName)
        {
            return this.Client.DomainTopics.Get(resourceGroupName, domainName, domainTopicName);
        }

        public (IEnumerable<DomainTopic>, string) ListDomainTopicsByDomain(string resourceGroupName, string domainName, string oDataQuery, int? top)
        {
            List<DomainTopic> domainTopicsList = new List<DomainTopic>();
            IPage<DomainTopic> domainTopicsPage = this.Client.DomainTopics.ListByDomain(resourceGroupName, domainName, oDataQuery, top);
            bool isAllResultsNeeded = top == null;
            string nextLink = null;
            if (domainTopicsPage != null)
            {
                domainTopicsList.AddRange(domainTopicsPage);
                nextLink = domainTopicsPage.NextPageLink;
                while (nextLink != null && isAllResultsNeeded)
                {
                    IEnumerable<DomainTopic> newDomainTopicsList;
                    (newDomainTopicsList, nextLink) = this.ListDomainTopicsByDomainNext(nextLink);
                    domainTopicsList.AddRange(newDomainTopicsList);
                }
            }

            return (domainTopicsList, nextLink);
        }

        public (IEnumerable<DomainTopic>, string) ListDomainTopicsByDomainNext(string nextLink)
        {
            List<DomainTopic> domianTopicsList = new List<DomainTopic>();
            string newNextLink = null;
            IPage<DomainTopic> domainTopicsPage = this.Client.DomainTopics.ListByDomainNext(nextLink);
            if (domainTopicsPage != null)
            {
                domianTopicsList.AddRange(domainTopicsPage);
                newNextLink = domainTopicsPage.NextPageLink;
            }

            return (domianTopicsList, newNextLink);
        }

        #endregion

        public EventSubscription CreateEventSubscription(
            string scope,
            string eventSubscriptionName,
            string endpoint,
            string endpointType,
            string subjectBeginsWith,
            string subjectEndsWith,
            bool isSubjectCaseSensitive,
            string[] includedEventTypes,
            string[] labels,
            RetryPolicy retryPolicy,
            string deadLetterEndpoint,
            DateTime expirationDate,
            Hashtable[] advancedFilter)
        {
            EventSubscription eventSubscription = new EventSubscription();
            EventSubscriptionDestination destination = null;

            if (string.IsNullOrEmpty(endpointType) ||
                string.Equals(endpointType, EventGridConstants.Webhook, StringComparison.OrdinalIgnoreCase))
            {
                destination = new WebHookEventSubscriptionDestination()
                {
                    EndpointUrl = endpoint
                };
            }
            else if (string.Equals(endpointType, EventGridConstants.EventHub, StringComparison.OrdinalIgnoreCase))
            {
                destination = new EventHubEventSubscriptionDestination()
                {
                    ResourceId = endpoint
                };
            }
            else if (string.Equals(endpointType, EventGridConstants.StorageQueue, StringComparison.OrdinalIgnoreCase))
            {
                destination = this.GetStorageQueueEventSubscriptionDestinationFromEndpoint(endpoint);
            }
            else if (string.Equals(endpointType, EventGridConstants.HybridConnection, StringComparison.OrdinalIgnoreCase))
            {
                destination = new HybridConnectionEventSubscriptionDestination()
                {
                    ResourceId = endpoint
                };
            }
            else if (string.Equals(endpointType, EventGridConstants.ServiceBusQueue, StringComparison.OrdinalIgnoreCase))
            {
                destination = new ServiceBusQueueEventSubscriptionDestination()
                {
                    ResourceId = endpoint
                };
            }
            else
            {
                throw new ArgumentNullException(nameof(endpointType), "Invalid EndpointType. Allowed values are WebHook, EventHub, StorageQueue, HybridConnection or ServiceBusQueue.");
            }

            eventSubscription.Destination = destination;

            var filter = new EventSubscriptionFilter()
            {
                SubjectBeginsWith = subjectBeginsWith,
                SubjectEndsWith = subjectEndsWith,
                IsSubjectCaseSensitive = isSubjectCaseSensitive
            };

            if (includedEventTypes != null)
            {
                filter.IncludedEventTypes = new List<string>(includedEventTypes);
            }

            eventSubscription.Filter = filter;

            if (advancedFilter != null && advancedFilter.Count() > 0)
            {
                this.UpdatedAdvancedFilterParameters(advancedFilter, eventSubscription.Filter);
            }

            if (labels != null)
            {
                eventSubscription.Labels = new List<string>(labels);
            }

            if (retryPolicy != null)
            {
                eventSubscription.RetryPolicy = retryPolicy;
            }

            if (!string.IsNullOrEmpty(deadLetterEndpoint))
            {
                eventSubscription.DeadLetterDestination = this.GetStorageBlobDeadLetterDestinationFromEndPoint(deadLetterEndpoint);
            }

            if (expirationDate != null && expirationDate != DateTime.MinValue)
            {
                eventSubscription.ExpirationTimeUtc = expirationDate;
            }

            return this.Client.EventSubscriptions.CreateOrUpdate(scope, eventSubscriptionName, eventSubscription);
        }

        public EventSubscription UpdateEventSubscription(
            string scope,
            string eventSubscriptionName,
            string endpoint,
            string endpointType,
            string subjectBeginsWith,
            string subjectEndsWith,
            bool? isSubjectCaseSensitive,
            string[] includedEventTypes,
            string[] labels,
            RetryPolicy retryPolicy,
            string deadLetterEndpoint,
            DateTime expirationDate,
            Hashtable[] advancedFilter)
        {
            EventSubscriptionUpdateParameters eventSubscriptionUpdateParameters = new EventSubscriptionUpdateParameters();

            if (!string.IsNullOrEmpty(endpoint))
            {
                // An endpoint was specified, so it needs to be included as part of the update parameters
                // Defaulting to webhook if endpoint type was not specified
                if (string.IsNullOrEmpty(endpointType) ||
                    string.Equals(endpointType, EventGridConstants.Webhook, StringComparison.OrdinalIgnoreCase))
                {
                    eventSubscriptionUpdateParameters.Destination = new WebHookEventSubscriptionDestination()
                    {
                        EndpointUrl = endpoint
                    };
                }
                else if (string.Equals(endpointType, EventGridConstants.EventHub, StringComparison.OrdinalIgnoreCase))
                {
                    eventSubscriptionUpdateParameters.Destination = new EventHubEventSubscriptionDestination()
                    {
                        ResourceId = endpoint
                    };
                }
                else if (string.Equals(endpointType, EventGridConstants.StorageQueue, StringComparison.OrdinalIgnoreCase))
                {
                    eventSubscriptionUpdateParameters.Destination = this.GetStorageQueueEventSubscriptionDestinationFromEndpoint(endpoint);
                }
                else if (string.Equals(endpointType, EventGridConstants.HybridConnection, StringComparison.OrdinalIgnoreCase))
                {
                    eventSubscriptionUpdateParameters.Destination = new HybridConnectionEventSubscriptionDestination()
                    {
                        ResourceId = endpoint
                    };
                }
                else if (string.Equals(endpointType, EventGridConstants.ServiceBusQueue, StringComparison.OrdinalIgnoreCase))
                {
                    eventSubscriptionUpdateParameters.Destination = new ServiceBusQueueEventSubscriptionDestination()
                    {
                        ResourceId = endpoint
                    };
                }
                else
                {
                    throw new ArgumentNullException(nameof(endpointType), "EndpointType should be WebHook, EventHub, Storage Queue, HybridConnection or ServiceBusQueue.");
                }
            }

            eventSubscriptionUpdateParameters.Filter = new EventSubscriptionFilter()
            {
                SubjectBeginsWith = subjectBeginsWith,
                SubjectEndsWith = subjectEndsWith,
                IsSubjectCaseSensitive = isSubjectCaseSensitive
            };

            if (includedEventTypes != null)
            {
                eventSubscriptionUpdateParameters.Filter.IncludedEventTypes = new List<string>(includedEventTypes);
            }

            if (labels != null)
            {
                eventSubscriptionUpdateParameters.Labels = new List<string>(labels);
            }

            if (retryPolicy != null)
            {
                eventSubscriptionUpdateParameters.RetryPolicy = retryPolicy;
            }

            if (!string.IsNullOrEmpty(deadLetterEndpoint))
            {
                eventSubscriptionUpdateParameters.DeadLetterDestination = this.GetStorageBlobDeadLetterDestinationFromEndPoint(deadLetterEndpoint);
            }

            if (advancedFilter != null && advancedFilter.Count() > 0)
            {
                this.UpdatedAdvancedFilterParameters(advancedFilter, eventSubscriptionUpdateParameters.Filter);
            }

            if (expirationDate != null && expirationDate != DateTime.MinValue)
            {
                eventSubscriptionUpdateParameters.ExpirationTimeUtc = expirationDate;
            }

            return this.Client.EventSubscriptions.Update(scope, eventSubscriptionName, eventSubscriptionUpdateParameters);
        }

        public void DeleteEventSubscription(string scope, string eventSubscriptionName)
        {
            this.Client.EventSubscriptions.Delete(scope, eventSubscriptionName);
        }

        public EventSubscription GetEventSubscription(string scope, string eventSubscriptionName)
        {
            return this.Client.EventSubscriptions.Get(scope, eventSubscriptionName);
        }

        public EventSubscriptionFullUrl GetEventSubscriptionFullUrl(string scope, string eventSubscriptionName)
        {
            return this.Client.EventSubscriptions.GetFullUrl(scope, eventSubscriptionName);
        }

        public (IEnumerable<EventSubscription>, string) ListRegionalEventSubscriptionsByResourceGroup(string resourceGroupName, string location, string oDataQuery, int? top)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListRegionalByResourceGroup(resourceGroupName, location, oDataQuery, top);
            bool isAllResultsNeeded = top == null;
            string nextLink = null;
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                nextLink = eventSubscriptionsPage.NextPageLink;
                while (nextLink != null && isAllResultsNeeded)
                {
                    IEnumerable<EventSubscription> newEventSubscriptionsList;
                    (newEventSubscriptionsList, nextLink) = this.ListRegionalEventSubscriptionsByResourceGroupNext(nextLink);
                    eventSubscriptionsList.AddRange(newEventSubscriptionsList);
                }
            }

            return (eventSubscriptionsList, nextLink);
        }

        public (IEnumerable<EventSubscription>, string) ListRegionalEventSubscriptionsByResourceGroupNext(string nextLink)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            string newNextLink = null;
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListRegionalByResourceGroupNext(nextLink);
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                newNextLink = eventSubscriptionsPage.NextPageLink;
            }

            return (eventSubscriptionsList, newNextLink);
        }

        public (IEnumerable<EventSubscription>, string) ListRegionalEventSubscriptionsBySubscription(string location, string oDataQuery, int? top)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListRegionalBySubscription(location, oDataQuery, top);
            bool isAllResultsNeeded = top == null;
            string nextLink = null;
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                nextLink = eventSubscriptionsPage.NextPageLink;
                while (nextLink != null && isAllResultsNeeded)
                {
                    IEnumerable<EventSubscription> newEventSubscriptionsList;
                    (newEventSubscriptionsList, nextLink) = this.ListRegionalEventSubscriptionsBySubscriptionNext(nextLink);
                    eventSubscriptionsList.AddRange(newEventSubscriptionsList);
                }
            }

            return (eventSubscriptionsList, nextLink);
        }

        public (IEnumerable<EventSubscription>, string) ListRegionalEventSubscriptionsBySubscriptionNext(string nextLink)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            string newNextLink = null;
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListRegionalBySubscriptionNext(nextLink);
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                newNextLink = eventSubscriptionsPage.NextPageLink;
            }

            return (eventSubscriptionsList, newNextLink);
        }

        public (IEnumerable<EventSubscription>, string) ListGlobalEventSubscriptionsByResourceGroup(string resourceGroupName, string oDataQuery, int? top)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListGlobalByResourceGroup(resourceGroupName, oDataQuery, top);
            bool isAllResultsNeeded = top == null;
            string nextLink = null;
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                nextLink = eventSubscriptionsPage.NextPageLink;
                while (nextLink != null && isAllResultsNeeded)
                {
                    IEnumerable<EventSubscription> newEventSubscriptionsList;
                    (newEventSubscriptionsList, nextLink) = this.ListGlobalEventSubscriptionsByResourceGroupNext(nextLink);
                    eventSubscriptionsList.AddRange(newEventSubscriptionsList);
                }
            }

            return (eventSubscriptionsList, nextLink);
        }

        public (IEnumerable<EventSubscription>, string) ListGlobalEventSubscriptionsByResourceGroupNext(string nextLink)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            string newNextLink = null;
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListGlobalByResourceGroupNext(nextLink);
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                newNextLink = eventSubscriptionsPage.NextPageLink;
            }

            return (eventSubscriptionsList, newNextLink);
        }

        public (IEnumerable<EventSubscription>, string) ListGlobalEventSubscriptionsBySubscription(string oDataQuery, int? top)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListGlobalBySubscription(oDataQuery, top);
            bool isAllResultsNeeded = top == null;
            string nextLink = null;
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                nextLink = eventSubscriptionsPage.NextPageLink;
                while (nextLink != null && isAllResultsNeeded)
                {
                    IEnumerable<EventSubscription> newEventSubscriptionsList;
                    (newEventSubscriptionsList, nextLink) = this.ListGlobalEventSubscriptionsBySubscriptionNext(nextLink);
                    eventSubscriptionsList.AddRange(newEventSubscriptionsList);
                }
            }

            return (eventSubscriptionsList, nextLink);
        }

        public (IEnumerable<EventSubscription>, string) ListGlobalEventSubscriptionsBySubscriptionNext(string nextLink)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListGlobalBySubscriptionNext(nextLink);
            string newNextLink = null;
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                newNextLink = eventSubscriptionsPage.NextPageLink;
            }

            return (eventSubscriptionsList, newNextLink);
        }

        public (IEnumerable<EventSubscription>, string) ListRegionalEventSubscriptionsByResourceGroupForTopicType(string resourceGroupName, string location, string topicType, string oDataQuery, int? top)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListRegionalByResourceGroupForTopicType(resourceGroupName, location, topicType, oDataQuery, top);
            bool isAllResultsNeeded = top == null;
            string nextLink = null;
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                nextLink = eventSubscriptionsPage.NextPageLink;
                while (nextLink != null && isAllResultsNeeded)
                {
                    IEnumerable<EventSubscription> newEventSubscriptionsList;
                    (newEventSubscriptionsList, nextLink) = this.ListRegionalEventSubscriptionsByResourceGroupForTopicTypeNext(nextLink);
                    eventSubscriptionsList.AddRange(newEventSubscriptionsList);
                }
            }

            return (eventSubscriptionsList, nextLink);
        }

        public (IEnumerable<EventSubscription>, string) ListRegionalEventSubscriptionsByResourceGroupForTopicTypeNext(string nextLink)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListRegionalByResourceGroupForTopicTypeNext(nextLink);
            string newNextLink = null;
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                newNextLink = eventSubscriptionsPage.NextPageLink;
            }

            return (eventSubscriptionsList, newNextLink);
        }


        public (IEnumerable<EventSubscription>, string) ListRegionalEventSubscriptionsBySubscriptionForTopicType(string location, string topicType, string oDataQuery, int? top)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListRegionalBySubscriptionForTopicType(location, topicType, oDataQuery, top);
            bool isAllResultsNeeded = top == null;
            string nextLink = null;
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                nextLink = eventSubscriptionsPage.NextPageLink;
                while (nextLink != null && isAllResultsNeeded)
                {
                    IEnumerable<EventSubscription> newEventSubscriptionsList;
                    (newEventSubscriptionsList, nextLink) = this.ListRegionalEventSubscriptionsBySubscriptionForTopicTypeNext(nextLink);
                    eventSubscriptionsList.AddRange(newEventSubscriptionsList);
                }
            }

            return (eventSubscriptionsList, nextLink);
        }

        public (IEnumerable<EventSubscription>, string) ListRegionalEventSubscriptionsBySubscriptionForTopicTypeNext(string nextLink)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListRegionalBySubscriptionForTopicTypeNext(nextLink);
            string newNextLink = null;
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                newNextLink = eventSubscriptionsPage.NextPageLink;
            }

            return (eventSubscriptionsList, newNextLink);
        }

        public (IEnumerable<EventSubscription>, string) ListGlobalEventSubscriptionsByResourceGroupForTopicType(string resourceGroupName, string topicType, string oDataQuery, int? top)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListGlobalByResourceGroupForTopicType(resourceGroupName, topicType, oDataQuery, top);
            bool isAllResultsNeeded = top == null;
            string nextLink = null;
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                nextLink = eventSubscriptionsPage.NextPageLink;
                while (nextLink != null && isAllResultsNeeded)
                {
                    IEnumerable<EventSubscription> newEventSubscriptionsList;
                    (newEventSubscriptionsList, nextLink) = this.ListGlobalEventSubscriptionsByResourceGroupForTopicTypeNext(nextLink);
                    eventSubscriptionsList.AddRange(newEventSubscriptionsList);
                }
            }

            return (eventSubscriptionsList, nextLink);
        }

        public (IEnumerable<EventSubscription>, string) ListGlobalEventSubscriptionsByResourceGroupForTopicTypeNext(string nextLink)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListGlobalByResourceGroupForTopicTypeNext(nextLink);
            string newNextLink = null;
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                newNextLink = eventSubscriptionsPage.NextPageLink;
            }

            return (eventSubscriptionsList, newNextLink);
        }

        public (IEnumerable<EventSubscription>, string) ListGlobalEventSubscriptionsBySubscriptionForTopicType(string topicType, string oDataQuery, int? top)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListGlobalBySubscriptionForTopicType(topicType, oDataQuery, top);
            bool isAllResultsNeeded = top == null;
            string nextLink = null;
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                nextLink = eventSubscriptionsPage.NextPageLink;
                while (nextLink != null && isAllResultsNeeded)
                {
                    IEnumerable<EventSubscription> newEventSubscriptionsList;
                    (newEventSubscriptionsList, nextLink) = this.ListGlobalEventSubscriptionsBySubscriptionForTopicTypeNext(nextLink);
                    eventSubscriptionsList.AddRange(newEventSubscriptionsList);
                }
            }

            return (eventSubscriptionsList, nextLink);
        }

        public (IEnumerable<EventSubscription>, string) ListGlobalEventSubscriptionsBySubscriptionForTopicTypeNext(string nextLink)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListGlobalBySubscriptionForTopicTypeNext(nextLink);
            string newNextLink = null;
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                newNextLink = eventSubscriptionsPage.NextPageLink;
            }

            return (eventSubscriptionsList, newNextLink);
        }

        public (IEnumerable<EventSubscription>, string) ListByResource(string resourceGroupName, string providerNamespace, string resourceType, string resourceName, string oDataQuery, int? top)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListByResource(resourceGroupName, providerNamespace, resourceType, resourceName, oDataQuery, top);
            bool isAllResultsNeeded = top == null;
            string nextLink = null;
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                nextLink = eventSubscriptionsPage.NextPageLink;
                while (nextLink != null && isAllResultsNeeded)
                {
                    IEnumerable<EventSubscription> newEventSubscriptionsList;
                    (newEventSubscriptionsList, nextLink) = this.ListByResourceNext(nextLink);
                    eventSubscriptionsList.AddRange(newEventSubscriptionsList);
                }
            }

            return (eventSubscriptionsList, nextLink);
        }

        public (IEnumerable<EventSubscription>, string) ListByResourceNext(string nextLink)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListByResourceNext(nextLink);
            string newNextLink = null;
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                newNextLink = eventSubscriptionsPage.NextPageLink;
            }

            return (eventSubscriptionsList, newNextLink);
        }

        public (IEnumerable<EventSubscription>, string) ListByResourceId(string currentSubscriptionId, string resourceId, string oDataQuery, int? top)
        {
            string[] tokens = resourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 2)
            {
                // subscription scope
                string providedSubscriptionId = tokens[1];
                this.ValidateSubscription(providedSubscriptionId, currentSubscriptionId);

                return this.ListGlobalEventSubscriptionsBySubscription(oDataQuery, top);
            }
            else if (tokens.Length == 4)
            {
                string providedSubscriptionId = tokens[1];
                this.ValidateSubscription(providedSubscriptionId, currentSubscriptionId);

                // Resource Group scope
                string resourceGroupName = tokens[3];
                return this.ListGlobalEventSubscriptionsByResourceGroup(resourceGroupName, oDataQuery, top);
            }
            else if (tokens.Length == 8)
            {
                string providedSubscriptionId = tokens[1];
                this.ValidateSubscription(providedSubscriptionId, currentSubscriptionId);

                // Resource scope
                string resourceGroupName = tokens[3];
                string providerNamespace = tokens[5];
                string resourceType = tokens[6];
                string resourceName = tokens[7];
                return this.ListByResource(resourceGroupName, providerNamespace, resourceType, resourceName, oDataQuery, top);
            }
            else if (tokens.Length == 10)
            {
                string providedSubscriptionId = tokens[1];
                this.ValidateSubscription(providedSubscriptionId, currentSubscriptionId);

                // Resource scope
                string resourceGroupName = tokens[3];
                string providerNamespace = tokens[5];
                string resourceType = tokens[6];
                string resourceName = tokens[7];
                string nestedResourceName = tokens[9];
                return this.ListByDomainTopic(resourceGroupName, resourceName, nestedResourceName, oDataQuery, top);
            }
            else
            {
                throw new ArgumentException("Unsupported value for resourceID", nameof(resourceId));
            }
        }

        public (IEnumerable<EventSubscription>, string) ListByDomainTopic(string resourceGroupName, string domainName, string domainTopicName, string oDataQuery, int? top)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListByDomainTopic(resourceGroupName, domainName, domainTopicName, oDataQuery, top);
            bool isAllResultsNeeded = top == null;
            string nextLink = null;
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                nextLink = eventSubscriptionsPage.NextPageLink;
                while (nextLink != null && isAllResultsNeeded)
                {
                    IEnumerable<EventSubscription> newEventSubscriptionsList;
                    (newEventSubscriptionsList, nextLink) = this.ListByDomainTopicNext(nextLink);
                    eventSubscriptionsList.AddRange(newEventSubscriptionsList);
                }
            }

            return (eventSubscriptionsList, nextLink);
        }

        public (IEnumerable<EventSubscription>, string) ListByDomainTopicNext(string nextLink)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.EventSubscriptions.ListByDomainTopicNext(nextLink);
            string newNextLink = null;
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                newNextLink = eventSubscriptionsPage.NextPageLink;
            }

            return (eventSubscriptionsList, newNextLink);
        }

        public (IEnumerable<EventSubscription>, string) ListEventSubscriptionsNext(string nextLink)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            // Get Next page of event subscriptions. Get the proper next API to be called based on the nextLink.
            Uri uri = new Uri(nextLink);
            string path = uri.AbsolutePath;

            path = path.Substring(0, path.LastIndexOf("/providers/Microsoft.EventGrid/eventSubscriptions", StringComparison.OrdinalIgnoreCase));

            // /subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/DevExpRg/providers/Microsoft.EventGrid/domains/PwrShellTestDomain6/providers/Microsoft.EventGrid/eventSubscriptions
            string[] tokens = path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 2)
            {
                // subscription scope
                return this.ListGlobalEventSubscriptionsBySubscriptionNext(nextLink);
            }
            else if (tokens.Length == 4)
            {
                // Resource Group scope
                return this.ListGlobalEventSubscriptionsByResourceGroupNext(nextLink);
            }
            else if (tokens.Length == 8)
            {
                // Resource scope
                return this.ListByResourceNext(nextLink);
            }
            else if (tokens.Length == 10)
            {
                // Resource scope
                return this.ListByDomainTopicNext(nextLink);
            }
            else
            {
                throw new ArgumentException("Unsupported value for nextLink", nameof(path));
            }
        }

        void ValidateSubscription(string providedSubscriptionId, string subscriptionIdFromContext)
        {
            if (!string.Equals(subscriptionIdFromContext, providedSubscriptionId, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("SubscriptionID from resource is different than the default subscription set in the context. Please retry after setting this subscription ID as the default subscription.");
            }
        }

        StorageQueueEventSubscriptionDestination GetStorageQueueEventSubscriptionDestinationFromEndpoint(string endpoint)
        {
            int strIndex = endpoint.IndexOf("/queueServices/default/queues/", StringComparison.OrdinalIgnoreCase);
            string[] tokens = endpoint.Split('/');

            if (!this.IsValidStorageAccountResourceId(strIndex, tokens))
            {
                throw new Exception(
                    $"The provided endpoint value {endpoint} is invalid.The expected format is /subscriptions/[AzureSubscriptionID]/resourceGroups/" +
                    "[ResourceGroupName]/providers/Microsoft.Storage/storageAccounts/[StorageAccountName]/queueServices/default/queues/[QueueName].");
            }

            return new StorageQueueEventSubscriptionDestination()
            {
                ResourceId = endpoint.Substring(0, strIndex),
                QueueName = tokens[tokens.Length - 1]
            };
        }

        StorageBlobDeadLetterDestination GetStorageBlobDeadLetterDestinationFromEndPoint(string endpoint)
        {
            int strIndex = endpoint.IndexOf("/blobServices/default/containers/", StringComparison.OrdinalIgnoreCase);
            string[] tokens = endpoint.Split('/');

            if (!this.IsValidStorageAccountResourceId(strIndex, tokens))
            {
                throw new Exception(
                    $"The provided endpoint value {endpoint} is invalid.The expected format is /subscriptions/[AzureSubscriptionID]/resourceGroups/" +
                    "[ResourceGroupName]/providers/Microsoft.Storage/storageAccounts/[StorageAccountName]/blobServices/default/containers/[ContainerName].");
            }

            return new StorageBlobDeadLetterDestination
            {
                ResourceId = endpoint.Substring(0, strIndex),
                BlobContainerName = tokens[tokens.Length - 1]
            };
        }

        bool IsValidStorageAccountResourceId(int strIndex, string[] tokens)
        {
            Guid parsedGuid = Guid.Empty;

            // Basic validation of the endpoint.
            return (strIndex > 0 &&
                tokens.Length == 13 &&
                string.Equals(tokens[1], "subscriptions", StringComparison.OrdinalIgnoreCase) &&
                Guid.TryParse(tokens[2], out parsedGuid) &&
                string.Equals(tokens[3], "resourceGroups", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(tokens[5], "providers", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(tokens[6], "Microsoft.Storage", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(tokens[7], "storageAccounts", StringComparison.OrdinalIgnoreCase));
        }

        void UpdatedAdvancedFilterParameters(Hashtable[] advancedFilter, EventSubscriptionFilter filter)
        {
            filter.AdvancedFilters = new List<AdvancedFilter>();

            // Validate the advanced filter parameters.
            for (int i = 0; i < advancedFilter.Count(); i++)
            {
                // Validate entries.
                if (advancedFilter[i].Count != 3)
                {
                    throw new Exception($"Invalid Advanced Filter parameter:. Unexpected number of entries for advanced filter #{i + 1} as we expect 3 key-value pair while we received {advancedFilter[i].Count}");
                }

                if (!advancedFilter[i].ContainsKey("Operator") ||
                    !advancedFilter[i].ContainsKey("keY") ||
                    !(advancedFilter[i].ContainsKey("value")
                    || advancedFilter[i].ContainsKey("values")))
                {
                    throw new Exception($"Invalid Advanced Filter parameter:. At least one of the key parameters is invalid for advanced filter #{i + 1}. The expected keys are either: Operator, key, and value or values.");
                }

                string operatorValue = (string)advancedFilter[i]["operator"];

                if (string.IsNullOrEmpty(operatorValue))
                {
                    throw new Exception($"Invalid Advanced Filter parameter: The operator value is null or empty for advanced filter #{i + 1}.");
                }

                string keyValue = (string)advancedFilter[i]["key"];

                if (string.IsNullOrEmpty(keyValue))
                {
                    throw new Exception($"Invalid Advanced Filter parameter. The key value is null or empty for advanced filter #{i + 1}");
                }

                List<string> keyValuesList = null;
                List<double?> keyValuesListForDouble = null;
                Object[] tempValues = (Object[])advancedFilter[i]["values"];

                if (tempValues != null)
                {
                    if (operatorValue.ToLower().Contains("string"))
                    {
                        keyValuesList = new List<string>();
                        for (int val = 0; val < tempValues.Count(); val++)
                        {
                            keyValuesList.Add((string)tempValues[val]);
                        }
                    }
                    else if (operatorValue.ToLower().Contains("number"))
                    {
                        keyValuesListForDouble = new List<double?>();
                        for (int val = 0; val < tempValues.Count(); val++)
                        {
                            keyValuesListForDouble.Add((double?)(int)tempValues[val]);
                        }
                    }
                }

                var singleValueValue = advancedFilter[i]["value"];

                if (tempValues == null && singleValueValue == null)
                {
                    throw new Exception($"Invalid Advanced Filter parameters. Either Values or Value should be determined for advanced filter #{i + 1}");
                }

                if (string.Equals(operatorValue, "StringIn", StringComparison.OrdinalIgnoreCase))
                {
                    var stringInAdvFilter = new StringInAdvancedFilter
                    {
                        Key = keyValue,
                        Values = keyValuesList
                    };

                    filter.AdvancedFilters.Add(stringInAdvFilter);
                }
                else if (string.Equals(operatorValue, "StringNotIn", StringComparison.OrdinalIgnoreCase))
                {
                    var stringNotInAdvFilter = new StringNotInAdvancedFilter
                    {
                        Key = keyValue,
                        Values = keyValuesList
                    };

                    filter.AdvancedFilters.Add(stringNotInAdvFilter);
                }
                else if (string.Equals(operatorValue, "StringContains", StringComparison.OrdinalIgnoreCase))
                {
                    var stringContainsAdvFilter = new StringContainsAdvancedFilter
                    {
                        Key = keyValue,
                        Values = keyValuesList
                    };

                    filter.AdvancedFilters.Add(stringContainsAdvFilter);
                }
                else if (string.Equals(operatorValue, "StringBeginsWith", StringComparison.OrdinalIgnoreCase))
                {
                    var stringBeginsWithAdvFilter = new StringBeginsWithAdvancedFilter
                    {
                        Key = keyValue,
                        Values = keyValuesList
                    };

                    filter.AdvancedFilters.Add(stringBeginsWithAdvFilter);
                }
                else if (string.Equals(operatorValue, "StringEndsWith", StringComparison.OrdinalIgnoreCase))
                {
                    var stringEndsWithAdvFilter = new StringEndsWithAdvancedFilter
                    {
                        Key = keyValue,
                        Values = keyValuesList
                    };

                    filter.AdvancedFilters.Add(stringEndsWithAdvFilter);
                }
                else if (string.Equals(operatorValue, "NumberIn", StringComparison.OrdinalIgnoreCase))
                {
                    var numberInAdvFilter = new NumberInAdvancedFilter
                    {
                        Key = keyValue,
                        Values = keyValuesListForDouble
                    };

                    filter.AdvancedFilters.Add(numberInAdvFilter);
                }
                else if (string.Equals(operatorValue, "NumberGreaterThanOrEquals", StringComparison.OrdinalIgnoreCase))
                {
                    var numberGreaterThanAdvFilter = new NumberGreaterThanAdvancedFilter
                    {
                        Key = keyValue,
                        Value = (double?)advancedFilter[i]["value"]
                    };

                    filter.AdvancedFilters.Add(numberGreaterThanAdvFilter);
                }
                else if (string.Equals(operatorValue, "NumberNotIn", StringComparison.OrdinalIgnoreCase))
                {
                    var numberNotInAdvFilter = new NumberNotInAdvancedFilter
                    {
                        Key = keyValue,
                        Values = keyValuesListForDouble
                    };

                    filter.AdvancedFilters.Add(numberNotInAdvFilter);
                }
                else if (string.Equals(operatorValue, "NumberGreaterThan", StringComparison.OrdinalIgnoreCase))
                {
                    var numberGreaterThanAdvFilter = new NumberGreaterThanAdvancedFilter
                    {
                        Key = keyValue,
                        Value = (double?)advancedFilter[i]["value"]
                    };

                    filter.AdvancedFilters.Add(numberGreaterThanAdvFilter);
                }
                else if (string.Equals(operatorValue, "NumberLessThan", StringComparison.OrdinalIgnoreCase))
                {
                    var numberLessThanAdvFilter = new NumberLessThanAdvancedFilter
                    {
                        Key = keyValue,
                        Value = (double?)advancedFilter[i]["value"]
                    };

                    filter.AdvancedFilters.Add(numberLessThanAdvFilter);
                }
                else if (string.Equals(operatorValue, "NumberLessThanOrEquals", StringComparison.OrdinalIgnoreCase))
                {
                    var numberLessThanOrEqualsAdvFilter = new NumberLessThanOrEqualsAdvancedFilter
                    {
                        Key = keyValue,
                        Value = (double?)advancedFilter[i]["value"]
                    };

                    filter.AdvancedFilters.Add(numberLessThanOrEqualsAdvFilter);
                }
                else if (string.Equals(operatorValue, "BoolEquals", StringComparison.OrdinalIgnoreCase))
                {
                    var boolEqualsAdvFilter = new BoolEqualsAdvancedFilter
                    {
                        Key = keyValue,
                        Value = (bool?)advancedFilter[i]["value"]
                    };

                    filter.AdvancedFilters.Add(boolEqualsAdvFilter);
                }
                else
                {
                    throw new Exception($"Invalid Advanced Filter parameter. Unsupported operator for advanced filter #{i + 1}.");
                }
            }
        }
    }
}
