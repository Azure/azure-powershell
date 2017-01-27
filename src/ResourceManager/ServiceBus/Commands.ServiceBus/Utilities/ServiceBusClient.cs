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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.ServiceBus;
using Microsoft.Azure.Management.ServiceBus.Models;
using Microsoft.Azure.Commands.ServiceBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace Microsoft.Azure.Commands.Servicebus
{
    public class ServiceBusClient
    {
        // Azure SDK requires a request parameter to be specified for a few Backup API calls, but
        // the request is actually optional unless an update is needed
      //  private static readonly BackupRequest EmptyRequest = new BackupRequest(location: "");

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        public ServiceBusClient(AzureContext context)
        {
            this.Client = AzureSession.ClientFactory.CreateArmClient<ServiceBusManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);

        }
        public ServiceBusManagementClient Client
        {
            get;
            private set;
        }

        #region Namespace
        public NamespaceAttributes GetNamespace(string resourceGroupName, string namespaceName)
        {
            NamespaceResource response = Client.Namespaces.Get(resourceGroupName, namespaceName);
            return new NamespaceAttributes(response);
        }

        public IEnumerable<NamespaceAttributes> ListNamespaces(string resourceGroupName)
        {
            Rest.Azure.IPage<NamespaceResource> response = Client.Namespaces.ListByResourceGroup(resourceGroupName);
            //IEnumerable<NamespaceAttributes> resourceList = response.Select(resource => new NamespaceAttributes(resourceGroupName, resource));
            IEnumerable<NamespaceAttributes> resourceList = response.Select(resource => new NamespaceAttributes(resource));
            return resourceList;
        }

        public IEnumerable<NamespaceAttributes> ListAllNamespaces()
        {
            Rest.Azure.IPage<NamespaceResource> response = Client.Namespaces.ListBySubscription();

            //var resourceList = response.Select(resource => new NamespaceAttributes(null, resource));
            var resourceList = response.Select(resource => new NamespaceAttributes(resource));
            return resourceList;
        }


        public NamespaceAttributes BeginCreateNamespace(string resourceGroupName, string namespaceName, string location, string skuName, Dictionary<string, string> tags)
        {
            NamespaceCreateOrUpdateParameters parameter = new NamespaceCreateOrUpdateParameters();
            parameter.Location = location;

            if (tags != null)
            {
                parameter.Tags = new Dictionary<string, string>(tags);
            }

            if (skuName != null)
            {
                parameter.Sku = new Sku
                {
                    Name = skuName,
                    Tier = skuName
                };
            }

            NamespaceResource response = Client.Namespaces.CreateOrUpdate(resourceGroupName, namespaceName, parameter);
            return new NamespaceAttributes(response);
        }


        public NamespaceAttributes UpdateNamespace(string resourceGroupName, string namespaceName, string location, string skuName, int? skuCapacity, Dictionary<string, string> tags)
        {

            var parameter = new NamespaceCreateOrUpdateParameters()
            {
                Location = location
            };

            if (tags != null)
            {
                parameter.Tags = new Dictionary<string, string>(tags);
            }

            Sku tempSku = new Sku();



            if (skuName != null)
            {
                tempSku.Name = skuName;
                tempSku.Tier = skuName;
            }

            if (skuCapacity != null)
            {
                tempSku.Capacity = skuCapacity;
            }

            parameter.Sku = tempSku;

            NamespaceResource response = Client.Namespaces.CreateOrUpdate(resourceGroupName, namespaceName, parameter);
            return new NamespaceAttributes(response);
        }

        public void BeginDeleteNamespace(string resourceGroupName, string namespaceName)
        {
            Client.Namespaces.Delete(resourceGroupName, namespaceName);

        }

        //internal NamespaceLongRunningOperation GetLongRunningOperationStatus(NamespaceLongRunningOperation longRunningOperation)
        //{
        //    var response = Client.Namespaces.l(longRunningOperation.OperationLink);

        //    RetryAfter(response, Client.LongRunningOperationRetryTimeout);
        //    var result = NamespaceLongRunningOperation.CreateLongRunningOperation(longRunningOperation.OperationName, response as NamespaceLongRunningResponse);

        //    return result;
        //}

        private static void RetryAfter(NamespaceLongRunningOperation longrunningResponse, int longRunningOperationInitialTimeout)
        {
            if (longRunningOperationInitialTimeout >= 0)
            {
                //longrunningResponse.RetryAfter = longRunningOperationInitialTimeout;
            }
        }
        #endregion

        #region NameSpace AuthorizationRules

        public SharedAccessAuthorizationRuleAttributes GetNamespaceAuthorizationRules(string resourceGroupName, string namespaceName, string authRuleName)
        {
            SharedAccessAuthorizationRuleResource response = Client.Namespaces.GetAuthorizationRule(resourceGroupName, namespaceName, authRuleName);

            return new SharedAccessAuthorizationRuleAttributes(response);
        }

        public IEnumerable<SharedAccessAuthorizationRuleAttributes> ListNamespaceAuthorizationRules(string resourceGroupName, string namespaceName)
        {
            Rest.Azure.IPage<SharedAccessAuthorizationRuleResource> response = Client.Namespaces.ListAuthorizationRules(resourceGroupName, namespaceName);
            IEnumerable<SharedAccessAuthorizationRuleAttributes> resourceList = response.Select(resource => new SharedAccessAuthorizationRuleAttributes(resource));

            return resourceList;
        }

        public SharedAccessAuthorizationRuleAttributes CreateOrUpdateNamespaceAuthorizationRules(string resourceGroupName, string namespaceName, string authorizationRuleName, SharedAccessAuthorizationRuleAttributes parameters)
        {
            var parameter1 = new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
            {
                Name = parameters.Name,
                Rights = parameters.Rights.ToList()
            };
            var response = Client.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, authorizationRuleName, parameter1);
            return new SharedAccessAuthorizationRuleAttributes(response);
        }

        public bool DeleteNamespaceAuthorizationRules(string resourceGroupName, string namespaceName, string authRuleName)
        {
            if (string.Equals(SharedAccessAuthorizationRuleAttributes.DefaultNamespaceAuthorizationRule, authRuleName, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            Client.Namespaces.DeleteAuthorizationRule(resourceGroupName, namespaceName, authRuleName);
            return true;
        }

        public ResourceListKeys GetNamespaceListKeys(string resourceGroupName, string namespaceName, string authRuleName)
        {
            var listKeys = Client.Namespaces.ListKeys(resourceGroupName, namespaceName, authRuleName);
            return listKeys;
        }

        public ResourceListKeys SetRegenerateKeys(string resourceGroupName, string namespaceName, string authRuleName, RegenerateKeysParameters regenerateKeys)
        {
            var regenerateKeyslistKeys = Client.Namespaces.RegenerateKeys(resourceGroupName, namespaceName, authRuleName, regenerateKeys);
            return regenerateKeyslistKeys;
        }

        #endregion 


        #region Queues 

        public QueueAttributes CreateUpdateQueue(string resourceGroupName, string namespaceName, string queueName, QueueAttributes queue)
        {
            var parameters = new QueueCreateOrUpdateParameters()
            {
                Name = queue.Name,
                Location = queue.Location,
                LockDuration = queue.LockDuration,
                AccessedAt = queue.AccessedAt,
                AutoDeleteOnIdle = queue.AutoDeleteOnIdle,
                EntityAvailabilityStatus = queue.EntityAvailabilityStatus,
                CreatedAt = queue.CreatedAt, 
                DefaultMessageTimeToLive = queue.DefaultMessageTimeToLive,
                DuplicateDetectionHistoryTimeWindow = queue.DuplicateDetectionHistoryTimeWindow,
                EnableBatchedOperations = queue.EnableBatchedOperations,
                DeadLetteringOnMessageExpiration = queue.DeadLetteringOnMessageExpiration,
                EnableExpress = queue.EnableExpress,
                EnablePartitioning = queue.EnablePartitioning,
                IsAnonymousAccessible = queue.IsAnonymousAccessible,
                MaxDeliveryCount = queue.MaxDeliveryCount,
                MaxSizeInMegabytes = queue.MaxSizeInMegabytes,
                MessageCount = queue.MessageCount,
                CountDetails = queue.CountDetails,
                RequiresDuplicateDetection = queue.RequiresDuplicateDetection,
                RequiresSession = queue.RequiresSession,
                SizeInBytes = queue.SizeInBytes,
                Status = queue.Status,
                SupportOrdering = queue.SupportOrdering,
                UpdatedAt = queue.UpdatedAt,
        };

        var response = Client.Queues.CreateOrUpdate(resourceGroupName, namespaceName, queueName, parameters);
            return new QueueAttributes(response);
        }

        public QueueResource GetQueue(string resourceGroupName, string namespaceName, string queueName)
        {
            QueueResource response = Client.Queues.Get(resourceGroupName, namespaceName, queueName);
            return response;
        }

        public QueueAttributes UpdateQueue(string resourceGroupName, string namespaceName, string queueName, string location, bool enableExpress, bool isAnonymousAccessible)
        {
            QueueCreateOrUpdateParameters parameters = new QueueCreateOrUpdateParameters()
            {
                Location = location,
                EnableExpress = enableExpress,
                IsAnonymousAccessible = isAnonymousAccessible
            };

            var response = Client.Queues.CreateOrUpdate(resourceGroupName, namespaceName, queueName, parameters);
            return new QueueAttributes(response);
        }

        public IEnumerable<QueueAttributes> ListQueues(string resourceGroupName, string namespaceName)
        {
            Rest.Azure.IPage<QueueResource> response = Client.Queues.ListAll(resourceGroupName, namespaceName);
            //IEnumerable<NamespaceAttributes> resourceList = response.Select(resource => new NamespaceAttributes(resourceGroupName, resource));
            IEnumerable<QueueAttributes> resourceList = response.Select(resource => new QueueAttributes(resource));
            return resourceList;
        }

        public bool DeleteQueue(string resourceGroupName, string namespaceName, string queueName)
        {
            Client.Queues.Delete(resourceGroupName, namespaceName, queueName);
            return true;
        }

        public SharedAccessAuthorizationRuleAttributes CreateOrUpdateServiceBusQueueAuthorizationRules(string resourceGroupName, string namespaceName, string queueName, string authorizationRuleName, SharedAccessAuthorizationRuleAttributes parameters)
        {
            var parameter1 = new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
            {
                Name = parameters.Name,
                Rights = parameters.Rights.ToList()
            };
            var response = Client.Queues.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, queueName, authorizationRuleName, parameter1);
            return new SharedAccessAuthorizationRuleAttributes(response);
        }

        public SharedAccessAuthorizationRuleAttributes GetServiceBusQueueAuthorizationRules(string resourceGroupName, string namespaceName, string queueName, string authRuleName)
        {
            SharedAccessAuthorizationRuleResource response = Client.Queues.GetAuthorizationRule(resourceGroupName, namespaceName, queueName, authRuleName);

            return new SharedAccessAuthorizationRuleAttributes(response);
        }

        public IEnumerable<SharedAccessAuthorizationRuleAttributes> ListServiceBusQueueAuthorizationRules(string resourceGroupName, string namespaceName, string queueName)
        {
            Rest.Azure.IPage<SharedAccessAuthorizationRuleResource> response = Client.Queues.ListAuthorizationRules(resourceGroupName, namespaceName,queueName);
            IEnumerable<SharedAccessAuthorizationRuleAttributes> resourceList = response.Select(resource => new SharedAccessAuthorizationRuleAttributes(resource));

            return resourceList;
        }

        public bool DeleteServiceBusQueueAuthorizationRules(string resourceGroupName, string namespaceName, string queueName, string authRuleName)
        {
            if (string.Equals(SharedAccessAuthorizationRuleAttributes.DefaultNamespaceAuthorizationRule, authRuleName, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            Client.Queues.DeleteAuthorizationRule(resourceGroupName, namespaceName, queueName, authRuleName);
            return true;
        }

        public ListKeysAttributes GetQueueKey(string resourceGroupName, string namespaceName, string queueName, string authRuleName)
        {
            var listKeys = Client.Topics.ListKeys(resourceGroupName, namespaceName, queueName, authRuleName);
            return new ListKeysAttributes(listKeys);
        }

        public ListKeysAttributes NewQueueKey(string resourceGroupName, string namespaceName, string queueName, string authRuleName, string regenerateKeys)
        {

            ResourceListKeys regenerateKeyslistKeys;
            if (regenerateKeys == "PrimaryKey")
                regenerateKeyslistKeys = Client.Queues.RegenerateKeys(resourceGroupName, namespaceName, queueName, authRuleName, new RegenerateKeysParameters(Policykey.PrimaryKey));
            else
                regenerateKeyslistKeys = Client.Queues.RegenerateKeys(resourceGroupName, namespaceName, queueName, authRuleName, new RegenerateKeysParameters(Policykey.SecondaryKey));

            return new ListKeysAttributes(regenerateKeyslistKeys);
        }

        #endregion Queues


        #region Topics 


        public TopicAttributes CreateUpdateTopic(string resourceGroupName, string namespaceName, string topicName, TopicAttributes topic)
        {
            var parameters = new TopicCreateOrUpdateParameters()
            {
                AccessedAt = topic.AccessedAt,
                AutoDeleteOnIdle = topic.AutoDeleteOnIdle,
                EntityAvailabilityStatus = topic.EntityAvailabilityStatus,
                CreatedAt = topic.CreatedAt,
                CountDetails = topic.CountDetails,
                DefaultMessageTimeToLive = topic.DefaultMessageTimeToLive,
                DuplicateDetectionHistoryTimeWindow = topic.DuplicateDetectionHistoryTimeWindow,
                EnableBatchedOperations = topic.EnableBatchedOperations,
                EnableExpress = topic.EnableExpress,
                EnablePartitioning = topic.EnablePartitioning,
                EnableSubscriptionPartitioning = topic.EnableSubscriptionPartitioning,
                FilteringMessagesBeforePublishing = topic.FilteringMessagesBeforePublishing,
                IsAnonymousAccessible = topic.IsAnonymousAccessible,
                IsExpress = topic.IsExpress,
                MaxSizeInMegabytes = topic.MaxSizeInMegabytes,
                RequiresDuplicateDetection = topic.RequiresDuplicateDetection,
                SizeInBytes = topic.SizeInBytes,
                Status = topic.Status,
                SubscriptionCount = topic.SubscriptionCount,
                SupportOrdering = topic.SupportOrdering,
                UpdatedAt = topic.UpdatedAt,
                Location = topic.Location
                
        };

            var response = Client.Topics.CreateOrUpdate(resourceGroupName, namespaceName, topicName, parameters);
            return new TopicAttributes(response);
        }

        public TopicAttributes GetTopic(string resourceGroupName, string namespaceName, string topicName)
        {
            TopicResource response = Client.Topics.Get(resourceGroupName, namespaceName, topicName);
            return new TopicAttributes(response);
        }

        public TopicAttributes UpdateTopic(string resourceGroupName, string namespaceName, string topicName, string location, bool enableExpress, bool isAnonymousAccessible)
        {
            TopicCreateOrUpdateParameters parameters = new TopicCreateOrUpdateParameters()
            {
                Location = location,
                EnableExpress = enableExpress,
                IsAnonymousAccessible = isAnonymousAccessible
            };

            var response = Client.Topics.CreateOrUpdate(resourceGroupName, namespaceName, topicName, parameters);
            return new TopicAttributes(response);
        }

        public IEnumerable<TopicAttributes> ListTopics(string resourceGroupName, string namespaceName)
        {
            Rest.Azure.IPage<TopicResource> response = Client.Topics.ListAll(resourceGroupName, namespaceName);
            //IEnumerable<NamespaceAttributes> resourceList = response.Select(resource => new NamespaceAttributes(resourceGroupName, resource));
            IEnumerable<TopicAttributes> resourceList = response.Select(resource => new TopicAttributes(resource));
            return resourceList;
        }

        public bool DeleteTopic(string resourceGroupName, string namespaceName, string topicName)
        {
            Client.Topics.Delete(resourceGroupName, namespaceName, topicName);
            return true;
        }

        public SharedAccessAuthorizationRuleAttributes CreateOrUpdateServiceBusTopicAuthorizationRules(string resourceGroupName, string namespaceName, string topicName, string authorizationRuleName, SharedAccessAuthorizationRuleAttributes parameters)
        {
            var parameter1 = new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
            {
                Name = parameters.Name,
                Rights = parameters.Rights.ToList()
            };
            var response = Client.Topics.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, topicName, authorizationRuleName, parameter1);
            return new SharedAccessAuthorizationRuleAttributes(response);
        }

        public SharedAccessAuthorizationRuleAttributes GetServiceBusTopicAuthorizationRules(string resourceGroupName, string namespaceName, string topicName, string authRuleName)
        {
            SharedAccessAuthorizationRuleResource response = Client.Topics.GetAuthorizationRule(resourceGroupName, namespaceName, topicName, authRuleName);

            return new SharedAccessAuthorizationRuleAttributes(response);
        }

        public IEnumerable<SharedAccessAuthorizationRuleAttributes> ListServiceBusTopicAuthorizationRules(string resourceGroupName, string namespaceName, string topicName)
        {
            Rest.Azure.IPage<SharedAccessAuthorizationRuleResource> response = Client.Topics.ListAuthorizationRules(resourceGroupName, namespaceName, topicName);
            IEnumerable<SharedAccessAuthorizationRuleAttributes> resourceList = response.Select(resource => new SharedAccessAuthorizationRuleAttributes(resource));

            return resourceList;
        }

        public bool DeleteServiceBusTopicAuthorizationRule(string resourceGroupName, string namespaceName, string topicName, string authRuleName)
        {
            if (string.Equals(SharedAccessAuthorizationRuleAttributes.DefaultNamespaceAuthorizationRule, authRuleName, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            Client.Topics.DeleteAuthorizationRule(resourceGroupName, namespaceName, topicName, authRuleName);
            return true;
        }

        public ListKeysAttributes GetTopicKey(string resourceGroupName, string namespaceName, string topicName, string authRuleName)
        {
            var listKeys = Client.Topics.ListKeys(resourceGroupName, namespaceName, topicName, authRuleName);
            return new ListKeysAttributes(listKeys);
        }

        public ListKeysAttributes NewTopicKey(string resourceGroupName, string namespaceName, string topicName, string authRuleName, string regenerateKeys)
        {

            ResourceListKeys regenerateKeyslistKeys;
            if (regenerateKeys == "PrimaryKey")
                regenerateKeyslistKeys = Client.Topics.RegenerateKeys(resourceGroupName, namespaceName, topicName, authRuleName, new RegenerateKeysParameters(Policykey.PrimaryKey));
            else
                regenerateKeyslistKeys = Client.Topics.RegenerateKeys(resourceGroupName, namespaceName, topicName, authRuleName, new RegenerateKeysParameters(Policykey.SecondaryKey));

            return new ListKeysAttributes(regenerateKeyslistKeys);
        }

        #endregion Topics

        #region Subscription

        public SubscriptionAttributes CreateUpdateSubscription(string resourceGroupName, string namespaceName, string topicName, string subscriptionName, SubscriptionAttributes subscription)
        {
            var parameters = new SubscriptionCreateOrUpdateParameters()
            {
                AccessedAt = subscription.AccessedAt,
                AutoDeleteOnIdle = subscription.AutoDeleteOnIdle,
                CountDetails = subscription.CountDetails,
                CreatedAt = subscription.CreatedAt,
                DefaultMessageTimeToLive = subscription.DefaultMessageTimeToLive,
                DeadLetteringOnFilterEvaluationExceptions = subscription.DeadLetteringOnFilterEvaluationExceptions,
                DeadLetteringOnMessageExpiration = subscription.DeadLetteringOnMessageExpiration,
                EnableBatchedOperations = subscription.EnableBatchedOperations,
                EntityAvailabilityStatus = subscription.EntityAvailabilityStatus,
                IsReadOnly = subscription.IsReadOnly,
                LockDuration = subscription.LockDuration,
                MaxDeliveryCount = subscription.MaxDeliveryCount,
                MessageCount = subscription.MessageCount,
                RequiresSession = subscription.RequiresSession,
                Status = subscription.Status,
                UpdatedAt = subscription.UpdatedAt,
                Location = subscription.Location
        };

            var response = Client.Subscriptions.CreateOrUpdate(resourceGroupName, namespaceName, topicName, subscriptionName, parameters);
            return new SubscriptionAttributes(response);
        }

        public SubscriptionAttributes GetSubscription(string resourceGroupName, string namespaceName, string topicName, string subscriptionName)
        {
            SubscriptionResource response = Client.Subscriptions.Get(resourceGroupName, namespaceName, topicName, subscriptionName);
            return new SubscriptionAttributes(response);
        }

        public SubscriptionAttributes UpdateSubscription(string resourceGroupName, string namespaceName, string topicName, string subscriptionName, string location, bool enableExpress, bool isAnonymousAccessible)
        {
            SubscriptionCreateOrUpdateParameters parameters = new SubscriptionCreateOrUpdateParameters()
            {
                Location = location,
                //EnableExpress = enableExpress,
                //IsAnonymousAccessible = isAnonymousAccessible
            };

            var response = Client.Subscriptions.CreateOrUpdate(resourceGroupName, namespaceName, topicName, subscriptionName, parameters);
            return new SubscriptionAttributes(response);
        }

        public IEnumerable<SubscriptionAttributes> ListSubscriptions(string resourceGroupName, string namespaceName, string topicName)
        {
            Rest.Azure.IPage<SubscriptionResource> response = Client.Subscriptions.ListAll(resourceGroupName, namespaceName,topicName);
            //IEnumerable<NamespaceAttributes> resourceList = response.Select(resource => new NamespaceAttributes(resourceGroupName, resource));
            IEnumerable<SubscriptionAttributes> resourceList = response.Select(resource => new SubscriptionAttributes(resource));
            return resourceList;
        }

        public bool DeleteSubscription(string resourceGroupName, string namespaceName, string topicName, string subscriptionName)
        {
            Client.Subscriptions.Delete(resourceGroupName, namespaceName, topicName, subscriptionName);
            return true;
        }

        #endregion Subscription

        //#region EventHub
        //public EventHubResource GetEventnHub(string resourceGroupName, string namespaceName, string eventHubName)
        //{
        //    EventHubResource response = Client.ServiceBus.Get(resourceGroupName, namespaceName, eventHubName);
        //    return response;
        //}

        ////public EventHubAttributes GetEventHubPNSCredentials(string resourceGroupName, string namespaceName, string eventHubName)
        ////{
        ////    IPage<EventHubResource> response = Client.ServiceBus.GetPnsCredentials(resourceGroupName, namespaceName, eventHubName);
        ////    return new EventHubAttributes(response);
        ////}

        //public IEnumerable<EventHubAttributes> ListServiceBus(string resourceGroupName, string namespaceName)
        //{
        //    Rest.Azure.IPage<EventHubResource> response = Client.ServiceBus.ListAll(resourceGroupName, namespaceName);
        //    IEnumerable<EventHubAttributes> resourceList = response.Select(resource => new EventHubAttributes(resource));
        //    return resourceList;
        //}

        //public EventHubAttributes CreateEventHub(string resourceGroupName, string namespaceName, string eventHubName, EventHubCreateOrUpdateParameters parameters)
        //{
        //    var parameter = new EventHubCreateOrUpdateParameters()
        //    {
        //        //Location = location
        //    };

        //    var response = Client.ServiceBus.CreateOrUpdate(resourceGroupName, namespaceName, eventHubName, parameter);
        //    return new EventHubAttributes(response);
        //}

        //public EventHubAttributes UpdateEventHub(string resourceGroupName, string namespaceName, string eventHubName, EventHubCreateOrUpdateParameters parameters)
        //{
        //    var parameter = new EventHubCreateOrUpdateParameters()
        //    {
        //       // Location = location,
        //        Name = eventHubName
        //    };

        //    var response = Client.ServiceBus.CreateOrUpdate(resourceGroupName, namespaceName, eventHubName, parameter);
        //    return new EventHubAttributes(response);
        //}

        //public bool DeleteEventHub(string resourceGroupName, string namespaceName, string eventHubName)
        //{
        //    Client.ServiceBus.Delete(resourceGroupName, namespaceName, eventHubName);
        //    return true;
        //}

        //public SharedAccessAuthorizationRuleAttributes GetEventHubAuthorizationRules(string resourceGroupName, string namespaceName, string eventHubName, string authRuleName)
        //{
        //    SharedAccessAuthorizationRuleResource response = Client.ServiceBus.GetAuthorizationRule(resourceGroupName, namespaceName,
        //                                eventHubName, authRuleName);

        //    return new SharedAccessAuthorizationRuleAttributes(response);
        //}

        //public IEnumerable<SharedAccessAuthorizationRuleAttributes> ListEventHubAuthorizationRules(string resourceGroupName, string namespaceName,
        //                                            string eventHubName)
        //{
        //    Rest.Azure.IPage<SharedAccessAuthorizationRuleResource> response = Client.ServiceBus.ListAuthorizationRules(resourceGroupName, namespaceName, eventHubName);
        //    IEnumerable<SharedAccessAuthorizationRuleAttributes> resourceList = response.Select(resource => new SharedAccessAuthorizationRuleAttributes(resource));

        //    return resourceList;
        //}


        //public SharedAccessAuthorizationRuleAttributes CreateOrUpdateEventHubAuthorizationRules(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, SharedAccessAuthorizationRuleCreateOrUpdateParameters parameters)
        //{
        //    var parameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
        //    {
        //        //Name = authRuleName,
        //        //Properties = new SharedAccessAuthorizationRuleProperties()
        //        //{
        //        //    KeyName = authRuleName,
        //        //    Rights = new List<AccessRights>(rights),
        //        //    PrimaryKey = primarykey,
        //        //    ClaimType = SharedAccessAuthorizationRuleAttributes.DefaultClaimType,
        //        //    ClaimValue = SharedAccessAuthorizationRuleAttributes.DefaultClaimValue
        //        //}
        //        Rights = parameters.Rights
        //    };

        //    //parameter.Properties.SecondaryKey = string.IsNullOrEmpty(secondaryKey) ? GenerateRandomKey() : secondaryKey;

        //    var response = Client.ServiceBus.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, eventHubName, authorizationRuleName, parameters);
        //    return new SharedAccessAuthorizationRuleAttributes(response);
        //}

        //public bool DeleteEventHubAuthorizationRules(string resourceGroupName, string namespaceName, string eventHubName, string authRuleName)
        //{
        //    if (string.Equals(SharedAccessAuthorizationRuleAttributes.DefaultNamespaceAuthorizationRule, authRuleName, StringComparison.InvariantCultureIgnoreCase))
        //    {
        //        return false;
        //    }

        //    //var response = Client.ServiceBus.DeleteAuthorizationRule(resourceGroupName, namespaceName, eventHubName, authRuleName);
        //    return true;
        //}

        //public ResourceListKeys GetEventHubListKeys(string resourceGroupName, string namespaceName, string eventHubName, string authRuleName)
        //{
        //    ResourceListKeys listKeys = Client.ServiceBus.ListKeys(resourceGroupName, namespaceName,
        //                                eventHubName, authRuleName);

        //    return listKeys;
        //}

        //#endregion

        public static string GenerateRandomKey()
        {
            byte[] key256 = new byte[32];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetBytes(key256);
            }

            return Convert.ToBase64String(key256);
        }

    }
}
