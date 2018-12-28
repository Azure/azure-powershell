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
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.EventGrid;
using Microsoft.Azure.Management.EventGrid.Models;

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

        public Topic CreateTopic(string resourceGroupName, string topicName, string location, Dictionary<string, string> tags)
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

        public EventSubscription CreateEventSubscription(
            string scope,
            string eventSubscriptionName,
            string endpoint,
            string endpointType,
            string subjectBeginsWith,
            string subjectEndsWith,
            bool isSubjectCaseSensitive,
            string[] includedEventTypes,
            string[] labels)
        {
            EventSubscription eventSubscription = new EventSubscription();
            EventSubscriptionDestination destination = null;
            const string WebHookEventSubscriptionDestination = "webhook";
            const string EventHubEventSubscriptionDestination = "eventhub";

            if (string.IsNullOrEmpty(endpointType) ||
                string.Equals(endpointType, WebHookEventSubscriptionDestination, StringComparison.OrdinalIgnoreCase))
            {
                destination = new WebHookEventSubscriptionDestination()
                {
                    EndpointUrl = endpoint
                };
            }
            else if (string.Equals(endpointType, EventHubEventSubscriptionDestination, StringComparison.OrdinalIgnoreCase))
            {
                destination = new EventHubEventSubscriptionDestination()
                {
                    ResourceId = endpoint
                };
            }
            else
            {
                throw new ArgumentNullException(nameof(endpointType), "EndpointType should be WebHook or EventHub");
            }

            if (includedEventTypes == null)
            {
                includedEventTypes = new string[1];
                includedEventTypes[0] = "All";
            }

            var filter = new EventSubscriptionFilter()
            {
                SubjectBeginsWith = subjectBeginsWith,
                SubjectEndsWith = subjectEndsWith,
                IsSubjectCaseSensitive = isSubjectCaseSensitive,
                IncludedEventTypes = new List<string>(includedEventTypes)
            };

            eventSubscription.Destination = destination;
            eventSubscription.Filter = filter;

            if (labels != null)
            {
                eventSubscription.Labels = new List<string>(labels);
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
            string[] labels)
        {
            EventSubscriptionUpdateParameters eventSubscriptionUpdateParameters = new EventSubscriptionUpdateParameters();
            const string WebHookEventSubscriptionDestination = "webhook";
            const string EventHubEventSubscriptionDestination = "eventhub";

            if (!string.IsNullOrEmpty(endpoint))
            {
                // An endpoint was specified, so it needs to be included as part of the update parameters
                // Defaulting to webhook if endpoint type was not specified
                if (string.IsNullOrEmpty(endpointType) ||
                    string.Equals(endpointType, WebHookEventSubscriptionDestination, StringComparison.OrdinalIgnoreCase))
                {
                    eventSubscriptionUpdateParameters.Destination = new WebHookEventSubscriptionDestination()
                    {
                        EndpointUrl = endpoint
                    };
                }
                else if (string.Equals(endpointType, EventHubEventSubscriptionDestination, StringComparison.OrdinalIgnoreCase))
                {
                    eventSubscriptionUpdateParameters.Destination = new EventHubEventSubscriptionDestination()
                    {
                        ResourceId = endpoint
                    };
                }
                else
                {
                    throw new ArgumentNullException(nameof(endpointType), "EndpointType should be WebHook or EventHub");
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
            else
            {
                throw new ArgumentException("Unsupported value for resourceID", nameof(resourceId));
            }
        }

        void ValidateSubscription(string providedSubscriptionId, string subscriptionIdFromContext)
        {
            if (!string.Equals(subscriptionIdFromContext, providedSubscriptionId, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("SubscriptionID from resource is different than the default subscription set in the context. Please retry after setting this subscription ID as the default subscription.");
            }
        }
    }
}
