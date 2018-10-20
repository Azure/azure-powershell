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

        public IEnumerable<Topic> ListTopicsByResourceGroup(string resourceGroupName)
        {
            return this.Client.Topics.ListByResourceGroup(resourceGroupName);
        }

        public IEnumerable<Topic> ListTopicsBySubscription()
        {
            return this.Client.Topics.ListBySubscription();
        }

        public Topic CreateTopic(
            string resourceGroupName,
            string topicName,
            string location,
            Dictionary<string, string> tags,
            string inputSchema,
            Dictionary<string, string> inputMappingFields,
            Dictionary<string, string> inputMappingDefaultValuesDictionary)
        {
            Topic topic = new Topic();
            JsonInputSchemaMapping jsonInputMapping = null;
            topic.Location = location;

            topic.InputSchema = inputSchema;

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

        public IEnumerable<Domain> ListDomainsByResourceGroup(string resourceGroupName)
        {
            return this.Client.Domains.ListByResourceGroup(resourceGroupName);
        }

        public IEnumerable<Domain> ListDomainsBySubscription()
        {
            return this.Client.Domains.ListBySubscription();
        }

        public Domain CreateDomain(
            string resourceGroupName,
            string domainName,
            string location,
            Dictionary<string, string> tags,
            string inputSchema,
            Dictionary<string, string> inputMappingFields,
            Dictionary<string, string> inputMappingDefaultValuesDictionary)
        {
            Domain domain = new Domain();
            JsonInputSchemaMapping jsonInputMapping = null;
            domain.Location = location;

            domain.InputSchema = inputSchema;

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

        public DomainTopic GetDomainTopic(string resourceGroupName, string domainName, string domainTopicName)
        {
            return this.Client.DomainTopics.Get(resourceGroupName, domainName, domainTopicName);
        }

        public IEnumerable<DomainTopic> ListDomainTopicsByDomain(string resourceGroupName, string domainName)
        {
            return this.Client.DomainTopics.ListByDomain(resourceGroupName, domainName);
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
            else
            {
                throw new ArgumentNullException(nameof(endpointType), "Invalid EndpointType. Allowed values are WebHook, EventHub, StorageQueue or HybridConnection");
            }

            if (includedEventTypes == null)
            {
                includedEventTypes = new string[1];
                includedEventTypes[0] = "All";
            }

            eventSubscription.Destination = destination;

            var filter = new EventSubscriptionFilter()
            {
                SubjectBeginsWith = subjectBeginsWith,
                SubjectEndsWith = subjectEndsWith,
                IsSubjectCaseSensitive = isSubjectCaseSensitive,
                IncludedEventTypes = new List<string>(includedEventTypes)
            };

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
                else
                {
                    throw new ArgumentNullException(nameof(endpointType), "EndpointType should be WebHook, EventHub, storage queue, or hybrid connection");
                }
            }

            if (includedEventTypes == null)
            {
                includedEventTypes = new string[1];
                includedEventTypes[0] = "All";
            }

            eventSubscriptionUpdateParameters.Filter = new EventSubscriptionFilter()
            {
                SubjectBeginsWith = subjectBeginsWith,
                SubjectEndsWith = subjectEndsWith,
                IsSubjectCaseSensitive = isSubjectCaseSensitive,
                IncludedEventTypes = new List<string>(includedEventTypes)
            };

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

        public IEnumerable<EventSubscription> ListRegionalEventSubscriptionsByResourceGroup(string resourceGroupName, string location)
        {
            return this.Client.EventSubscriptions.ListRegionalByResourceGroup(resourceGroupName, location);
        }

        public IEnumerable<EventSubscription> ListRegionalEventSubscriptionsBySubscription(string location)
        {
            return this.Client.EventSubscriptions.ListRegionalBySubscription(location);
        }

        public IEnumerable<EventSubscription> ListGlobalEventSubscriptionsByResourceGroup(string resourceGroupName)
        {
            return this.Client.EventSubscriptions.ListGlobalByResourceGroup(resourceGroupName);
        }

        public IEnumerable<EventSubscription> ListGlobalEventSubscriptionsBySubscription()
        {
            return this.Client.EventSubscriptions.ListGlobalBySubscription();
        }

        public IEnumerable<EventSubscription> ListRegionalEventSubscriptionsByResourceGroupForTopicType(string resourceGroupName, string location, string topicType)
        {
            return this.Client.EventSubscriptions.ListRegionalByResourceGroupForTopicType(resourceGroupName, location, topicType);
        }

        public IEnumerable<EventSubscription> ListRegionalEventSubscriptionsBySubscriptionForTopicType(string location, string topicType)
        {
            return this.Client.EventSubscriptions.ListRegionalBySubscriptionForTopicType(location, topicType);
        }

        public IEnumerable<EventSubscription> ListGlobalEventSubscriptionsByResourceGroupForTopicType(string resourceGroupName, string topicType)
        {
            return this.Client.EventSubscriptions.ListGlobalByResourceGroupForTopicType(resourceGroupName, topicType);
        }

        public IEnumerable<EventSubscription> ListGlobalEventSubscriptionsBySubscriptionForTopicType(string topicType)
        {
            return this.Client.EventSubscriptions.ListGlobalBySubscriptionForTopicType(topicType);
        }

        public IEnumerable<EventSubscription> ListByResource(string resourceGroupName, string providerNamespace, string resourceType, string resourceName)
        {
            return this.Client.EventSubscriptions.ListByResource(resourceGroupName, providerNamespace, resourceType, resourceName);
        }

        public IEnumerable<EventSubscription> ListByResourceId(string currentSubscriptionId, string resourceId)
        {
            string[] tokens = resourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 2)
            {
                // subscription scope
                string providedSubscriptionId = tokens[1];
                this.ValidateSubscription(providedSubscriptionId, currentSubscriptionId);

                return this.ListGlobalEventSubscriptionsBySubscription();
            }
            else if (tokens.Length == 4)
            {
                string providedSubscriptionId = tokens[1];
                this.ValidateSubscription(providedSubscriptionId, currentSubscriptionId);

                // Resource Group scope
                string resourceGroupName = tokens[3];
                return this.ListGlobalEventSubscriptionsByResourceGroup(resourceGroupName);
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
                return this.Client.EventSubscriptions.ListByResource(resourceGroupName, providerNamespace, resourceType, resourceName);
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
                return this.ListByDomainTopic(resourceGroupName, resourceName, nestedResourceName);
            }
            else
            {
                throw new ArgumentException("Unsupported value for resourceID", nameof(resourceId));
            }
        }

        public IEnumerable<EventSubscription> ListByDomainTopic(string resourceGroupName, string domainName, string domainTopicName)
        {
            return this.Client.EventSubscriptions.ListByDomainTopic(resourceGroupName, domainName, domainTopicName);
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
                    throw new Exception($"Invalid Advanced Filter parameter:. Unexpected number of entries for advanced filter #{i + 1}");
                }

                if (!advancedFilter[i].ContainsKey("Operator") ||
                    !advancedFilter[i].ContainsKey("keY") ||
                    !(advancedFilter[i].ContainsKey("value")
                    || advancedFilter[i].ContainsKey("values")))
                {
                    throw new Exception($"Invalid Advanced Filter parameter:. At least one of the key parameters is invalid for advanced filter #{i + 1}.");
                }

                string operatorValue = (string)advancedFilter[i]["operator"];

                if (string.IsNullOrEmpty(operatorValue))
                {
                    throw new Exception($"Invalid Advanced Filter parameter: Operator value is null or empty for advanced filter #{i + 1}.");
                }

                string keyValue = (string)advancedFilter[i]["key"];

                if (string.IsNullOrEmpty(keyValue))
                {
                    throw new Exception($"Invalid Advanced Filter parameter. At least one of the key value is null or empty for advanced filter #{i + 1}");
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
                    var stringEndssWithAdvFilter = new StringEndsWithAdvancedFilter
                    {
                        Key = keyValue,
                        Values = keyValuesList
                    };

                    filter.AdvancedFilters.Add(stringEndssWithAdvFilter);
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
                    throw new Exception($"Invalid Advanced Filter parameter. Unsupported operator for advanced filter #{i + 1}");
                }
            }
        }
    }
}
