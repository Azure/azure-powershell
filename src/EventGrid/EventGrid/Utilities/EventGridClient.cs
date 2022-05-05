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
using System.Security.Cryptography;

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
            Dictionary<string, string> tags,
            string inputSchema,
            Dictionary<string, string> inputMappingFields,
            Dictionary<string, string> inputMappingDefaultValuesDictionary,
            Dictionary<string, string> inboundIpRules,
            string publicNetworkAccess,
            string identityType,
            Dictionary<string, UserIdentityProperties> userAssignedIdentities)
        {
            Topic topic = new Topic();
            JsonInputSchemaMapping jsonInputMapping = null;
            topic.Location = location;

            topic.InputSchema = inputSchema;

            if (identityType != null)
            {
                IdentityInfo identityInfo = new IdentityInfo();
                identityInfo.Type = identityType;
                identityInfo.UserAssignedIdentities = userAssignedIdentities;
                topic.Identity = identityInfo;
            }

            if (tags != null)
            {
                topic.Tags = new Dictionary<string, string>(tags);
            }

            if (inputMappingFields != null || inputMappingDefaultValuesDictionary != null)
            {
                jsonInputMapping = new JsonInputSchemaMapping();
                this.PrepareInputSchemaMappingParameters(inputMappingFields, inputMappingDefaultValuesDictionary, jsonInputMapping);
            }

            topic.InputSchemaMapping = jsonInputMapping;

            topic.PublicNetworkAccess = publicNetworkAccess;

            if (inboundIpRules != null)
            {
                topic.InboundIpRules = new List<InboundIpRule>();

                foreach (var rule in inboundIpRules)
                {
                    InboundIpRule ipRule = new InboundIpRule
                    {
                        IpMask = rule.Key,
                        Action = rule.Value
                    };

                    topic.InboundIpRules.Add(ipRule);
                }
            }

            return this.Client.Topics.CreateOrUpdate(resourceGroupName, topicName, topic);
        }

        public Topic ReplaceTopic(
            string resourceGroupName,
            string topicName,
            string location,
            Dictionary<string, string> tags,
            Dictionary<string, string> inboundIpRules,
            string publicNetworkAccess,
            string identityType,
            Dictionary<string, UserIdentityProperties> userAssignedIdentities)
        {
            var topic = new Topic();
            topic.Location = location;

            if (identityType != null)
            {
                IdentityInfo identityInfo = new IdentityInfo();
                identityInfo.Type = identityType;
                identityInfo.UserAssignedIdentities = userAssignedIdentities;
                topic.Identity = identityInfo;
            }

            if (tags != null && tags.Any())
            {
                topic.Tags = new Dictionary<string, string>(tags);
            }

            topic.PublicNetworkAccess = publicNetworkAccess;

            if (inboundIpRules != null && inboundIpRules.Any())
            {
                topic.InboundIpRules = new List<InboundIpRule>();

                foreach (var rule in inboundIpRules)
                {
                    InboundIpRule ipRule = new InboundIpRule
                    {
                        IpMask = rule.Key,
                        Action = rule.Value
                    };

                    topic.InboundIpRules.Add(ipRule);
                }
            }

            return this.Client.Topics.CreateOrUpdate(resourceGroupName, topicName, topic);
        }

        public Topic UpdateTopic(string resourceGroupName, string topicName, Dictionary<string, string> tags)
        {
            TopicUpdateParameters updateParams = new TopicUpdateParameters { Tags = tags };
            return this.Client.Topics.Update(resourceGroupName, topicName, updateParams);
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

        #region SystemTopic
        public SystemTopic GetSystemTopic(string resourceGroupName, string systemTopicName)
        {
            var systemTopic = this.Client.SystemTopics.Get(resourceGroupName, systemTopicName);
            return systemTopic;
        }

        public (IEnumerable<SystemTopic>, string) ListSystemTopicBySubscription(string oDataQuery, int? top)
        {
            List<SystemTopic> topicsList = new List<SystemTopic>();
            IPage<SystemTopic> topicsPage = this.Client.SystemTopics.ListBySubscription(oDataQuery, top);
            bool isAllResultsNeeded = top == null;
            string nextLink = null;

            if (topicsPage != null)
            {
                topicsList.AddRange(topicsPage);
                nextLink = topicsPage.NextPageLink;
                while (nextLink != null && isAllResultsNeeded)
                {
                    IEnumerable<SystemTopic> newTopicsList;
                    (newTopicsList, nextLink) = this.ListSystemTopicBySubscriptionNext(nextLink);
                    topicsList.AddRange(newTopicsList);
                }
            }
            return (topicsList, nextLink);
        }

        public (IEnumerable<SystemTopic>, string) ListSystemTopicBySubscriptionNext(string nextLink)
        {
            List<SystemTopic> topicsList = new List<SystemTopic>();
            string newNextLink = null;
            IPage<SystemTopic> topicsPage = this.Client.SystemTopics.ListBySubscriptionNext(nextLink);
            if (topicsPage != null)
            {
                topicsList.AddRange(topicsPage);
                newNextLink = topicsPage.NextPageLink;
            }

            return (topicsList, newNextLink);
        }

        public (IEnumerable<SystemTopic>, string) ListSystemTopicByResourceGroup(string resourceGroupname, string oDataQuery, int? top)
        {
            List<SystemTopic> topicsList = new List<SystemTopic>();
            IPage<SystemTopic> topicsPage = this.Client.SystemTopics.ListByResourceGroup(resourceGroupname, oDataQuery, top);
            bool isAllResultsNeeded = top == null;
            string nextLink = null;

            if (topicsPage != null)
            {
                topicsList.AddRange(topicsPage);
                nextLink = topicsPage.NextPageLink;
                while (nextLink != null && isAllResultsNeeded)
                {
                    IEnumerable<SystemTopic> newTopicsList;
                    (newTopicsList, nextLink) = this.ListSystemTopicByResourceGroupNext(nextLink);
                    topicsList.AddRange(newTopicsList);
                }
            }
            return (topicsList, nextLink);
        }

        public (IEnumerable<SystemTopic>, string) ListSystemTopicByResourceGroupNext(string nextLink)
        {
            List<SystemTopic> topicsList = new List<SystemTopic>();
            string newNextLink = null;
            IPage<SystemTopic> topicsPage = this.Client.SystemTopics.ListByResourceGroupNext(nextLink);
            if (topicsPage != null)
            {
                topicsList.AddRange(topicsPage);
                newNextLink = topicsPage.NextPageLink;
            }

            return (topicsList, newNextLink);
        }

        public SystemTopic CreateSystemTopic(
            string resourceGroupName,
            string systemTopicName,
            string location,
            string source,
            string topicType,
            string identityType,
            IDictionary<string, UserIdentityProperties> userAssignedIdentities,
            Dictionary<string, string> tags)
        {
            SystemTopic systemTopic = new SystemTopic();
            systemTopic.Location = location;
            systemTopic.Source = source;
            systemTopic.TopicType = topicType;
            if(identityType != null)
            {
                IdentityInfo identityInfo = new IdentityInfo();
                identityInfo.Type = identityType;
                identityInfo.UserAssignedIdentities = userAssignedIdentities;
                systemTopic.Identity = identityInfo;
            }
            
            return this.Client.SystemTopics.CreateOrUpdate(resourceGroupName, systemTopicName, systemTopic);
        }

        public SystemTopic UpdateSystemTopic(
            string resourceGroupName,
            string systemTopicName,
            string identityType,
            IDictionary<string, UserIdentityProperties> userAssignedIdentities,
            Dictionary<string, string> tags)
        {
            IdentityInfo identityInfo = null;
            if (identityType != null)
            {
                identityInfo = new IdentityInfo();
                identityInfo.Type = identityType;
                identityInfo.UserAssignedIdentities = userAssignedIdentities;
            }
            SystemTopicUpdateParameters systemTopicUpdateParameters = new SystemTopicUpdateParameters(tags, identityInfo);
            return this.Client.SystemTopics.Update(resourceGroupName, systemTopicName, systemTopicUpdateParameters);
        }

        public void DeleteSystemTopic(string resourceGroupName, string systemTopicName)
        {
            this.Client.SystemTopics.Delete(resourceGroupName, systemTopicName);
        }


        #endregion

        #region SystemTopicEventSubscription

        public EventSubscription GetSystemTopicEventSubscriptiion(string resourceGroupName, string systemTopicName, string eventSubscriptionName)
        {
            var systemTopicEventSubscription = this.Client.SystemTopicEventSubscriptions.Get(resourceGroupName, systemTopicName, eventSubscriptionName);
            return systemTopicEventSubscription;
        }

        public (IEnumerable<EventSubscription>, string) ListSystemTopicEventSubscriptions(string resourceGroupName, string systemTopic, string oDataQuery, int? top)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.SystemTopicEventSubscriptions.ListBySystemTopic(resourceGroupName, systemTopic, oDataQuery, top);
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

        public (IEnumerable<EventSubscription>, string) ListSystemTopicEventSubscriptionsNext(string nextLink)
        {
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            string newNextLink = null;
            IPage<EventSubscription> eventSubscriptionsPage = this.Client.SystemTopicEventSubscriptions.ListBySystemTopicNext(nextLink);
            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                newNextLink = eventSubscriptionsPage.NextPageLink;
            }

            return (eventSubscriptionsList, newNextLink);
        }

        public EventSubscription createSystemTopicEventSubscriptiion(
            string eventSubscriptionName,
            string resourceGroupName,
            string systemTopicName,
            string aadAppIdOrUri,
            string aadTenantId,
            string deadLetterEndpoint,
            string[] deliveryAttributeMapping ,
            string endpoint,
            string endpointType,
            string deliverySchema,
            RetryPolicy retryPolicy, 
            DateTime expirationDate,
            string[] labels,
            int maxEventsPerBatch,
            int preferredBatchSizeInKiloByte,
            long storageQueueMessageTtl,
            Hashtable[] advancedFilter,
            bool enableAdvancedFilteringOnArrays,
            string[] includedEventTypes,
            string subjectBeginsWith,
            string subjectEndsWith,
            bool isSubjectCaseSensitive
            )
        {
            EventSubscription eventSubscription = new EventSubscription();
            EventSubscriptionDestination destination = null;

            if (string.IsNullOrEmpty(endpointType) ||
                string.Equals(endpointType, EventGridConstants.Webhook, StringComparison.OrdinalIgnoreCase))
            {
                destination = new WebHookEventSubscriptionDestination()
                {
                    EndpointUrl = endpoint,
                    MaxEventsPerBatch = (maxEventsPerBatch == 0) ? (int?)null : maxEventsPerBatch,
                    PreferredBatchSizeInKilobytes = (preferredBatchSizeInKiloByte == 0) ? (int?)null : preferredBatchSizeInKiloByte,
                    AzureActiveDirectoryApplicationIdOrUri = aadAppIdOrUri,
                    AzureActiveDirectoryTenantId = aadTenantId,
                    DeliveryAttributeMappings = GetDeliveryAttributeMapping(deliveryAttributeMapping)
                };
            }
            else if (string.Equals(endpointType, EventGridConstants.EventHub, StringComparison.OrdinalIgnoreCase))
            {
                destination = new EventHubEventSubscriptionDestination()
                {
                    ResourceId = endpoint,
                    DeliveryAttributeMappings = GetDeliveryAttributeMapping(deliveryAttributeMapping)
                };
            }
            else if (string.Equals(endpointType, EventGridConstants.StorageQueue, StringComparison.OrdinalIgnoreCase))
            {
                destination = this.GetStorageQueueEventSubscriptionDestinationFromEndpoint(endpoint, storageQueueMessageTtl);
            }
            else if (string.Equals(endpointType, EventGridConstants.HybridConnection, StringComparison.OrdinalIgnoreCase))
            {
                destination = new HybridConnectionEventSubscriptionDestination()
                {
                    ResourceId = endpoint,
                    DeliveryAttributeMappings = GetDeliveryAttributeMapping(deliveryAttributeMapping)
                };
            }
            else if (string.Equals(endpointType, EventGridConstants.ServiceBusQueue, StringComparison.OrdinalIgnoreCase))
            {
                destination = new ServiceBusQueueEventSubscriptionDestination()
                {
                    ResourceId = endpoint,
                    DeliveryAttributeMappings = GetDeliveryAttributeMapping(deliveryAttributeMapping)
                };
            }
            else if (string.Equals(endpointType, EventGridConstants.ServiceBusTopic, StringComparison.OrdinalIgnoreCase))
            {
                destination = new ServiceBusTopicEventSubscriptionDestination()
                {
                    ResourceId = endpoint,
                    DeliveryAttributeMappings = GetDeliveryAttributeMapping(deliveryAttributeMapping)
                };
            }
            else if (string.Equals(endpointType, EventGridConstants.AzureFunction, StringComparison.OrdinalIgnoreCase))
            {
                destination = new AzureFunctionEventSubscriptionDestination()
                {
                    ResourceId = endpoint,
                    DeliveryAttributeMappings = GetDeliveryAttributeMapping(deliveryAttributeMapping)
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
                IsSubjectCaseSensitive = isSubjectCaseSensitive,
                EnableAdvancedFilteringOnArrays = enableAdvancedFilteringOnArrays
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


            eventSubscription.RetryPolicy = retryPolicy;

            if (!string.IsNullOrEmpty(deadLetterEndpoint))
            {
                eventSubscription.DeadLetterDestination = this.GetStorageBlobDeadLetterDestinationFromEndPoint(deadLetterEndpoint);
            }

            eventSubscription.EventDeliverySchema = deliverySchema;

            if (expirationDate != null && expirationDate != DateTime.MinValue)
            {
                eventSubscription.ExpirationTimeUtc = expirationDate;
            }
            var systemTopicEventSubscription = this.Client.SystemTopicEventSubscriptions.CreateOrUpdate(resourceGroupName, systemTopicName, eventSubscriptionName, eventSubscription);
            return systemTopicEventSubscription;
        }

        public EventSubscription UpdateSystemTopicEventSubscriptiion(
            string eventSubscriptionName,
            string resourceGroupName,
            string systemTopicName,
            string deadLetterEndpoint,
            string[] deliveryAttributeMapping,
            string endpoint,
            string endpointType,
            string[] labels,
            long storageQueueMessageTtl,
            Hashtable[] advancedFilter,
            bool enableAdvancedFilteringOnArrays,
            string[] includedEventTypes,
            string subjectBeginsWith,
            string subjectEndsWith,
            bool isSubjectCaseSensitive)
        {
            EventSubscriptionDestination destination = null;
            DeadLetterDestination deadLetterDestination = null;
            EventSubscriptionFilter eventSubscriptionFilter = null;

            if (string.IsNullOrEmpty(endpointType) ||
                string.Equals(endpointType, EventGridConstants.Webhook, StringComparison.OrdinalIgnoreCase))
            {
                destination = new WebHookEventSubscriptionDestination()
                {
                    EndpointUrl = endpoint,
                    DeliveryAttributeMappings = GetDeliveryAttributeMapping(deliveryAttributeMapping)
                };
            }
            else if (string.Equals(endpointType, EventGridConstants.EventHub, StringComparison.OrdinalIgnoreCase))
            {
                destination = new EventHubEventSubscriptionDestination()
                {
                    ResourceId = endpoint,
                    DeliveryAttributeMappings = GetDeliveryAttributeMapping(deliveryAttributeMapping)
                };
            }
            else if (string.Equals(endpointType, EventGridConstants.StorageQueue, StringComparison.OrdinalIgnoreCase))
            {
                destination = this.GetStorageQueueEventSubscriptionDestinationFromEndpoint(endpoint, storageQueueMessageTtl);
            }
            else if (string.Equals(endpointType, EventGridConstants.HybridConnection, StringComparison.OrdinalIgnoreCase))
            {
                destination = new HybridConnectionEventSubscriptionDestination()
                {
                    ResourceId = endpoint,
                    DeliveryAttributeMappings = GetDeliveryAttributeMapping(deliveryAttributeMapping)
                };
            }
            else if (string.Equals(endpointType, EventGridConstants.ServiceBusQueue, StringComparison.OrdinalIgnoreCase))
            {
                destination = new ServiceBusQueueEventSubscriptionDestination()
                {
                    ResourceId = endpoint,
                    DeliveryAttributeMappings = GetDeliveryAttributeMapping(deliveryAttributeMapping)
                };
            }
            else if (string.Equals(endpointType, EventGridConstants.ServiceBusTopic, StringComparison.OrdinalIgnoreCase))
            {
                destination = new ServiceBusTopicEventSubscriptionDestination()
                {
                    ResourceId = endpoint,
                    DeliveryAttributeMappings = GetDeliveryAttributeMapping(deliveryAttributeMapping)
                };
            }
            else if (string.Equals(endpointType, EventGridConstants.AzureFunction, StringComparison.OrdinalIgnoreCase))
            {
                destination = new AzureFunctionEventSubscriptionDestination()
                {
                    ResourceId = endpoint,
                    DeliveryAttributeMappings = GetDeliveryAttributeMapping(deliveryAttributeMapping)
                };
            }
            else
            {
                throw new ArgumentNullException(nameof(endpointType), "Invalid EndpointType. Allowed values are WebHook, EventHub, StorageQueue, HybridConnection or ServiceBusQueue.");
            }


            var filter = new EventSubscriptionFilter()
            {
                SubjectBeginsWith = subjectBeginsWith,
                SubjectEndsWith = subjectEndsWith,
                IsSubjectCaseSensitive = isSubjectCaseSensitive,
                EnableAdvancedFilteringOnArrays = enableAdvancedFilteringOnArrays
            };

            if (includedEventTypes != null)
            {
                filter.IncludedEventTypes = new List<string>(includedEventTypes);
            }

            eventSubscriptionFilter = filter;

            if (advancedFilter != null && advancedFilter.Count() > 0)
            {
                this.UpdatedAdvancedFilterParameters(advancedFilter, eventSubscriptionFilter);
            }
            if (!string.IsNullOrEmpty(deadLetterEndpoint))
            {
                deadLetterDestination = this.GetStorageBlobDeadLetterDestinationFromEndPoint(deadLetterEndpoint);
            }

            EventSubscriptionUpdateParameters eventSubscriptionUpdateParameters = new EventSubscriptionUpdateParameters();
            if(!string.IsNullOrEmpty(endpoint))
            {
                eventSubscriptionUpdateParameters.Destination = destination;
            }
            eventSubscriptionUpdateParameters.DeliveryWithResourceIdentity = null;
            eventSubscriptionUpdateParameters.Filter = filter;
            eventSubscriptionUpdateParameters.Labels = labels;
            eventSubscriptionUpdateParameters.DeadLetterDestination = deadLetterDestination;
            eventSubscriptionUpdateParameters.DeadLetterWithResourceIdentity = null;
            //(EventSubscriptionDestination destination = null, DeliveryWithResourceIdentity deliveryWithResourceIdentity = null, EventSubscriptionFilter filter = null, IList<string> labels = null, DateTime ? expirationTimeUtc = null, string eventDeliverySchema = null, RetryPolicy retryPolicy = null, DeadLetterDestination deadLetterDestination = null, DeadLetterWithResourceIdentity deadLetterWithResourceIdentity = null);

            var systemTopicEventSubscription = this.Client.SystemTopicEventSubscriptions.Update(resourceGroupName, systemTopicName, eventSubscriptionName, eventSubscriptionUpdateParameters);
            return systemTopicEventSubscription;
        }

        public void DeleteSystemTopicEventSubscriptiion(string resourceGroupName, string systemTopicName, string eventSubscriptionName)
        {
            this.Client.SystemTopicEventSubscriptions.Delete(resourceGroupName, systemTopicName, eventSubscriptionName);
        }

        public EventSubscriptionFullUrl GetAzFullUrlForSystemTopicEventSubscription(string resourceGroupName, string systemTopicName, string eventSubscriptionName)
        {
            return this.Client.SystemTopicEventSubscriptions.GetFullUrl(resourceGroupName, systemTopicName, eventSubscriptionName);
        }

        public DeliveryAttributeListResult GetAzEventSubscriptionsDeliveryAttribute(string resourceGroupName, string systemTopicName, string eventSubscriptionName)
        {
            return this.Client.SystemTopicEventSubscriptions.GetDeliveryAttributes(resourceGroupName, systemTopicName, eventSubscriptionName);
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
            Dictionary<string, string> tags,
            string inputSchema,
            Dictionary<string, string> inputMappingFields,
            Dictionary<string, string> inputMappingDefaultValuesDictionary,
            Dictionary<string, string> inboundIpRules,
            string publicNetworkAccess,
            string identityType,
            Dictionary<string, UserIdentityProperties> userAssignedIdentities,
            bool disableLocalAuth,
            bool autoCreateTopicWithFirstSubscription,
            bool autoDeleteTopicWithLastSubscription)
        {
            Domain domain = new Domain();
            JsonInputSchemaMapping jsonInputMapping = null;
            domain.Location = location;

            if (identityType != null)
            {
                IdentityInfo identityInfo = new IdentityInfo();
                identityInfo.Type = identityType;
                identityInfo.UserAssignedIdentities = userAssignedIdentities;
                domain.Identity = identityInfo;
            }

            domain.InputSchema = inputSchema;
            domain.DisableLocalAuth = disableLocalAuth;
            domain.AutoCreateTopicWithFirstSubscription = autoCreateTopicWithFirstSubscription;
            domain.AutoDeleteTopicWithLastSubscription = autoDeleteTopicWithLastSubscription;

            if (tags != null)
            {
                domain.Tags = new Dictionary<string, string>(tags);
            }

            if (inputMappingFields != null || inputMappingDefaultValuesDictionary != null)
            {
                jsonInputMapping = new JsonInputSchemaMapping();
                this.PrepareInputSchemaMappingParameters(inputMappingFields, inputMappingDefaultValuesDictionary, jsonInputMapping);
            }

            domain.InputSchemaMapping = jsonInputMapping;

            domain.PublicNetworkAccess = publicNetworkAccess;

            if (inboundIpRules != null)
            {
                domain.InboundIpRules = new List<InboundIpRule>();

                foreach (var rule in inboundIpRules)
                {
                    InboundIpRule ipRule = new InboundIpRule
                    {
                        IpMask = rule.Key,
                        Action = rule.Value
                    };

                    domain.InboundIpRules.Add(ipRule);
                }
            }

            return this.Client.Domains.CreateOrUpdate(resourceGroupName, domainName, domain);
        }

        public Domain ReplaceDomain(
            string resourceGroupName,
            string domainName,
            string location,
            Dictionary<string, string> tags,
            Dictionary<string, string> inboundIpRules,
            string publicNetworkAccess)
        {
            var domain = new Domain();
            domain.Location = location;

            if (tags != null && tags.Any())
            {
                domain.Tags = new Dictionary<string, string>(tags);
            }

            domain.PublicNetworkAccess = publicNetworkAccess;

            if (inboundIpRules != null && inboundIpRules.Any())
            {
                domain.InboundIpRules = new List<InboundIpRule>();

                foreach (var rule in inboundIpRules)
                {
                    InboundIpRule ipRule = new InboundIpRule
                    {
                        IpMask = rule.Key,
                        Action = rule.Value
                    };

                    domain.InboundIpRules.Add(ipRule);
                }
            }

            return this.Client.Domains.CreateOrUpdate(resourceGroupName, domainName, domain);
        }

        public Domain UpdateDomain(string resourceGroupName, string domainName, Dictionary<string, string> tags)
        {
            DomainUpdateParameters updateParams = new DomainUpdateParameters { Tags = tags };
            return this.Client.Domains.Update(resourceGroupName, domainName, updateParams);
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
            string deliverySchema,
            string deadLetterEndpoint,
            DateTime expirationDate,
            Hashtable[] advancedFilter,
            int maxEventsPerBatch,
            int preferredBatchSizeInKiloByte,
            string aadTenantId,
            string aadAppIdOrUri,
            bool enableAdvancedFilteringOnArrays,
            string[] deliveryAttributeMapping,
            long storageQueueMessageTtl)
        {
            EventSubscription eventSubscription = new EventSubscription();
            EventSubscriptionDestination destination = null;

            if (string.IsNullOrEmpty(endpointType) ||
                string.Equals(endpointType, EventGridConstants.Webhook, StringComparison.OrdinalIgnoreCase))
            {
                destination = new WebHookEventSubscriptionDestination()
                {
                    EndpointUrl = endpoint,
                    MaxEventsPerBatch = (maxEventsPerBatch == 0) ? (int?) null : maxEventsPerBatch,
                    PreferredBatchSizeInKilobytes = (preferredBatchSizeInKiloByte == 0) ? (int?)null : preferredBatchSizeInKiloByte,
                    AzureActiveDirectoryApplicationIdOrUri = aadAppIdOrUri,
                    AzureActiveDirectoryTenantId = aadTenantId,
                    DeliveryAttributeMappings = GetDeliveryAttributeMapping(deliveryAttributeMapping)
                };
            }
            else if (string.Equals(endpointType, EventGridConstants.EventHub, StringComparison.OrdinalIgnoreCase))
            {
                destination = new EventHubEventSubscriptionDestination()
                {
                    ResourceId = endpoint,
                    DeliveryAttributeMappings = GetDeliveryAttributeMapping(deliveryAttributeMapping)
                };
            }
            else if (string.Equals(endpointType, EventGridConstants.StorageQueue, StringComparison.OrdinalIgnoreCase))
            {
                destination = this.GetStorageQueueEventSubscriptionDestinationFromEndpoint(endpoint, storageQueueMessageTtl);
            }
            else if (string.Equals(endpointType, EventGridConstants.HybridConnection, StringComparison.OrdinalIgnoreCase))
            {
                destination = new HybridConnectionEventSubscriptionDestination()
                {
                    ResourceId = endpoint,
                    DeliveryAttributeMappings = GetDeliveryAttributeMapping(deliveryAttributeMapping)
                };
            }
            else if (string.Equals(endpointType, EventGridConstants.ServiceBusQueue, StringComparison.OrdinalIgnoreCase))
            {
                destination = new ServiceBusQueueEventSubscriptionDestination()
                {
                    ResourceId = endpoint,
                    DeliveryAttributeMappings = GetDeliveryAttributeMapping(deliveryAttributeMapping)
                };
            }
            else if (string.Equals(endpointType, EventGridConstants.ServiceBusTopic, StringComparison.OrdinalIgnoreCase))
            {
                destination = new ServiceBusTopicEventSubscriptionDestination()
                {
                    ResourceId = endpoint,
                    DeliveryAttributeMappings = GetDeliveryAttributeMapping(deliveryAttributeMapping)
                };
            }
            else if (string.Equals(endpointType, EventGridConstants.AzureFunction, StringComparison.OrdinalIgnoreCase))
            {
                destination = new AzureFunctionEventSubscriptionDestination()
                {
                    ResourceId = endpoint,
                    DeliveryAttributeMappings = GetDeliveryAttributeMapping(deliveryAttributeMapping)
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
                IsSubjectCaseSensitive = isSubjectCaseSensitive,
                EnableAdvancedFilteringOnArrays = enableAdvancedFilteringOnArrays
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

            eventSubscription.EventDeliverySchema = deliverySchema;

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
            Hashtable[] advancedFilter,
            int? maxEventsPerBatch,
            int? preferredBatchSizeInKiloByte,
            string aadAppIdOrUri,
            string aadTenantId)
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
                        EndpointUrl = endpoint,
                        MaxEventsPerBatch = maxEventsPerBatch,
                        PreferredBatchSizeInKilobytes = preferredBatchSizeInKiloByte,
                        AzureActiveDirectoryApplicationIdOrUri = aadAppIdOrUri,
                        AzureActiveDirectoryTenantId = aadTenantId
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
                else if (string.Equals(endpointType, EventGridConstants.ServiceBusTopic, StringComparison.OrdinalIgnoreCase))
                {
                    eventSubscriptionUpdateParameters.Destination = new ServiceBusTopicEventSubscriptionDestination()
                    {
                        ResourceId = endpoint
                    };
                }
                else if (string.Equals(endpointType, EventGridConstants.AzureFunction, StringComparison.OrdinalIgnoreCase))
                {
                    eventSubscriptionUpdateParameters.Destination = new AzureFunctionEventSubscriptionDestination()
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

        public DeliveryAttributeListResult GetAzFullUrlForSystemTopicEventSubscription(string scope, string eventSubscriptionName)
        {
            return this.Client.EventSubscriptions.GetDeliveryAttributes(scope, eventSubscriptionName);
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

        IList<DeliveryAttributeMapping> GetDeliveryAttributeMapping(string[] deliveryAttributes)
        {
            if(deliveryAttributes == null || deliveryAttributes.Length==0)
            {
                return null;
            }

            IList<DeliveryAttributeMapping> deliveryAttributeMapping = new List<DeliveryAttributeMapping>();
            foreach (string deliveryAttribute in deliveryAttributes)
            {
                deliveryAttributeMapping.Add(new DeliveryAttributeMapping(deliveryAttribute));
            }
            return deliveryAttributeMapping;
        }

        StorageQueueEventSubscriptionDestination GetStorageQueueEventSubscriptionDestinationFromEndpoint(string endpoint, long? queueMessageTimeToLiveInSeconds = null)
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
                QueueName = tokens[tokens.Length - 1],
                QueueMessageTimeToLiveInSeconds = queueMessageTimeToLiveInSeconds
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

        void PrepareInputSchemaMappingParameters(
            Dictionary<string, string> inputMappingFields,
            Dictionary<string, string> inputMappingDefaultValuesDictionary,
            JsonInputSchemaMapping jsonInputMapping)
        {
            if (inputMappingFields != null)
            {
                foreach (var entry in inputMappingFields)
                {
                    if (string.Equals(entry.Key, EventGridConstants.InputMappingId, StringComparison.OrdinalIgnoreCase))
                    {
                        jsonInputMapping.Id = new JsonField(entry.Value);
                    }
                    else if (string.Equals(entry.Key, EventGridConstants.InputMappingTopic, StringComparison.OrdinalIgnoreCase))
                    {
                        jsonInputMapping.Topic = new JsonField(entry.Value);
                    }
                    else if (string.Equals(entry.Key, EventGridConstants.InputMappingEventTime, StringComparison.OrdinalIgnoreCase))
                    {
                        jsonInputMapping.EventTime = new JsonField(entry.Value);
                    }
                    else if (string.Equals(entry.Key, EventGridConstants.InputMappingSubject, StringComparison.OrdinalIgnoreCase))
                    {
                        jsonInputMapping.Subject = new JsonFieldWithDefault(sourceField: entry.Value, defaultValue: null);
                    }
                    else if (string.Equals(entry.Key, EventGridConstants.InputMappingEventType, StringComparison.OrdinalIgnoreCase))
                    {
                        jsonInputMapping.EventType = new JsonFieldWithDefault(sourceField: entry.Value, defaultValue: null);
                    }
                    else if (string.Equals(entry.Key, EventGridConstants.InputMappingDataVersion, StringComparison.OrdinalIgnoreCase))
                    {
                        jsonInputMapping.DataVersion = new JsonFieldWithDefault(sourceField: entry.Value, defaultValue: null);
                    }
                }
            }

            if (inputMappingDefaultValuesDictionary != null)
            {
                foreach (var entry in inputMappingDefaultValuesDictionary)
                {
                    if (string.Equals(entry.Key, EventGridConstants.InputMappingSubject, StringComparison.OrdinalIgnoreCase))
                    {
                        if (jsonInputMapping.Subject == null)
                        {
                            jsonInputMapping.Subject = new JsonFieldWithDefault(sourceField: null, defaultValue: entry.Value);
                        }
                        else
                        {
                            jsonInputMapping.Subject.DefaultValue = entry.Value;
                        }
                    }
                    else if (string.Equals(entry.Key, EventGridConstants.InputMappingEventType, StringComparison.OrdinalIgnoreCase))
                    {
                        if (jsonInputMapping.EventType == null)
                        {
                            jsonInputMapping.EventType = new JsonFieldWithDefault(sourceField: null, defaultValue: entry.Value);
                        }
                        else
                        {
                            jsonInputMapping.EventType.DefaultValue = entry.Value;
                        }
                    }
                    else if (string.Equals(entry.Key, EventGridConstants.InputMappingDataVersion, StringComparison.OrdinalIgnoreCase))
                    {
                        if (jsonInputMapping.DataVersion == null)
                        {
                            jsonInputMapping.DataVersion = new JsonFieldWithDefault(sourceField: null, defaultValue: entry.Value);
                        }
                        else
                        {
                            jsonInputMapping.DataVersion.DefaultValue = entry.Value;
                        }
                    }
                }
            }
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
